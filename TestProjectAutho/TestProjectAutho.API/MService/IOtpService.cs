namespace TestProjectAuthoAPI.MService
{
    public interface IOtpService
    {
        void SaveOtp(string email, string otp);
        string GetOtp(string email);
        void RemoveOtp(string email);
    }
}
