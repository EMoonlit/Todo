using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts;

// Add restriction T need ICommand base
public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}