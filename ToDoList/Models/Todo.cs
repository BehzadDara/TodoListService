using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class Todo
{
    [Key] public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsDone { get; set; } = false;

    public static Todo Create(int userId, string title, string description)
    {
        return new Todo
        {
            UserId = userId,
            Title = title,
            Description = description
        };
    }
}
