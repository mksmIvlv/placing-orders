using FluentValidation;
using MediatR;

namespace Application.Mediatr.Pipelines;

/// <summary>
/// Pipeline валидации входящих данных
/// </summary>
/// <typeparam name="TIn">Входной тип данных</typeparam>
/// <typeparam name="TOut">Тип возвращаемого значения</typeparam>
public class DataValidationPipelineBehaviour<TIn, TOut> : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
{
    #region Поле

    /// <summary>
    /// Коллекция валидаторов
    /// </summary>
    private readonly IEnumerable<IValidator<TIn>> _validators;

    #endregion

    #region Конструктор

    public DataValidationPipelineBehaviour(IEnumerable<IValidator<TIn>> validators)
    {
        _validators = validators;
    }

    #endregion
    
    #region Метод
    
    /// <summary>
    /// Валидация
    /// </summary>
    /// <param name="request">Запрос, который пришел</param>
    /// <param name="next">Метод, который должен выполниться</param>
    /// <param name="cancellationToken">Токен</param>
    /// <returns>Возвращаемый тип, метода, который должен выполниться</returns>
    public async Task<TOut> Handle(TIn request, RequestHandlerDelegate<TOut> next, CancellationToken cancellationToken)
    {
        if(!_validators.Any())
            return await next();
        
        var context = new ValidationContext<TIn>(request);

        foreach (var validator in _validators)
        {
            var validationResult = await validator.ValidateAsync(context, cancellationToken);
            if (validationResult.Errors.Any())
                throw new ValidationException(validationResult.Errors);
        }
        
        return await next();
    }
    
    #endregion
}