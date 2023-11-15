using Application.Mediatr.Interfaces.Commands;
using MediatR;

namespace Application.MediatR.Features.Models;

public class AddOrderUserCommand : ICommand<Unit>
{
    #region Свойства

    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid IdUser { get; }
    
    /// <summary>
    /// Название заказа
    /// </summary>
    public string NameOrder { get; }
    
    /// <summary>
    /// Описание заказа
    /// </summary>
    public string DescriptionOrder { get; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; }

    #endregion

    #region Конструктор

    public AddOrderUserCommand(Guid idUser, string nameOrder, string descriptionOrder, decimal price)
    {
        IdUser = idUser;
        NameOrder = nameOrder;
        DescriptionOrder = descriptionOrder;
        Price = price;
    }

    #endregion
}