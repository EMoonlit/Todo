using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands.Request;

public class CreateTodoCommand
{
    public string Title { get; set; }
    public string User { get; set; }
    public DateTime Date { get; set; }
    
    public CreateTodoCommand(string title, string user, DateTime date)
    {
        Title = title;
        User = user;
        Date = date;
    }


}