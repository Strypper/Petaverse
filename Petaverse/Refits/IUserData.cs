using PetaVerse.Models.DTOs;
using Refit;
using System.Threading.Tasks;

namespace Petaverse.Refits
{
    public interface IUserData
    {
        [Get("/User/GetByUserGuid/{guid}")]
        Task<User> GetByUserGuid(string guid);
    }
}
