using Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Configurations;

/// <summary>
/// Конфигуарция пользователя
/// </summary>
public static class UserConfiguration
{
    /// <summary>
    /// Конфигурация
    /// </summary>
    public static void AddUserConfiguration()
    {
        BsonClassMap.RegisterClassMap<User>(q =>
        {
            q.AutoMap();
            q.MapIdMember(e => e.Id).SetSerializer(new GuidSerializer(BsonType.String));
        });
    }
}