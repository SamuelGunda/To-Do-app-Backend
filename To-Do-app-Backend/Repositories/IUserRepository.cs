using To_Do_app_Backend.Models.Domains;
using To_Do_app_Backend.Models.Entities;

namespace To_Do_app_Backend.Repositories;

public interface IUserRepository
{
    Task AddAsync(AuthInfo user);
    Task<User?> GetByIdAsync(int id); 
}