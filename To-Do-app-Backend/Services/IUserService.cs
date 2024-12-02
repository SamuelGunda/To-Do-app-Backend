using To_Do_app_Backend.Models.Domains;
using To_Do_app_Backend.Models.Entities;

namespace To_Do_app_Backend.Services;

public interface IUserService
{
    Task AddAsync(AuthInfo user);
    Task<User?> GetByIdAsync(int id);
}