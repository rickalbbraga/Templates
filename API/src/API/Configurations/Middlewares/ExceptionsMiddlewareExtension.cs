using System.Diagnostics.CodeAnalysis;

namespace Template.API.Configurations.Middlewares;

[ExcludeFromCodeCoverage]
public static class ExceptionsMiddlewareExtension
{
    public static IApplicationBuilder UserExceptions(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionsMiddleware>();
    }
}