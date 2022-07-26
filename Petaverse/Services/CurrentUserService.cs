using Microsoft.Toolkit.Uwp.Helpers;
using Petaverse.Helpers;
using Petaverse.Interfaces;
using PetaVerse.Models.DTOs;
using System;
using System.Threading.Tasks;

namespace Petaverse.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private ApplicationDataStorageHelper _appDataStorageHelper;
        public CurrentUserService(ToolkitSerializer serializer)
        {
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
            throw new NotImplementedException();
        }

        public Task RemoveLocalUserAsync(string userGuid)
        {
            throw new NotImplementedException();
        }

        public async Task SaveLocalUserAsync(User currentUser)
        {
            _appDataStorageHelper.Save(currentUser.Guid, currentUser);
        }
    }
}
