using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Domain.Tests.Domain.Repositories;
using Xunit;

namespace Todo.Domain.Tests.Domain.HandlerTests;

public class CreateTodoHandlerTests
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Test", "EMoonlit", DateTime.Now);
    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
    
    [Fact]
    public void ShouldCommandInvalidReturnsInvalidHandler()
    {
        var result = _handler.Handle(_invalidCommand);
        Assert.False(result.Success);
    }
    
    [Fact]
    public void ShouldCommandValidReturnsValidHandler()
    {
        var result = _handler.Handle(_validCommand);
        Assert.True(result.Success);
    }
}