using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Notifications;

namespace Template.Infra.CrossCutting.IoC;

[ExcludeFromCodeCoverage]
public static class IoCServices
{
    public static IServiceCollection SetIoCServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<NotificationContext>();
        
        return service;
    }
}