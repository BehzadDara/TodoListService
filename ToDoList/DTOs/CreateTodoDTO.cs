namespace TodoList.DTOs;

public class CreateTodoDTO
{
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
}
