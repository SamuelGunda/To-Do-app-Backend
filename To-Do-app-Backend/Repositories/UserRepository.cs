using Microsoft.EntityFrameworkCore;
using To_Do_app_Backend.Database;
using To_Do_app_Backend.Exceptions;
using To_Do_app_Backend.Models.Domains;
using To_Do_app_Backend.Models.Entities;

namespace To_Do_app_Backend.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task AddAsync(AuthInfo user)
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
}