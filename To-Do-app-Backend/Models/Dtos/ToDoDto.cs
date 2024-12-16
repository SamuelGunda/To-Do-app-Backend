namespace To_Do_app_Backend.Models.Dtos;

public class ToDoDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool State { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
}