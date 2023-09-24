using Application.MediatR.Features.Models;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    #region Поле

    /// <summary>
    /// Медиатор
    /// </summary>
    private readonly IMediator _mediator;

    #endregion
    
    #region Конструктор
    
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #endregion
    
    #region Api - Методы

    /// <summary>
    /// Получение пользователя
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <returns>Пользователя</returns>
    [HttpGet]
    public async Task<User> GetUserAsync(string id)
    {
        return await _mediator.Send(new GetUserGetCommand(new Guid(id)));
    }
    
    /// <summary>
    /// Добавление нового пользователя
    /// </summary>
    /// <param name="name">Имя</param>
    /// <param name="surname">Фамилия</param>
    [HttpPost]
    public async Task AddUserAsync(string name, string surname)
    {
        await _mediator.Send(new AddUserPostCommand(name, surname));
    }
    
    /// <summary>
    /// Изменение данных пользователя
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <param name="name">Имя/Измененное имя</param>
    /// <param name="surname">Фамилия/Измененноая фамилия</param>
    [HttpPut]
    public async Task EditUserAsync(string id, string name, string surname)
    {
        await _mediator.Send(new EditUserPutCommand(new Guid(id) ,name, surname));
    }
    
    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="id">Id пользователя</param>
    [HttpDelete]
    public async Task DeleteUserAsync(string id)
    {
        await _mediator.Send(new DeleteUserDeleteCommand(new Guid(id)));
    }

    /// <summary>
    /// Добавление заказа к пользователю
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <param name="nameOrder">Название заказа</param>
    /// <param name="descriptionOrder">Описание заказа</param>
    /// <param name="price">Цена заказа</param>
    [HttpPost]
    public async Task AddOrderUser(string id, string nameOrder, string descriptionOrder, decimal price)
    {
        await _mediator.Send(new AddOrderUserPostCommand(new Guid(id), nameOrder, descriptionOrder, price));
    }

    #endregion
}