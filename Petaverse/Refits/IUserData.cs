using PetaVerse.Models.DTOs;
using Refit;
using System.Threading.Tasks;

namespace Petaverse.Refits
{
    public interface IUserData
    {
        [Get("/User/UseByGuid")]
        Task<User> GetPetaverseUser(string guid);
    }
}
