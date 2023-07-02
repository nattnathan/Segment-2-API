using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Account;

public class ForgotPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public int Otp { get; set; }

    [Required]
    public DateTime ExpireTime { get; set; }
}
