using Microsoft.EntityFrameworkCore;
using To_Do_app_Backend.Database;
using To_Do_app_Backend.Models.Domains;

namespace To_Do_app_Backend.Repositories;

public class ToDoRepository(AppDbContext context) : IToDoRepository
{
    public async Task AddAsync(ToDo toDo)
    {
        context.ToDos.Add(toDo);
        await context.SaveChangesAsync();
    }
    
    public async Task<ToDo?> GetByIdAsync(int id)
    {
        return await context.ToDos.FindAsync(id);
    }
    
    public async Task UpdateAsync(ToDo toDo)
    {
        context.ToDos.Update(toDo);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(ToDo toDo)
    {
        context.ToDos.Remove(toDo);
        await context.SaveChangesAsync();
    }
    
    public async Task<List<ToDo>> GetAllByUserIdAsync(int userId)
    {
        return await context.ToDos.Where(t => t.UserId == userId).ToListAsync();
    }
}