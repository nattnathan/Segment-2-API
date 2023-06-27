using API.Utilities;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Account
{
    public class GetAccountDto
    {
        [Required]
        public Guid Guid { get; set; }

        [PasswordPolicy]
        public string Password { get; set; }
        public int? Otp { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsUsed { get; set; }
        public DateTime? ExpiredTime { get; set; }
    }
}
