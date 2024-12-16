using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using To_Do_app_Backend.Models.Dtos;
using To_Do_app_Backend.Models.Requests;
using To_Do_app_Backend.Services;

namespace To_Do_app_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController(IToDoService toDoService) : ControllerBase
{
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetTasks()
    {
        try
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value ?? throw new Exception());
            
            var toDos = await toDoService.GetAllByUserIdAsync(userId);
            
            var toDoDtos = toDos.Select(toDo => toDo.ToDto()).ToList();
            return Ok(toDoDtos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateTask(ToDoCreateRequest toDoCreateRequest)
    {
        var userId = int.Parse(User.FindFirst("Id")?.Value ?? throw new Exception());
        
        await toDoService.AddAsync(toDoCreateRequest, userId);
        return Created();
    }
    
    /*[HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateTask(ToDoDto toDoDto)
    {
        await toDoService.UpdateAsync(toDoDto);
        return NoContent();
    }*/
    
    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await toDoService.DeleteAsync(id);
        return NoContent();
    }
}