namespace TestProjectAuthoAPI.MService
{
    public class OtpService:IOtpService
    {
        private readonly Dictionary<string, (string Otp, DateTime Expiry)> _otpStore = new();

        public void SaveOtp(string email, string otp)
        {
            _otpStore[email] = (otp, DateTime.UtcNow.AddMinutes(5)); // expires in 5 min
        }

        public string GetOtp(string email)
        {
            if (_otpStore.ContainsKey(email))
            {
                var (otp, expiry) = _otpStore[email];
                if (DateTime.UtcNow <= expiry)
                    return otp;
            }
            return null;
        }

        public void RemoveOtp(string email)
        {
            _otpStore.Remove(email);
        }
    }
}
