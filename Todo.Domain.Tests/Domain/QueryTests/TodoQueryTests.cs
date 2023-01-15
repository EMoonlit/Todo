using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Xunit;

namespace Todo.Domain.Tests.Domain.QueryTests;

public class TodoQueryTests
{
    private readonly string user1 = "User1";
    private readonly string user2 = "User2";
    
    private readonly List<TodoItem> _items;

    public TodoQueryTests()
    {
        _items = new List<TodoItem>
        {
            new TodoItem("Todo 1", user1, DateTime.Now),
            new TodoItem("Todo 2", user1, DateTime.Now),
            new TodoItem("Todo 3", user2, DateTime.Now),
            new TodoItem("Todo 4", user1, DateTime.Now),
            new TodoItem("Todo 5", user2, DateTime.Now)
        };
    }
    
    [Fact]
    public void ShouldQueryReturnOnlyTodosOfSelectedUser()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll(user2));
        Assert.True(_items.Count(x => x.User == user2) == result.Count());
    }
    
    [Fact]
    public void ShouldQueryReturnOnlyTodosDoneOfSelectedUser()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAllDone(user2));
        Assert.True(_items.Count(x => 
            x.User == user2 &&
            x.Done) == result.Count());
    }
    
    [Fact]
    public void ShouldQueryReturnOnlyTodosUndoneOfSelectedUser()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone(user2));
        Assert.True(_items.Count(x => 
            x.User == user2 &&
            x.Done == false) == result.Count());
    }
    
    [Fact]
    public void ShouldQueryReturnOnlyTodosByPeriodOfSelectedUser()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod(user2, DateTime.Now, false));
        Assert.True(_items.Count(x => 
            x.User == user2 &&
            x.Done == false &&
            x.Date.Date == DateTime.Now.Date) == result.Count());
    }
}