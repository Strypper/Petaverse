﻿using PetaVerse.Models.DTOs;
using System.Threading.Tasks;

namespace Petaverse.Interfaces
{
    public interface ICurrentUserService
    {
        Task<User> GetUserFromCloud();
        Task<User> GetLocalUserAsync(string userGuid);
        Task SaveLocalUserAsync(User currentUser);
        Task RemoveLocalUserAsync(string userGuid);
        void RemoveLocalUser(string userGuid);
    }
}
