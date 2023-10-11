using Petaverse.ContentDialogs;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using Petaverse.Refits;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petaverse.Services.PetaverseAPI
{
    public class PetaverseUserService : IPetaverseUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IUserData  _userData;
        public PetaverseUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
            catch (Exception e)
            {
                await new ServerNotFoundContentDialog()
                {
                    HttpClientInfo = _httpClient,
                    Action = "Trying to get user's Petaverse info based on Guid",
                    DestinationTryingToReach = "/Animal/GetAllByUserGuid/{userGuid}",
                    ServiceImageUrl = "https://i.imgur.com/EieEOMK.png",
                    ProblemsCouldCauseList = new List<string>() { "Petaverse server is shutted down", "Wrong URL", "IDK Maybe ur mum is gei" },
                    SolutionsList = new List<string>() { "Start the PetaverseAPI", "Contact to IT", "Go Fck urself !" }
                }
                .ShowAsync();
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
            catch (Exception e)
            {
                await new ServerNotFoundContentDialog()
                {
                    HttpClientInfo = _httpClient,
                    Action = "Trying to get user based on their Guid",
                    DestinationTryingToReach = "/Animal/GetAllByUserGuid/{userGuid}",
                    ServiceImageUrl = "https://i.imgur.com/EieEOMK.png",
                    ProblemsCouldCauseList = new List<string>() { "Petaverse server is shutted down", "Wrong URL", "IDK Maybe ur mum is gei" },
                    SolutionsList = new List<string>() { "Start the PetaverseAPI", "Contact to IT", "Go Fck urself !" }
                }
                .ShowAsync();
                return null;
            }
        }
    }
}
