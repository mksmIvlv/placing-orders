using Domain.Models;

namespace Application.Interface;

public interface IRepository
{
    /// <summary>
    /// Получение пользователя
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <returns>Пользователя</returns>
    public Task<User> GetUserAsync(Guid id);
    
    /// <summary>
    /// Добавление нового пользователя
    /// </summary>
    /// <param name="name">Имя</param>
    /// <param name="surname">Фамилия</param>
    public Task AddUserAsync(string name, string surname);

    /// <summary>
    /// Изменение данных пользователя
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <param name="name">Имя/Измененное имя</param>
    /// <param name="surname">Фамилия/Измененноая фамилия</param>
    public Task EditUserAsync(Guid id, string name, string surname);

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="id">Id пользователя</param>
    public Task DeleteUserAsync(Guid id);

    /// <summary>
    /// Добавление заказа к пользователю
    /// </summary>
    /// <param name="idUser">Id пользователя</param>
    /// <param name="newOrder">Заказ</param>
    public Task AddOrderUserAsync(Guid idUser, Order newOrder);
}