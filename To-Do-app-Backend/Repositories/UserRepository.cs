using Microsoft.EntityFrameworkCore;
using To_Do_app_Backend.Database;
using To_Do_app_Backend.Exceptions;
using To_Do_app_Backend.Models.Domains;
using To_Do_app_Backend.Models.Requests;
using Task = System.Threading.Tasks.Task;

namespace To_Do_app_Backend.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task AddAsync(AuthRequest user)
    {
        var newUser = new User
        {
            Email = user.Email,
            Password = user.Password
        };
        
        context.Users.Add(newUser);
        
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new EntityAlreadyExistsException("User with this email already exists");
        }
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}