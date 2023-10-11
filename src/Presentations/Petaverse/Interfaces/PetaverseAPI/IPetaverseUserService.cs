using Petaverse.Models.DTOs;
using System.Threading.Tasks;

namespace Petaverse.Interfaces.PetaverseAPI
{
    public interface IPetaverseUserService
    {
        Task<User> LoginPetaverseByGuidAsync(string guid);
        Task<string> RegisterPetaverseUserAsync(User petaverseUser);
    }
}
