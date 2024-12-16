using To_Do_app_Backend.Models.Domains;
using To_Do_app_Backend.Models.Requests;
using Task = System.Threading.Tasks.Task;

namespace To_Do_app_Backend.Services;

public interface IUserService
{
    Task<string> LoginAsync(AuthRequest authRequest);
    Task AddAsync(AuthRequest authRequest);
    Task<User?> GetByIdAsync(int id);
}