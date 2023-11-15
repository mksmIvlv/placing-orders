using Application.Interface;
using Application.MediatR.Features.Models;
using Application.Mediatr.Interfaces.Commands;
using MediatR;

namespace Application.MediatR.Features.Commands;

public class AddUserHandler : ICommandHandler<AddUserCommand, Unit>
{
    #region Поле

    /// <summary>
    /// Доступ к репозиторию
    /// </summary>
    private readonly IRepository _repository;

    #endregion

    #region Конструктор

    public AddUserHandler(IRepository repository)
    {
        _repository = repository;
    }

    #endregion

    #region Метод

    /// <summary>
    /// Добавление нового пользователя
    /// </summary>
    /// <param name="command">Команда</param>
    /// <param name="cancellationToken">Токен</param>
    public async Task<Unit> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        await _repository.AddUserAsync(command.Name, command.Surname);
        
        return await Unit.Task;
    }

    #endregion

    
    
    
}