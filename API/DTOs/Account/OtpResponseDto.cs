namespace API.DTOs.Account
{
    public class OtpResponseDto
    {
        public string Email { get; set; }
        public Guid Guid { get; set; }
        public int Otp { get; set; }
    }
}
