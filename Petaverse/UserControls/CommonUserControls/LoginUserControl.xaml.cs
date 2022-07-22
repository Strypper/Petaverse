using Petaverse.Refits;
using PetaVerse.Models.DTOs;
using Refit;
using System;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Petaverse.UserControls.CommonUserControls
{
    public sealed partial class LoginUserControl : UserControl
    {
        public delegate void LoginDelegate(UserPrincipal loginModel);
        public event LoginDelegate LoginEventHandler;

        private HttpClient httpClient = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
        })
        {
            BaseAddress = new Uri("https://localhost:5001/api")
        };

        private HttpClient authenticateClient = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
        })
        {
            BaseAddress = new Uri("http://localhost:4300/api")
        };

        private readonly IUserData userData;
        private readonly ISpeciesData speciestData;
        private readonly IAuthenticateServices authenticateServices;

        public LoginUserControl()
        {
            this.InitializeComponent();

            userData = RestService.For<IUserData>(httpClient);
            speciestData         = RestService.For<ISpeciesData>(httpClient);
            authenticateServices = RestService.For<IAuthenticateServices>(authenticateClient);
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(PhoneNumber.Text) && !String.IsNullOrEmpty(Password.Password))
            {
                var pricipalUserInfo = await authenticateServices.Authenticate(new LoginModel()
                {
                    PhoneNumber = PhoneNumber.Text,
                    Password = Password.Password
                });
                if (pricipalUserInfo != null)
                {
                    //LoginEventHandler.Invoke(pricipalUserInfo.userInfo);
                    await new ContentDialog()
                    {
                        Title = "Login success",
                        Content = $"Hello {pricipalUserInfo.userInfo.fullName}"
                    }.ShowAsync();
                }
                else await new ContentDialog()
                {
                    Title = "Invalid phone number or password",
                    Content = "Please check your information again or press the forgot button"
                }.ShowAsync();
            }

            else await new ContentDialog()
            {
                Title = "Please fill all the feilds",
                Content = "Please check your information again and fill all the feilds"
            }.ShowAsync();
        }
    }
}
