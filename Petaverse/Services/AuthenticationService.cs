using Petaverse.ContentDialogs;
using Petaverse.Interfaces;
using Petaverse.Refits;
using PetaVerse.Models.DTOs;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petaverse.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private HttpClient authenticateClient = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
        })
        {
            BaseAddress = new Uri("http://localhost:4300/api")
        };

        private readonly IAuthenticateServices authenticateServices;

        private readonly string unableToAuthenticate = "Unable to authenticate with Totechs Identity";
        private readonly string notFoundUser         = "Please check your phonenumber or password again";

        public AuthenticationService()
        {
            authenticateServices = RestService.For<IAuthenticateServices>(authenticateClient);
        }
        public async Task<TotechsIdentityUser> Authenticate(LoginModel model)
        {
            try
            {
               var pricipalUserInfo = await authenticateServices.Authenticate(new LoginModel()
                {
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password
                });
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
    }
}
