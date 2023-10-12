namespace Domain.Models;

/// <summary>
/// Пользователь
/// </summary>
public class User
{
    #region Свойства

    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string Surname { get; private set; }

    /// <summary>
    /// Коллекция заказов у пользователя
    /// </summary>
    public ICollection<Order> CollectionOrders { get; private set; }

    #endregion

    #region Конструктор

    public User(string name, string surname)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        CollectionOrders = new List<Order>();
    }

    #endregion
}