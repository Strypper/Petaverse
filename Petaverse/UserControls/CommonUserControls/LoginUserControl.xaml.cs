using CommunityToolkit.Mvvm.DependencyInjection;
using Petaverse.Enums;
using Petaverse.Interfaces;
using Petaverse.Models.DTOs;
using Petaverse.Refits;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Petaverse.UserControls.CommonUserControls
{
    public sealed partial class LoginUserControl : UserControl
    {
        public delegate void LoginSuccessDelegate(User pricipalUserInfo);
        public event LoginSuccessDelegate LoginSuccessEventHandler;

        private readonly IUserData userData;
        private readonly ICurrentUserService currentUserService;
        private readonly IAuthenticationService authenticateServices;

        public LoginUserControl()
        {
            this.InitializeComponent();

            var httpClient       = Ioc.Default.GetRequiredService<HttpClient>();
            userData             = RestService.For<IUserData>(httpClient);
            currentUserService   = Ioc.Default.GetRequiredService<ICurrentUserService>();
            authenticateServices = Ioc.Default.GetRequiredService<IAuthenticationService>();
        }

        private async void LoginOrSignUp_Click(object sender, RoutedEventArgs e)
        {
            LoginOrSignUpProgressBar.Visibility = Visibility.Visible;
            LoginOrSignUpIndeterminateBar.Visibility = Visibility.Visible;
            if (SignUpToggleSwitch.IsOn)
            {

            }
            else
            {
                if (!String.IsNullOrEmpty(PhoneNumber.Text) && !String.IsNullOrEmpty(Password.Password))
                {

                    var pricipalUserInfo = await authenticateServices.Authenticate(new LoginModel()
                    {
                        PhoneNumber = PhoneNumber.Text,
                        Password = Password.Password
                    });
                    LoginOrSignUpProgressBar.Value = 30;

                    if (pricipalUserInfo != null)
                    {
                        var petaverseUser = await ProcessLogin(pricipalUserInfo);

                        LoginComplete(petaverseUser);
                    }
                    else
                    {
                        LoginOrSignUpIndeterminateBar.ShowError = true;
                        LoginOrSignUpProgressBar.Value = 0;

                        LoginOrSignUpProgressBar.Visibility = Visibility.Collapsed;
                        LoginOrSignUpIndeterminateBar.Visibility = Visibility.Collapsed;
                    }
                }
                else await new ContentDialog()
                {
                    Title = "Please fill all the feilds",
                    Content = "Please check your information again and fill all the feilds"
                }.ShowAsync();
            }
        }

        private async Task<User> ProcessLogin(TotechsIdentityUser pricipalUserInfo)
        {
            currentUserService.WriteLocalUserGuidToAppSettings(pricipalUserInfo.UserInfo.Guid);

            LoginOrSignUpProgressBar.Value += 20;

            var petaverseUser = await userData.GetByUserGuid(pricipalUserInfo.UserInfo.Guid);

            LoginOrSignUpProgressBar.Value += 30;

            petaverseUser.FillPricipalUserInfo(pricipalUserInfo.UserInfo);

            LoginOrSignUpProgressBar.Value += 10;

            await currentUserService.SaveLocalUserAsync(petaverseUser);

            LoginOrSignUpProgressBar.Value += 10;
            return petaverseUser;
        }

        private void LoginComplete(User pricipalUserInfo)
        {
            if(pricipalUserInfo != null)
            {
                LoginOrSignUpProgressBar.Visibility = Visibility.Collapsed;
                LoginOrSignUpIndeterminateBar.Visibility = Visibility.Collapsed;
                Password.Password = String.Empty;

                LoginSuccessEventHandler.Invoke(pricipalUserInfo);
            }
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
