using Petaverse.Models.DTOs;
using System.Threading.Tasks;

namespace Petaverse.Interfaces.PetaverseAPI
{
    public interface IPetaverseUserService
    {
        Task<Models.DTOs.User> LoginPetaverseByGuidAsync(string guid);
        Task<string> RegisterPetaverseUserAsync(Models.DTOs.User petaverseUser);
    }
}
