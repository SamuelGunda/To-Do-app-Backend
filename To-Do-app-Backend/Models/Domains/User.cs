using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using To_Do_app_Backend.Models.Dtos;

namespace To_Do_app_Backend.Models.Domains;

[Table("Users")]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    [StringLength(100, MinimumLength = 5)]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public List<ToDo> ToDos { get; set; }
    
    public UserDto ToDto()
    {
        return new UserDto
        {
            Id = Id,
            Email = Email
        };
    }
}