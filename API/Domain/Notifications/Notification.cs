namespace Template.Domain.Notifications;

public class Notification
{
    public string? Code { get; set; }
    public string? Message { get; set; }

    public Notification(string? code, string? message)
    {
        Code = code;
        Message = message;
    }
}