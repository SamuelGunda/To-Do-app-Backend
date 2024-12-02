using Microsoft.EntityFrameworkCore;
using To_Do_app_Backend.Models.Domains;

namespace To_Do_app_Backend.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<ToDoTask> TodoTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Email = "alice@example.com", Password = "password" },
            new User { Id = 2, Email = "bob@example.com", Password = "password" }
        );

        // Seed ToDoTasks
        modelBuilder.Entity<ToDoTask>().HasData(
            new ToDoTask { Id = 1, Title = "Task 1", Description = "This is uncompleted task.", State = false, UserId = 1 },
            new ToDoTask { Id = 2, Title = "Task 2", Description = "This is completed task.", State = true, UserId = 2 }
        );
    }
}