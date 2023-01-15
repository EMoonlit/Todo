using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Domain.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todo)
    {
        
    }

    public void Update(TodoItem todo)
    {
        
    }

    public TodoItem GetById(Guid id, string user)
    {
        return new TodoItem("Title", "User", DateTime.Now);
    }
}