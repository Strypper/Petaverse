using Petaverse.Constants;
using Petaverse.ContentDialogs;
using Petaverse.Enums;
using Petaverse.Interfaces;
using Petaverse.Models.DTOs;
using Petaverse.Refits;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petaverse.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticateServices authenticateServices;

        private readonly string unableToAuthenticate = "Unable to authenticate with Totechs Identity";
        private readonly string notFoundUser         = "Please check your phonenumber or password again";

        public AuthenticationService(Func<HttpClientEnum, HttpClient> httpClient)
        {
            //HttpClientEnum.TotechIdentityLocal: Localhost:4300 (required local server to start)

            var _httpClient = httpClient(HttpClientEnum.TotechIdentityLocal);
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
        }
    }
}
