using Membership.Entities;
using System.Security.Claims;

namespace Membership.Services
{
 public interface ITokenService
    {
        Task<string> GetJwtTokenAsync(ApplicationUser user);
    }
}
