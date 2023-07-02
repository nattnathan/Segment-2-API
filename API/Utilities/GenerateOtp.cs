namespace API.Utilities
{
    public class GenerateOtp
    {
        public static int GenerateRandomOTP()
        {
            var random = new Random();
            var otp = random.Next(100000, 999999);
            return otp;
        }
    }
}
