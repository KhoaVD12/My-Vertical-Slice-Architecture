using System.ComponentModel.DataAnnotations;

namespace Lab3_Presentation.Authentication.SignIn;

public class Payload
{
    [Required]
    public string Email { get; set; } =string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;   
}

