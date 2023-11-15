using Application.MediatR.Features.Models;
using Application.Mediatr.Interfaces.Commands;
using Application.Interface;
using MediatR;

namespace Application.MediatR.Features.Commands;

public class DeleteUserHandler : ICommandHandler<DeleteUserCommand, Unit>
{
    #region Поле

    /// <summary>
    /// Доступ к репозиторию
    /// </summary>
    private readonly IRepository _repository;

    #endregion

    #region Конструктор

    public DeleteUserHandler(IRepository repository)
    {
        _repository = repository;
    }

    #endregion

    #region Метод

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="command">Команда</param>
    /// <param name="cancellationToken">Токен</param>
    public async Task<Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        await _repository.DeleteUserAsync(command.Id);
        
        return await Unit.Task;
    }

    #endregion
    
    
}