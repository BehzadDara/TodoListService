namespace TodoList.DTOs.Todo;

public class UpdateTodoDTO : CreateTodoDTO
{
    public int Id { get; set; }
    public bool IsDone { get; set; }
}
