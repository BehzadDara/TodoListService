namespace TodoList.DTOs;

public class ChangePasswordDTO
{
    public required string CurrentPassword { get; set; }
    public required string NewPassword { get; set; }
}
