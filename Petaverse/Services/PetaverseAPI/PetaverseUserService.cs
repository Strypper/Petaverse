using Petaverse.ContentDialogs;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using Petaverse.Refits;
using Refit;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petaverse.Services.PetaverseAPI
{
    public class PetaverseUserService : IPetaverseUserService
    {
        private readonly IUserData _userData;
        public PetaverseUserService(HttpClient httpClient)
        {
            _userData = RestService.For<IUserData>(httpClient);
        }

        public async Task<User> LoginPetaverseByGuidAsync(string guid)
        {
            try
            {
                var petaverseUser = await _userData.GetByUserGuid(guid);
                return petaverseUser;
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
        }

        public async Task<string> RegisterPetaverseUserAsync(User petaverseUser)
        {
            try
            {
                return await _userData.RegisterUserAsync(petaverseUser);
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return string.Empty;
            }
        }
    }
}
