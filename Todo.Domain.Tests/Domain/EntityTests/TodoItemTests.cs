using System;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Xunit;

namespace Todo.Domain.Tests.Domain.EntityTests;

public class TodoItemTests
{
    private readonly TodoItem _validTodo = new TodoItem(
        "Title",
        "User",
        DateTime.Now
    );

    [Fact]
    public void ShouldANewTodoPropDoneNeedIsFalse()
    {
        Assert.True(_validTodo.Done == false);
    }

}
