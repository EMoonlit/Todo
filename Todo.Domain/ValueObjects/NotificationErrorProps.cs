namespace Todo.Domain.ValueObjects;


    public class NotificationErrorProps
    {
        public string Message { get; set; }
        public string Context { get; set; }

        public NotificationErrorProps(string message, string context)
        {
            Message = message;
            Context = context;
        }
    }
