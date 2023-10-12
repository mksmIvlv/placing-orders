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
    public string Name { get; private set; }
    
    /// <summary>
    /// Описание заказа
    /// </summary>
    public string Description { get; private set; }
    
    /// <summary>
    /// Цена заказа
    /// </summary>
    public decimal Price { get; private set; }
    
    /// <summary>
    /// Дата оформления заказа
    /// </summary>
    public DateOnly DateRegistration { get; private set; }
    
    /// <summary>
    /// Время оформления заказа
    /// </summary>
    public TimeOnly TimeRegistration { get; private set; }

    #endregion

    #region Конструктор

    public Order(string name, string description, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        DateRegistration = DateOnly.FromDateTime(DateTime.Now);
        TimeRegistration = TimeOnly.FromDateTime(DateTime.Now);
    }

    #endregion
}