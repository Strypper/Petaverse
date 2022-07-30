using PetaVerse.Models.DTOs;
using System.Threading.Tasks;

namespace Petaverse.Interfaces
{
    public interface IAuthenticationService
    {
        Task<TotechsIdentityUser> Authenticate(LoginModel model);
    }
}
