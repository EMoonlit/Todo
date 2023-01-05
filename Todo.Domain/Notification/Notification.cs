using Todo.Domain.ValueObjects;

namespace Todo.Domain.Notification;

public class Notification : INotification
{
    private List<NotificationErrorProps> _errorPropsList = new();
    
    public void AddError(NotificationErrorProps error)
    {
        _errorPropsList.Add(error);
    }

    public bool HasErrors()
    {
        return _errorPropsList.Count > 0;
    }

    public IEnumerable<NotificationErrorProps> GetErrors()
    {
        return _errorPropsList;
    }

    public string GetMessages(string? context)
    {
        var message = "";
        foreach (var error in _errorPropsList)
        {
            message += $"{error.Message}, {error.Context} \n";
        }

        return message;
    }
}