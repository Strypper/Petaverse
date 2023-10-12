using Petaverse.Models.DTOs;
using System.Threading.Tasks;

namespace Petaverse.Interfaces
{
    public interface ICurrentUserService
    {
        Task<Models.DTOs.User> GetUserFromCloud(string userGuid);
        Task<Models.DTOs.User> GetLocalUserAsync(string userGuid);
        string GetLocalUserGuidFromAppSettings();
        void WriteLocalUserGuidToAppSettings(string userGuild);
        Task SaveLocalUserAsync(Models.DTOs.User currentUser);
        Task RemoveLocalUserAsync(string userGuid);
        void RemoveLocalUser(string userGuid);
        void RemoveAllLocalData();
    }
}
