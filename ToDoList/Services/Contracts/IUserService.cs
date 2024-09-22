using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DTOs.User;
using TodoList.Models;

namespace ToDoList.Services.Contracts
{
    public interface IUserService
    {
        Task<string?> Login(LoginDTO input);
        Task<string> Refresh();
        Task<bool> ChangePassword(ChangePasswordDTO input);
        Task<User?> Create(CreateUserDTO input);
        Task<User?> Update(UpdateUserDTO input);
        Task<bool> Delete(int id);
        Task<IEnumerable<UserDTO>> GetAll();   
    }
}