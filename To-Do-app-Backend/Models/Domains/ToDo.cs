using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using To_Do_app_Backend.Models.Dtos;

namespace To_Do_app_Backend.Models.Domains;

[Table("ToDoTasks")]
public class ToDo
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(32, MinimumLength = 3)]
    public string Title { get; set; }
    [StringLength(256)]
    public string Description { get; set; }
    public bool State { get; set; }
    public DateTime CreatedAt { get; set; }
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }
    
    public ToDo()
    {
        State = false;
        CreatedAt = DateTime.Now;
    }
    
    public ToDoDto ToDto()
    {
        return new ToDoDto
        {
            Id = Id,
            Title = Title,
            Description = Description,
            State = State,
            CreatedAt = CreatedAt,
            UserId = UserId
        };
    }
}