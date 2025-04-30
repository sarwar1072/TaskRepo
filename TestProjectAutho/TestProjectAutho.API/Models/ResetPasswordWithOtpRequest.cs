namespace TestProjectAuthoAPI.Models
{
    public class ResetPasswordWithOtpRequest
    {
        public string? Email { get; set; }
        public string? Otp { get; set; }
        public string? NewPassword { get; set; }
    }
}
