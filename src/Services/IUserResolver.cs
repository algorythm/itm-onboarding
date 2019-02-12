using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace todoProject.Services
{
    public interface IUserResolver
    {
        Task<IdentityUser> GetCurrentUser();
    }
}