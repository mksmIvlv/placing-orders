using Application.Interface;
using Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure;

public class Repository : IRepository
{
    #region Константы

    /// <summary>
    /// Id для поиска
    /// </summary>
    private const string PATTERN_ID = "_id";
    
    /// <summary>
    /// Установка данных
    /// </summary>
    private const string PATTERN_SET = "$set";

    /// <summary>
    /// Обнолвение данных
    /// </summary>
    private const string PATTERN_PUSH = "$push";

    #endregion

    #region Поле
    
    /// <summary>
    /// Коллекция с пользователями в бд
    /// </summary>
    private readonly IMongoCollection<User> _mongoCollection;

    #endregion

    #region Конструктор

    public Repository(IMongoClient client)
    {
        var dataBase = client.GetDatabase("Homework");
        _mongoCollection = dataBase.GetCollection<User>("Users");
    }

    #endregion

    #region Методы

    /// <summary>
    /// Получение пользователя
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <returns>Пользователя</returns>
    public async Task<User> GetUserAsync(Guid id)
    {
        var user = await _mongoCollection.Find(new BsonDocument(PATTERN_ID, id.ToString())).FirstAsync();
        
        return user;
    }
    
    /// <summary>
    /// Добавление нового пользователя
    /// </summary>
    /// <param name="name">Имя</param>
    /// <param name="surname">Фамилия</param>
    public async Task AddUserAsync(string name, string surname)
    {
        var user = new User(name, surname);
        await _mongoCollection.InsertOneAsync(user);
    }

    /// <summary>
    /// Изменение данных пользователя
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <param name="name">Имя/Измененное имя</param>
    /// <param name="surname">Фамилия/Измененноая фамилия</param>
    public async Task EditUserAsync(Guid id, string name, string surname)
    {
        var filter = new BsonDocument(PATTERN_ID, id.ToString());
        var updateName = new BsonDocument(PATTERN_SET, new BsonDocument("Name", name));
        var updateSurname = new BsonDocument(PATTERN_SET, new BsonDocument("Surname", surname));
        
        await _mongoCollection.UpdateOneAsync(filter, updateName);
        await _mongoCollection.UpdateOneAsync(filter, updateSurname);
    }

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="id">Id пользователя</param>
    public async Task DeleteUserAsync(Guid id)
    {
        await _mongoCollection.DeleteOneAsync(new BsonDocument(PATTERN_ID, id.ToString()));
    }

    /// <summary>
    /// Добавление заказа к пользователю
    /// </summary>
    /// <param name="idUser">Id пользователя</param>
    /// <param name="newOrder">Заказ</param>
    public async Task AddOrderUserAsync(Guid idUser, Order newOrder)
    {
        var filter = new BsonDocument(PATTERN_ID, idUser.ToString());
        var updateCollectionOrders = new BsonDocument(PATTERN_PUSH, new BsonDocument("CollectionOrders", newOrder.ToBsonDocument()));
        
        await _mongoCollection.UpdateOneAsync(filter,  updateCollectionOrders);
    }

    #endregion
}