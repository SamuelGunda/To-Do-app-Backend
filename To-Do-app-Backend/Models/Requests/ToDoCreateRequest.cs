using System.ComponentModel.DataAnnotations;

namespace To_Do_app_Backend.Models.Requests;

public class ToDoCreateRequest
{
    [StringLength(100, MinimumLength = 1)]
    public required string Title { get; set; }
    [StringLength(1000, MinimumLength = 1)]
    public required string Description { get; set; }
}