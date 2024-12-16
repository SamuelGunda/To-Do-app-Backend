using To_Do_app_Backend.Models.Domains;
using To_Do_app_Backend.Models.Requests;

namespace To_Do_app_Backend.Services;

public interface IToDoService
{
    Task AddAsync(ToDoCreateRequest toDoCreateRequest, int userId);
    Task<ToDo?> GetByIdAsync(int id);
    Task UpdateAsync(ToDo toDo);
    Task DeleteAsync(int id);
    Task<List<ToDo>> GetAllByUserIdAsync(int userId);   
}