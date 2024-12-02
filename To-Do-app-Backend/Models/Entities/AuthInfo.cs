using System.ComponentModel.DataAnnotations;

namespace To_Do_app_Backend.Models.Entities;

public class AuthInfo
{
    [EmailAddress]
    public required string Email { get; set; }
    [StringLength(24, MinimumLength = 6)]
    public required string Password { get; set; }
}