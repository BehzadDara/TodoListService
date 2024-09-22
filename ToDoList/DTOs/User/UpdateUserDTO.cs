namespace TodoList.DTOs.User;

public class UpdateUserDTO : CreateUserDTO
{
    public int Id { get; set; }
    public string Role { get; set; }
}
