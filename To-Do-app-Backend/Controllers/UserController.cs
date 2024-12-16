using Microsoft.AspNetCore.Mvc;
using To_Do_app_Backend.Exceptions;
using To_Do_app_Backend.Models.Requests;
using To_Do_app_Backend.Services;

namespace To_Do_app_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost ("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequest authRequest)
    {
        var token = await userService.LoginAsync(authRequest);
        
        return Ok(new { token = $"{token}" });
    }
    
    [HttpPost ("register")]
    public async Task<IActionResult> CreateUser([FromBody] AuthRequest authRequest)
    {
        await userService.AddAsync(authRequest);
        
        return Created();
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await userService.GetByIdAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(user.ToDto());
    }
}