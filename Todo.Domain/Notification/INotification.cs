using Todo.Domain.ValueObjects;

namespace Todo.Domain.Notification;

public interface INotification
{
    void AddError(NotificationErrorProps notificationErrorProps);
    bool HasErrors();
    IEnumerable<NotificationErrorProps> GetErrors();
    string GetMessages(string? context);
}