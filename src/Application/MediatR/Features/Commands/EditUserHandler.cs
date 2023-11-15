using Application.MediatR.Features.Models;
using Application.Mediatr.Interfaces.Commands;
using Application.Interface;
using MediatR;

namespace Application.MediatR.Features.Commands;

public class EditUserHandler : ICommandHandler<EditUserCommand, Unit>
{
    #region Поле

    /// <summary>
    /// Доступ к репозиторию
    /// </summary>
    private readonly IRepository _repository;

    #endregion

    #region Конструктор

    public EditUserHandler(IRepository repository)
    {
        _repository = repository;
    }

    #endregion

    #region Метод

    /// <summary>
    /// Изменение данных пользователя
    /// </summary>
    /// <param name="command">Команда</param>
    /// <param name="cancellationToken">Токен</param>
    public async Task<Unit> Handle(EditUserCommand command, CancellationToken cancellationToken)
    {
        await _repository.EditUserAsync(command.Id, command.Name, command.Surname);
        
        return await Unit.Task;
    }

    #endregion
    
    
}