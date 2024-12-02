using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
    
    public List<ToDoTask> ToDos { get; set; }
}