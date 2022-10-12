using Petaverse.Constants;
using Petaverse.ContentDialogs;
using Petaverse.Enums;
using Petaverse.Interfaces;
using Petaverse.Models.DTOs;
using Petaverse.Refits;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Petaverse.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthenticateServices authenticateServices;

        private readonly string unableToAuthenticate = "Unable to authenticate with Totechs Identity";
        private readonly string notFoundUser         = "Please check your phonenumber or password again";

        public AuthenticationService(Func<HttpClientEnum, HttpClient> httpClient)
        {
            //HttpClientEnum.TotechIdentityLocal: Localhost:4300 (required local server to start)

            _httpClient = httpClient(HttpClientEnum.TotechIdentity);
            authenticateServices = RestService.For<IAuthenticateServices>(_httpClient);
        }
        public async Task<TotechsIdentityUser> Authenticate(LoginModel model)
        {
            try
            {
               var pricipalUserInfo = await authenticateServices.Authenticate(model);
               return pricipalUserInfo;
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog()
                {
                    Title    = ex.StatusCode == System.Net.HttpStatusCode.InternalServerError
                                    ? unableToAuthenticate
                                    : notFoundUser,
                    Exception = ex
                }.ShowAsync();
                return null;
            }
            catch (Exception ex)
            {
                await new ServerNotFoundContentDialog()
                {
                    HttpClientInfo = _httpClient,
                    Action = "Trying to Authenticate the user based on the phone number",
                    DestinationTryingToReach = "/Access/LoginWithPhoneNumber",
                    ServiceImageUrl = "https://i.imgur.com/Ub65udB.png",
                    ProblemsCouldCauseList = new List<string>() { "Server is shutted down", "Wrong URL", "IDK Maybe ur mum is gei" },
                    SolutionsList = new List<string>() { "Start the server", "Contact to IT", "Go Fck urself !" }
                }
                .ShowAsync();
                return null;
            }
        }

        public async Task<UserPrincipal> RegisterAsync(RegisterModel model)
        {
            try
            {
                var pricipalUserInfo = await authenticateServices.RegisterAsync(model);
                return pricipalUserInfo;
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog()
                {
                    Title = "Can't create a profile for you right now",
                    Exception = ex
                }.ShowAsync();
                return null;
            }
            catch (Exception ex)
            {
                await new ServerNotFoundContentDialog()
                {
                    HttpClientInfo = _httpClient,
                    Action = "Trying to Register the user on Petaverse Service",
                    DestinationTryingToReach = "/Access/LoginWithPhoneNumber",
                    ServiceImageUrl = "https://i.imgur.com/EieEOMK.png",
                    ProblemsCouldCauseList = new List<string>() { "Server is shutted down", "Wrong URL", "IDK Maybe ur mum is gei" },
                    SolutionsList = new List<string>() { "Start the server", "Contact to IT", "Go Fck urself !" }
                }
                .ShowAsync();
                return null;
            }
        }
    }
}
