using Microsoft.AspNetCore.Mvc;
using To_Do_app_Backend.Exceptions;
using To_Do_app_Backend.Models.Entities;
using To_Do_app_Backend.Services;

namespace To_Do_app_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    
    [HttpPost ("register")]
    public async Task<IActionResult> CreateUser(AuthInfo user)
    {
        await userService.AddAsync(user);
        return Ok();
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await userService.GetByIdAsync(id);
        return Ok(user);
    }
}