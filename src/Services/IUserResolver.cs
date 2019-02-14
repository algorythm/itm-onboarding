using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace todoProject.Services
{
    public interface IUserResolver
    {
        Task<IdentityUser> GetCurrentUserAsync();
        ClaimsPrincipal CurrentClaimsPrincipal { get; }
        string CurrentUserId { get; }
    }
}