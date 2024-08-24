using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class User
{
    [Key] public int Id { get; set; }
    public required string Username { get; set; }
    public required string HashedPassword { get; set; }
    public List<Todo> Todos { get; set; } = [];
    public required string Role { get; set; }

    public static User CreateCustomer(string username)
    {
        return new User
        {
            Username = username,
            HashedPassword = MethodHelper.ComputeSHA512Hash(Constants.PASSWORD_DEFAULT),
            Role = Constants.ROLE_CUSTOMER
        };
    }

    public static User CreateAdmin()
    {
        return new User
        {
            Id = 1,
            Username = "BehzadDara",
            HashedPassword = MethodHelper.ComputeSHA512Hash(Constants.PASSWORD_DEFAULT),
            Role = Constants.ROLE_ADMIN
        };
    }
}
