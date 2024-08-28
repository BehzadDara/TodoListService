using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DTOs;
using TodoList.Models;

namespace ToDoList.Services.Contracts
{
    public interface IUserService
    {
        Task<string?> Login(LoginDTO input);
        Task<string> Refresh();
        Task<bool> ChangePassword(ChangePasswordDTO input);
        Task<User?> Create(CreateUserDTO input);
    }
}