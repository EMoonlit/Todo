using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;


public class MarkTodoAsUndoneCommand : Notifiable, ICommand
{
    public Guid Id { get; set; }
    public string User { get; set; }

    public MarkTodoAsUndoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasLen(Id.ToString(), 36, "Id", "Invalid Id")
                .HasMinLen(User, 6, "User", "Invalid User")
        );
    }
}