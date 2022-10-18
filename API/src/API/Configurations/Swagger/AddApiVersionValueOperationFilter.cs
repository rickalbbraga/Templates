using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Template.API.Configurations.Swagger;

[ExcludeFromCodeCoverage]
public class AddApiVersionValueOperationFilter : IOperationFilter
{
    private const string ApiVersionQueryParameter = "api-version";
    
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var apiVersionParameter = operation.Parameters.SingleOrDefault(p => p.Name == ApiVersionQueryParameter);

        if (apiVersionParameter == null)
            return;

        var attribute = context.MethodInfo.DeclaringType?
            .GetCustomAttributes(typeof(ApiVersionAttribute), false)
            .Cast<ApiVersionAttribute>()
            .SingleOrDefault();
            
        var version = attribute?.Versions.SingleOrDefault()?.ToString();

        if (version != null)
        {
            apiVersionParameter.Example = new OpenApiString(version);
            apiVersionParameter.Schema.Example = new OpenApiString(version);
        }
    }
}