using Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Configurations;

/// <summary>
/// Конфигурация заказа
/// </summary>
public static class OrderConfiguration
{
    /// <summary>
    /// Конфигурация
    /// </summary>
    public static void AddOrderConfiguration()
    {
        BsonClassMap.RegisterClassMap<Order>(q =>
        {
            q.AutoMap();
            q.MapIdMember(e => e.Id).SetSerializer(new GuidSerializer(BsonType.String));
            q.MapMember(e => e.Price).SetSerializer(new DecimalSerializer(BsonType.Decimal128));
        });
    }
}