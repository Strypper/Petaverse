using Microsoft.Toolkit.Uwp.Helpers;
using Petaverse.Helpers;
using Petaverse.Interfaces;
using PetaVerse.Models.DTOs;
using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace Petaverse.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private ApplicationDataContainer     _localSettings;
        private ApplicationDataStorageHelper _appDataStorageHelper;
        public CurrentUserService(ToolkitSerializer serializer,
                                  ApplicationDataContainer appData)
        {
            _localSettings        = appData;
            _appDataStorageHelper = ApplicationDataStorageHelper.GetCurrent(serializer);
        }

        public Task<User> GetUserFromCloud()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetLocalUserAsync(string userGuid)
        {
            return _appDataStorageHelper.Read<User>(userGuid);
        }

        public void RemoveLocalUser(string userGuid)
        {
            _appDataStorageHelper.Clear();
        }

        public Task RemoveLocalUserAsync(string userGuid)
        {
            throw new NotImplementedException();
        }

        public async Task SaveLocalUserAsync(User currentUser)
        {
            _appDataStorageHelper.Save(currentUser.Guid, currentUser);
        }

        public string GetLocalUserGuidFromAppSettings()
            => _localSettings.Values["UserGuid"] != null 
                    ? _localSettings.Values["UserGuid"].ToString()
                    : String.Empty;

        public void WriteLocalUserGuidToAppSettings(string userGuild)
            => _localSettings.Values["UserGuid"] = userGuild;

        public void RemoveAllLocalData()
            => _localSettings.Values.Clear();
    }
}
