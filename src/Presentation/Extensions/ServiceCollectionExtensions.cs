using Microsoft.OpenApi.Models;
using Presentation.Filters.Exceptions;

namespace Presentation.Extensions;

/// <summary>
/// Расширение для подключения сервисов Presentation
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Подключение сервисов
    /// </summary>
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers(config =>
        {
            config.Filters.Add(new ExceptionFilter());
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1.",
                Title = "Оформление заказов.",
                Description = "Проект ASP.NET Core Web API. Работает с базой данных MongoDB.",
            });
        });

        return services;
    }
}