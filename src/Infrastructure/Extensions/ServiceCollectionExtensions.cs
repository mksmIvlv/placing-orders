using Application.Interface;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NSubstitute;

namespace Infrastructure.Extensions;

/// <summary>
/// Расширение для подключения сервисов Infrastructure
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Подключение сервисов
    /// </summary>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("DefaultConnection");
        services.AddSingleton<IMongoClient>(sp =>  new MongoClient(connection));
        services.AddSingleton<IRepository, Repository>();

        Configurations.UserConfiguration.AddUserConfiguration();
        Configurations.OrderConfiguration.AddOrderConfiguration();
        
        return services;
    }
}