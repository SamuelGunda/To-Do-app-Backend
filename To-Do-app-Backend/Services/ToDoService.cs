using To_Do_app_Backend.Database;
using To_Do_app_Backend.Exceptions;
using To_Do_app_Backend.Models.Domains;
using To_Do_app_Backend.Models.Requests;
using To_Do_app_Backend.Repositories;

namespace To_Do_app_Backend.Services;

public class ToDoService(IToDoRepository toDoRepository) : IToDoService
{
    public async Task AddAsync(ToDoCreateRequest toDoCreateRequest, int userId)
    {
        var toDoEntity = new ToDo
        {
            Title = toDoCreateRequest.Title,
            Description = toDoCreateRequest.Description,
            UserId = userId
        };
        
        await toDoRepository.AddAsync(toDoEntity);
    }
    
    public async Task<ToDo?> GetByIdAsync(int id)
    {
        var toDo = await toDoRepository.GetByIdAsync(id);

        return toDo;
    }
    
    public async Task UpdateAsync(ToDo toDo)
    {
        await toDoRepository.UpdateAsync(toDo);
    }
    
    public async Task DeleteAsync(int id)
    {
        var toDo = await toDoRepository.GetByIdAsync(id);
        if (toDo == null)
        {
            throw new EntityNotFoundException($"To-Do with id {id} was not found.");
        }
        
        await toDoRepository.DeleteAsync(toDo);
    }
    
    public async Task<List<ToDo>> GetAllByUserIdAsync(int userId)
    {
        return await toDoRepository.GetAllByUserIdAsync(userId);
    }
}