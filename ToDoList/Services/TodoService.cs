using Microsoft.EntityFrameworkCore;
using TodoList.DTOs;
using TodoList.Models;

namespace TodoList.Services;

public class TodoService(
    TodoListDBContext context,
    CurrentUser currentUser)
{
    public async Task<Todo?> Create(CreateTodoDTO input)
    {
        var todo = Todo.Create(int.Parse(currentUser.Id), input.Title, input.Description);

        await context.Todos.AddAsync(todo);
        await context.SaveChangesAsync();

        return todo;
    }

    public async Task<Todo?> Check(int id)
    {
        var todo = await context.Todos.FirstOrDefaultAsync(x =>
            x.Id == id &&
            x.UserId == int.Parse(currentUser.Id));

        if (todo is null)
        {
            return null;
        }

        todo.IsDone = true;
        await context.SaveChangesAsync();

        return todo;
    }

    public async Task<Todo?> Get(int id)
    {
        var todo = await context.Todos.FirstOrDefaultAsync(x =>
            x.Id == id &&
            x.UserId == int.Parse(currentUser.Id));

        if (todo is null)
        {
            return null;
        }

        return todo;
    }

    public async Task<List<Todo>> Get()
    {
        var todos = await context.Todos.Where(x =>
            x.UserId == int.Parse(currentUser.Id))
            .ToListAsync();

        return todos;
    }
}
