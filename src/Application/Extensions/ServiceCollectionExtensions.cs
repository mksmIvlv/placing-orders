using Application.Mediatr.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Extensions;

/// <summary>
/// Расширение для подключения сервисов Application
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Подключение сервисов
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // FluentValidation
        services.AddValidatorsFromAssemblyContaining(typeof(ServiceCollectionExtensions));

        // MediatR
        services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(DataValidationPipelineBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehaviour<,>));
        
        
        return services;
    }
}