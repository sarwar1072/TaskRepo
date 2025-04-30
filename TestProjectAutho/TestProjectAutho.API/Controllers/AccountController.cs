using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestProjectAuthoAPI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> Forotpass()
        //{
        //    var resetToken = Guid.NewGuid().ToString(); // or use RandomString(30)

        //    var tokenEntry = new PasswordResetToken
        //    {
        //        Email = user.Email,
        //        Token = resetToken,
        //        ExpiryDate = DateTime.UtcNow.AddMinutes(15) // expires after 15 mins
        //    };

        //    await _dbContext.PasswordResetTokens.AddAsync(tokenEntry);
        //    await _dbContext.SaveChangesAsync();

        //    // Send email
        //    var resetLink = $"https://yourfrontend.com/reset-password?token={resetToken}&email={user.Email}";
        //    await _emailService.SendEmailAsync(user.Email, "Reset Password", $"Click <a href='{resetLink}'>here</a> to reset your password.");

        //}

        //public async Task<IActionResult> ResetPass()
        //{
        //    var tokenEntry = await _dbContext.PasswordResetTokens
        //            .FirstOrDefaultAsync(t => t.Token == model.Token && t.Email == model.Email);

        //    if (tokenEntry == null || tokenEntry.ExpiryDate < DateTime.UtcNow)
        //        return BadRequest("Invalid or expired token.");

        //    // find user and reset password
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    var resetResult = await _userManager.ResetPasswordAsync(user, await _userManager.GeneratePasswordResetTokenAsync(user), model.NewPassword);

        //    if (!resetResult.Succeeded)
        //    {
        //        var errors = resetResult.Errors.Select(e => e.Description);
        //        return BadRequest(new { Errors = errors });
        //    }

        //    // Token used, delete it
        //    _dbContext.PasswordResetTokens.Remove(tokenEntry);
        //    await _dbContext.SaveChangesAsync();

        //    return Ok("Password has been reset successfully.");

        //}
        //public class ForgotPasswordRequest
        //{
        //    public string Email { get; set; }
        //}

        //public class ResetPasswordWithOtpRequest
        //{
        //    public string Email { get; set; }
        //    public string Otp { get; set; }
        //    public string NewPassword { get; set; }
        //}
        //public interface IOtpService
        //{
        //    void SaveOtp(string email, string otp);
        //    string GetOtp(string email);
        //    void RemoveOtp(string email);
        //}

        //public class OtpService : IOtpService
        //{
        //    private readonly Dictionary<string, (string Otp, DateTime Expiry)> _otpStore = new();

        //    public void SaveOtp(string email, string otp)
        //    {
        //        _otpStore[email] = (otp, DateTime.UtcNow.AddMinutes(5)); // expires in 5 min
        //    }

        //    public string GetOtp(string email)
        //    {
        //        if (_otpStore.ContainsKey(email))
        //        {
        //            var (otp, expiry) = _otpStore[email];
        //            if (DateTime.UtcNow <= expiry)
        //                return otp;
        //        }
        //        return null;
        //    }

        //    public void RemoveOtp(string email)
        //    {
        //        _otpStore.Remove(email);
        //    }
        //}

           // [HttpPost("forgot-password")]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //        return BadRequest("User not found");

        //    var otp = new Random().Next(100000, 999999).ToString();
        //    _otpService.SaveOtp(model.Email, otp);

        //    var emailBody = $"<p>Your OTP for password reset is: <strong>{otp}</strong></p>";
        //    await _emailService.SendEmailAsync(model.Email, "Password Reset OTP", emailBody);

        //    return Ok("OTP sent to your email.");
        //}

        //[HttpPost("reset-password")]
        //public async Task<IActionResult> ResetPasswordWithOtp(ResetPasswordWithOtpRequest model)
    //    {
    //        var user = await _userManager.FindByEmailAsync(model.Email);
    //        if (user == null)
    //            return BadRequest("User not found");

    //        var savedOtp = _otpService.GetOtp(model.Email);
    //        if (savedOtp == null || savedOtp != model.Otp)
    //            return BadRequest("Invalid or expired OTP");

    //        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    //        var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

    //        if (!result.Succeeded)
    //            return BadRequest(result.Errors);

    //        _otpService.RemoveOtp(model.Email); // clean up
    //        return Ok("Password reset successful.");
    //    }

    }
}
