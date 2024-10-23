using Microsoft.EntityFrameworkCore;
using TodoList.DTOs.Todo;
using TodoList.Models;
using TodoList.Services.Contracts;

namespace TodoList.Services;

public class TodoService(
    TodoListDBContext context,
    CurrentUser currentUser) : ITodoService
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

    public async Task<Todo> Update(UpdateTodoDTO input)
    {
        var todo = await context.Todos.FirstOrDefaultAsync(x =>
            x.Id == input.Id);

        if (todo is null)
        {
            return null;
        }

        todo.Description = input.Description;
        todo.Id = input.Id;
        todo.Title = input.Title;
        todo.IsDone = input.IsDone;
        await context.SaveChangesAsync();
        return todo;
    }

    public async Task<bool> Delete(int id)
    {
        var todo = await context.Todos.FirstOrDefaultAsync(x =>
            x.Id == id);

        if (todo is null)
        {
            return false;
        }

        context.Todos.Remove(todo);
        await context.SaveChangesAsync();
        return true;
    }
}
