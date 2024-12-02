using To_Do_app_Backend.Exceptions;
using To_Do_app_Backend.Models.Domains;
using To_Do_app_Backend.Models.Entities;
using To_Do_app_Backend.Repositories;

namespace To_Do_app_Backend.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public Task AddAsync(AuthInfo user)
    {
        return userRepository.AddAsync(user);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await userRepository.GetByIdAsync(id);
        
        if (user == null)
        {
            throw new EntityNotFoundException($"User with id {id} was not found");
        }
        
        return user;
    }
}