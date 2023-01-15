using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : 
    Notifiable,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }
    
    public GenericCommandResult Handle(CreateTodoCommand command)
    {
        // Fail fat Validation
        command.Validate();
        if (command.Invalid)
        {
            return new GenericCommandResult(
                false,
                "Ops, your todo is invalid",
                command.Notifications
            );
        }
        
        // create TodoTtem
        var todo = new TodoItem(command.Title, command.User, command.Date);
        
        // save TodoItem
        _repository.Create(todo);
        
        // notify User
        return new GenericCommandResult(
            true,
            "Todo saved",
            todo
        );
    }

    public GenericCommandResult Handle(UpdateTodoCommand command)
    {
        // Fail fast validation
        command.Validate();
        if (command.Invalid)
        {
            return new GenericCommandResult(
                false,
                "Ops, your todo is invalid",
                command.Notifications
            );
        }
        
        // Find TodoItem
        var todo = _repository.GetById(command.Id, command.User);
        
        // Update Title
        todo.UpdateTitle(command.Title);
        
        // Persist in database
        _repository.Update(todo);
        
        // Return notification
        return new GenericCommandResult(
            true,
            "Todo saved",
            todo
        );
    }

    public GenericCommandResult Handle(MarkTodoAsDoneCommand command)
    {
        // Fail fast validation
        command.Validate();
        if (command.Invalid)
        {
            return new GenericCommandResult(
                false,
                "Ops, your todo is invalid",
                command.Notifications
            );
        }
        
        // Find TodoItem
        var todo = _repository.GetById(command.Id, command.User);
        
        // DONE TodoItem
        todo.MarkAsDone();
        
        // Persist in database
        _repository.Update(todo);
        
        // Return notification
        return new GenericCommandResult(
            true,
            "Todo saved",
            todo
        );
    }

    public GenericCommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        // Fail fast validation
        command.Validate();
        if (command.Invalid)
        {
            return new GenericCommandResult(
                false,
                "Ops, your todo is invalid",
                command.Notifications
            );
        }
        
        // Find TodoItem
        var todo = _repository.GetById(command.Id, command.User);
        
        // UNDONE TodoItem
        todo.MarkAsUndone();
        
        // Persist in database
        _repository.Update(todo);
        
        // Return notification
        return new GenericCommandResult(
            true,
            "Todo saved",
            todo
        );
    }
}