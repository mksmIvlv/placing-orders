namespace Domain.Models;

/// <summary>
/// Заказ
/// </summary>
public class Order
{
    #region Свойства

    /// <summary>
    /// Id заказа
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Название заказа
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Описание заказа
    /// </summary>
    public string Description { get; }
    
    /// <summary>
    /// Цена заказа
    /// </summary>
    public decimal Price { get; }
    
    /// <summary>
    /// Дата оформления заказа
    /// </summary>
    public DateTime DateRegistration { get; }

    #endregion

    #region Конструктор

    public Order(string name, string description, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        DateRegistration = DateTime.Now;
    }

    #endregion
}