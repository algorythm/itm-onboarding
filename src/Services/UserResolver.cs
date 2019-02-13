using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace todoProject.Services
{
    public class UserResolver : IUserResolver
    {
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserResolver(IHttpContextAccessor context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityUser> GetCurrentUserAsync()
        {
            var claimsPrincipal = _context.HttpContext.User;
            if (claimsPrincipal == null) return null;
            if (claimsPrincipal.Identity.Name == null) return null;
            if (claimsPrincipal.Identity.IsAuthenticated == false) return null; 

            var email = claimsPrincipal.Identity.Name;

            return await _userManager.FindByEmailAsync(email);
        }
    }
}