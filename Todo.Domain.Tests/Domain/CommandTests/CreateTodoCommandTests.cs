using System;
using Todo.Domain.Commands;
using Xunit;

namespace Todo.Domain.Tests.Domain.CommandTests;

public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Test", "EMoonlit", DateTime.Now);
    
    [Fact]
    public void ShouldCommandIsInvalid()
    {
        _invalidCommand.Validate();
        
        Assert.False(_invalidCommand.Valid);
    }

    [Fact]
    public void ShouldCommandIsValid()
    {
        _validCommand.Validate();
        
        Assert.True(_validCommand.Valid);
    }

}