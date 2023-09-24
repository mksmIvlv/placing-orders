using Application.MediatR.Features.Models;
using Application.Mediatr.Interfaces.Commands;
using Application.Interface;
using Domain.Models;

namespace Application.MediatR.Features.Queries;

public class GetUserHandler : ICommandHandler<GetUserGetCommand, User>
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
    /// <param name="command">Команда</param>
    /// <param name="cancellationToken">Токен</param>
    /// <returns></returns>
    public async Task<User> Handle(GetUserGetCommand command, CancellationToken cancellationToken)
    {
        return await _repository.GetUserAsync(command.Id);
    }

    #endregion
}