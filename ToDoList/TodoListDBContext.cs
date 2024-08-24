using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList;

public class TodoListDBContext(DbContextOptions<TodoListDBContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(User.CreateAdmin());
    }
}