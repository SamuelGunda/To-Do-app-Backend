using To_Do_app_Backend.Models.Domains;
using To_Do_app_Backend.Models.Requests;
using Task = System.Threading.Tasks.Task;

namespace To_Do_app_Backend.Repositories;

public interface IUserRepository
{
    Task AddAsync(AuthRequest user);
    Task<User?> GetByIdAsync(int id); 
    Task<User?> GetByEmailAsync(string email);
}