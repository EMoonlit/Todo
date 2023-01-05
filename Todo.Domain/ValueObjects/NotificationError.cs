namespace Todo.Domain.ValueObjects;

public class NotificationError : Exception
{
    public NotificationError(string error) : base(error)
    {
    }
}