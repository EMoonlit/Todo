using Todo.Domain.Notification;
using Todo.Domain.ValueObjects;

namespace Todo.Domain.Entities;

public class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? ContactNumber { get; set; }

    private INotification _notification = new Notification.Notification();

    public User(string firstName, string lastName, string email, string? contactNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ContactNumber = contactNumber;
        Validate();
        Validator(this);
    }

    public void Validator(User user)
    {
        if (user._notification.HasErrors())
        {
            throw new NotificationError(user._notification.GetMessages("User"));
        }
    }

    public void Validate()
    {
        if (string.IsNullOrEmpty(FirstName))
        {
            
            _notification.AddError(new NotificationErrorProps(
                "User",
                "FirstName is required")
            );
        }

        if (string.IsNullOrEmpty(LastName))
        {
            _notification.AddError(new NotificationErrorProps(
                "User",
                "LastName is required")
            );
        }

        if (string.IsNullOrEmpty(Email))
        {
            _notification.AddError(new NotificationErrorProps(
                "User",
                "Email is required")
            );
        }
    }
}