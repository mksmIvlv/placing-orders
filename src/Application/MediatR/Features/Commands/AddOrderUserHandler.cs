using Application.Interface;
using Application.MediatR.Features.Models;
using Application.Mediatr.Interfaces.Commands;
using Domain.Models;
using MediatR;

namespace Application.MediatR.Features.Commands;

public class AddOrderUserHandler : ICommandHandler<AddOrderUserCommand, Unit>
{
    #region Поле

    /// <summary>
    /// Доступ к репозиторию
    /// </summary>
    private readonly IRepository _repository;

    #endregion

    #region Конструктор

    public AddOrderUserHandler(IRepository repository)
    {
        _repository = repository;
    }

    #endregion

    #region Метод

    /// <summary>
    /// Добавление заказа к пользователю
    /// </summary>
    /// <param name="command">Команда</param>
    /// <param name="cancellationToken">Токен</param>
    public async Task<Unit> Handle(AddOrderUserCommand command, CancellationToken cancellationToken)
    {
        var order = new Order(command.NameOrder, command.DescriptionOrder, command.Price);
        
        await _repository.AddOrderUserAsync(command.IdUser, order);
        
        return await Unit.Task;
    }

    #endregion
}