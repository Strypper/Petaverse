using CommunityToolkit.Mvvm.DependencyInjection;
using Petaverse.Interfaces;
using Petaverse.Refits;
using PetaVerse.Models.DTOs;
using Refit;
using System;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

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
            BaseAddress = new Uri("https://localhost:44371/api")
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
        private readonly ICurrentUserService currentUserService;
        private readonly IAuthenticateServices authenticateServices;

        public LoginUserControl()
        {
            this.InitializeComponent();

            userData             = RestService.For<IUserData>(httpClient);
            speciestData         = RestService.For<ISpeciesData>(httpClient);
            currentUserService   = Ioc.Default.GetRequiredService<ICurrentUserService>();
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
                LoginOrSignUpProgressBar.Visibility = Visibility.Visible;
                LoginOrSignUpIndeterminateBar.Visibility = Visibility.Visible;
                LoginOrSignUpProgressBar.Value = 30;

                if (pricipalUserInfo != null)
                {
                    App.localSettings.Values["UserGuid"] = pricipalUserInfo.UserInfo.Guid;

                    LoginOrSignUpProgressBar.Value += 20;

                    var petaverseUser = await userData.GetByUserGuid(pricipalUserInfo.UserInfo.Guid);

                    LoginOrSignUpProgressBar.Value += 30;

                    petaverseUser.FillPricipalUserInfo(pricipalUserInfo.UserInfo);

                    LoginOrSignUpProgressBar.Value += 10;

                    await currentUserService.SaveLocalUserAsync(petaverseUser);

                    LoginOrSignUpProgressBar.Value += 10;

                    LoginOrSignUpIndeterminateBar.Visibility = Visibility.Collapsed;
                }
                else
                {
                    LoginOrSignUpIndeterminateBar.ShowError = true;
                    await new ContentDialog()
                    {
                        Title = "Invalid phone number or password",
                        Content = "Please check your information again or press the forgot button"
                    }.ShowAsync();
                }
            }

            else await new ContentDialog()
            {
                Title = "Please fill all the feilds",
                Content = "Please check your information again and fill all the feilds"
            }.ShowAsync();
        }
    }

    public class BoolToSignInSignUpConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var visibility = (bool)value;
            return visibility == true ? "Sign Up" : "Sign In";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
