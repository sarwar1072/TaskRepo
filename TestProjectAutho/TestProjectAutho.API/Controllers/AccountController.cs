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
    }
}
