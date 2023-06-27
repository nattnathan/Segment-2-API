using API.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs.Account
{
    public class NewAccountDto
    {
        [Required]
        public Guid Guid { get; set; }

        [PasswordPolicy]
        public string Password { get; set; }
        public int Otp { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsUsed { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
