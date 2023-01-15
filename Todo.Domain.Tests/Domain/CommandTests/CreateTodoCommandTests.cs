using System;
using Todo.Domain.Commands;
using Xunit;

namespace Todo.Domain.Tests.Domain.CommandTests;

public class CreateTodoCommandTests
{
    [Fact]
    public void ShouldCommandIsInvalid()
    {
        var command = new CreateTodoCommand("", "", DateTime.Now);
        command.Validate();
        
        Assert.False(command.Valid);
    }

    [Fact]
    public void ShouldCommandIsValid()
    {
        var command = new CreateTodoCommand("Teste", "EMoonlit", DateTime.Now);
        command.Validate();
        
        Assert.True(command.Valid);
    }

}