using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.DTOs.Todo;
using TodoList.DTOs.User;
using TodoList.Services.Contracts;
using ToDoList.Services.Contracts;

namespace TodoList;

public static class Endpoint
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/User");

        group.MapPost("/Login",
        async ([FromBody] LoginDTO input, IUserService service) =>
        {
            var token = await service.Login(input);
            return token is null ? Results.NotFound() : Results.Ok(token);
        });

        group.MapPost("/Refresh",
        async (IUserService service) =>
        {
            var token = await service.Refresh();
            return Results.Ok(token);
        });

        group.MapPost("/ChangePassword", [Authorize]
        async ([FromBody] ChangePasswordDTO input, IUserService service) =>
        {
            var result = await service.ChangePassword(input);
            return result ? Results.NoContent() : Results.BadRequest();
        });

        group.MapPost("/Create", [Authorize(Roles = Constants.ROLE_ADMIN)]
        async ([FromBody] CreateUserDTO input, IUserService service) =>
        {
            var user = await service.Create(input);
            return user is null ? Results.Conflict() : Results.Ok(user);
        });

        group.MapPut("/Update", [Authorize(Roles = Constants.ROLE_ADMIN)]
        async ([FromBody] UpdateUserDTO input, IUserService service) =>
        {
            var user = await service.Update(input);
            return user is null ? Results.Conflict() : Results.Ok(user);
        });

        group.MapDelete("/Delete/{id}", [Authorize(Roles = Constants.ROLE_ADMIN)]
        async (int id, IUserService service) =>
        {
            var user = await service.Delete(id);
            return user ? Results.NoContent() : Results.NotFound();
        });

        group.MapGet("/", [Authorize]
        async (IUserService service) =>
        {
            var users = await service.GetAll();
            return Results.Ok(users);
        });
    }

    public static void MapTodoEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/Todo").RequireAuthorization();

        group.MapPost("/",
        async ([FromBody] CreateTodoDTO input, ITodoService service) =>
        {
            var todo = await service.Create(input);
            return Results.Ok(todo);
        });

        group.MapPut("/Check/{id:int}",
        async (int id, ITodoService service) =>
        {
            var todo = await service.Check(id);
            return todo is null ? Results.NotFound() : Results.Ok(todo);
        });

        group.MapGet("/{id:int}",
        async (int id, ITodoService service) =>
        {
            var todo = await service.Get(id);
            return Results.Ok(todo);
        });

        group.MapGet("/",
        async (ITodoService service) =>
        {
            var todo = await service.Get();
            return Results.Ok(todo);
        });

        group.MapPut("/Update",
        async ([FromBody] UpdateTodoDTO input, ITodoService service) =>
        {
            var todo = await service.Update(input);
            return todo is null ? Results.Conflict() : Results.Ok(todo);
        });

        group.MapDelete("/Delete/{id}",
        async (int id, ITodoService service) =>
        {
            var todo = await service.Delete(id);
            return todo ? Results.NoContent() : Results.NotFound();
        });

    }
}
