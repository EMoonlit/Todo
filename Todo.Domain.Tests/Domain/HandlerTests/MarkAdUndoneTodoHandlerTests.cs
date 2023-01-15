using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Domain.Tests.Domain.Repositories;
using Xunit;

namespace Todo.Domain.Tests.Domain.HandlerTests;

public class MarkAsUndoneTodoHandlerTests
{
    private readonly MarkTodoAsUndoneCommand _invalidCommand = new MarkTodoAsUndoneCommand(
        Guid.Parse("e008c65a-647e-46eb-98c8-79fe4d453fbb"), 
        ""
    );
    
    private readonly MarkTodoAsUndoneCommand _validCommand = new MarkTodoAsUndoneCommand(
        Guid.Parse("e008c65a-647e-46eb-98c8-79fe4d453fbb"), 
        "EMoonlit"
    );
        
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