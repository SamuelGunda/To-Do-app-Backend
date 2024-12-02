using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_Do_app_Backend.Models.Domains;

[Table("ToDoTasks")]
public class ToDoTask
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
    
    public ToDoTask()
    {
        State = false;
        CreatedAt = DateTime.Now;
    }
}