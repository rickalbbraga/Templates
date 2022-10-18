using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Template.Domain.DTOs.Responses;
using Template.Domain.Notifications;

namespace Template.API.Configurations.Filters;

[ExcludeFromCodeCoverage]
public class NotificationFilter : IAsyncResultFilter
{
    private const string ContextType = "application/json";
    private const string TitleResponse = "Bad Request";
    private readonly NotificationContext _notificationContext;
        
    public NotificationFilter(NotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
    }
    
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (_notificationContext.HasNotifications)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.HttpContext.Response.ContentType = ContextType;

            var errors = _notificationContext.Notifications.Select(e => new ErrorResponseDto()
            {
                Title = TitleResponse,
                Code = e.Code,
                Details = e.Message
            }).ToList();

            var notifications = JsonSerializer.Serialize(errors);
            await context.HttpContext.Response.WriteAsync(notifications);

            return;
        }

        await next();
    }
}