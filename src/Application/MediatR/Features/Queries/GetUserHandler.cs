using Application.MediatR.Features.Models;
using Application.Interface;
using Application.Mediatr.Interfaces.Queries;
using Domain.Models;

namespace Application.MediatR.Features.Queries;

public class GetUserHandler : IQueryHandler<GetUserQuery, User>
{
    #region Поле

    /// <summary>
    /// Доступ к репозиторию
    /// </summary>
    private readonly IRepository _repository;

    #endregion

    #region Конструктор

    public GetUserHandler(IRepository repository)
    {
        _repository = repository;
    }

    #endregion

    #region Метод

    /// <summary>
    /// Получение пользователя
    /// </summary>
    /// <param name="query">Запрос</param>
    /// <param name="cancellationToken">Токен</param>
    /// <returns>Поьзователь</returns>
    public async Task<User> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        return await _repository.GetUserAsync(query.Id);
    }

    #endregion
}