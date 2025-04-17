using Membership.Entities;
using Membership.Seeds;
using Membership.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestProjectAuthoAPI.Models;

namespace TestProjectAuthoAPI.Controllers
{
    [EnableCors("AllowSites")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM registerVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }

            var userExists = await _userManager.FindByEmailAsync(registerVm.EmailAddress);
            if (userExists != null)
            {
                return BadRequest($"User {registerVm.EmailAddress} already exists!");
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVm.FullName,
                Email = registerVm.EmailAddress,
                //Password = registerVm.PassWord,
                UserName=registerVm.EmailAddress,
            };

            var result = await _userManager.CreateAsync(newUser, registerVm.PassWord);
            if (result.Succeeded)
            {
                //Add role
                switch (registerVm.Role)
                {
                    case IdenSD.Role_Admin:
                        await _userManager.AddToRoleAsync(newUser, IdenSD.Role_Admin);
                        break;

                    case IdenSD.Role_User:
                        await _userManager.AddToRoleAsync(newUser, IdenSD.Role_User);
                        break;

                    default:
                        break;
                }

                return Ok("User Created");
            };
            return BadRequest("Could not create the user");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please provide all required fields!");
            }

            var userExists = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (userExists != null && await _userManager.CheckPasswordAsync(userExists, loginVM.PassWord))
            {
                var tokenValue = await GenerateJWTTokenAsync(userExists);
                //return Ok(tokenValue);
                return Ok(new { token = tokenValue }); // ✅ Make sure it's wrapped like this

            }
            return Unauthorized();
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return NotFound();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return Ok(new { Token = token }); 
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return NotFound();

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            return result.Succeeded ? Ok("Password reset") : BadRequest(result.Errors);
        }
    
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            return result.Succeeded ? Ok("Password changed") : BadRequest(result.Errors);
        }

        //[Authorize(Roles = "Admin")]
        //[HttpGet("wish")]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public IActionResult Wish()
        //{
        //    return Ok("User Created");
        //}
        private async Task<AuthResultVM> GenerateJWTTokenAsync(ApplicationUser user)
        {
            var tokenObj = await _tokenService.GetJwtTokenAsync(user);

            var response = new AuthResultVM()
            {
                Token = tokenObj,
                ExpiresAt = DateTime.UtcNow.AddHours(5)
            };
            return response;
        }


    }
}
