using Petaverse.Models.DTOs;
using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petaverse.Refits
{
    public interface IUserData
    {
        [Get("/User/GetByUserGuid/{guid}")]
        Task<User> GetByUserGuid(string guid);

        [Post("/User/Register/")]
        Task<string> RegisterUserAsync(User petaverseUser);
    }
}
