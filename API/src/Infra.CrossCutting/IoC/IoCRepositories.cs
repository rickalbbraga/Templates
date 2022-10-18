using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Infra.CrossCutting.IoC;

[ExcludeFromCodeCoverage]
public static class IoCRepositories
{
    public static IServiceCollection SetIoCRepositories(this IServiceCollection service, IConfiguration configuration)
    {
        return service;
    }
}