using TodoList.DTOs.Todo;
using TodoList.Models;

namespace TodoList.Services.Contracts;

public interface ITodoService
{
    Task<Todo?> Create(CreateTodoDTO input);
    Task<Todo?> Check(int id);
    Task<Todo?> Get(int id);
    Task<List<Todo>> Get();
    Task<Todo> Update(UpdateTodoDTO input);
    Task<bool> Delete(int id);
}

