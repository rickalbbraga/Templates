using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using Template.Domain.DTOs.Responses;

namespace Template.API.Configurations.Middlewares;

[ExcludeFromCodeCoverage]
public class ExceptionsMiddleware
{
    private const string ContentType = "application/json";
    private const string TitleErrorMessage = "Internal Server Error.";
    private const string ErrorMessage = "An error unexpected occured.";
    
    private readonly RequestDelegate _next;

    public ExceptionsMiddleware(
        RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            //TODO: add logger
            Console.WriteLine(e);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = ContentType;
            await context.Response.WriteAsync(BuildResponse());
        }
    }

    private string BuildResponse()
    {
        return JsonSerializer.Serialize(new ErrorResponseDto
        {
            Title = TitleErrorMessage,
            Code = HttpStatusCode.InternalServerError.ToString(),
            Details = ErrorMessage
        });
    }
}