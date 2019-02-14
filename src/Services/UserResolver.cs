using System.Security.Claims;
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
            if (CurrentClaimsPrincipal == null) return null;
            if (CurrentClaimsPrincipal.Identity.Name == null) return null;
            if (CurrentClaimsPrincipal.Identity.IsAuthenticated == false) return null; 

            var email = CurrentClaimsPrincipal.Identity.Name;

            return await _userManager.FindByEmailAsync(email);
        }

        public ClaimsPrincipal CurrentClaimsPrincipal
        {
            get
            {
                return _context.HttpContext.User;
            }
        }

        public string CurrentUserId
        {
            get
            {
                return CurrentClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }
    }
}