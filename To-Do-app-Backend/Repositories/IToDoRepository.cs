using To_Do_app_Backend.Models.Domains;

namespace To_Do_app_Backend.Repositories;

public interface IToDoRepository
{
    Task AddAsync(ToDo toDo);
    Task<ToDo?> GetByIdAsync(int id);
    Task UpdateAsync(ToDo toDo);
    Task DeleteAsync(ToDo toDo);
    Task<List<ToDo>> GetAllByUserIdAsync(int userId);
}