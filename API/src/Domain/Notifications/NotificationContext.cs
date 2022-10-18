namespace Template.Domain.Notifications;

public class NotificationContext
{
    private readonly List<Notification> _notifications;
    public IReadOnlyCollection<Notification> Notifications => _notifications;
    public bool HasNotifications => _notifications.Any();

    public NotificationContext()
    {
        _notifications = new List<Notification>();
    }

    public void AddNotification(string? code, string? message)
    {
        _notifications.Add(new Notification(code, message));
    }
        
    public void AddNotifications(List<Notification> notifications)
    {
        notifications.ForEach(n => _notifications.Add(n));
    }

    public void CleanNotifications() => _notifications.Clear();
}