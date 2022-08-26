using CommunityToolkit.Mvvm.DependencyInjection;
using Petaverse.Constants;
using Petaverse.Enums;
using Petaverse.Interfaces;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using Petaverse.Refits;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using static Bogus.DataSets.Name;
using static System.Net.WebRequestMethods;

namespace Petaverse.UserControls.CommonUserControls
{
    public sealed partial class LoginUserControl : UserControl
    {
        public delegate void LoginSuccessDelegate(User pricipalUserInfo);
        public event LoginSuccessDelegate LoginSuccessEventHandler;

        private readonly IUserData              userData;
        private readonly ICurrentUserService    currentUserService;
        private readonly IPetaverseUserService  petaverseUserService;
        private readonly IAuthenticationService authenticationService;

        public LoginUserControl()
        {
            this.InitializeComponent();
            //We call this control in xaml so we cannot use constructor injection
            var httpClient        = Ioc.Default.GetRequiredService<HttpClient>();

            userData              = RestService.For<IUserData>(httpClient);
            currentUserService    = Ioc.Default.GetRequiredService<ICurrentUserService>();
            petaverseUserService  = Ioc.Default.GetRequiredService<IPetaverseUserService>();
            authenticationService = Ioc.Default.GetRequiredService<IAuthenticationService>();
        }

        private async void LoginOrSignUp_Click(object sender, RoutedEventArgs e)
        {
            LoginOrSignUpProgressBar.Visibility      = Visibility.Visible;
            LoginOrSignUpIndeterminateBar.Visibility = Visibility.Visible;
            if (SignUpToggleSwitch.IsOn)
            {
                //This one null ?
                var registerTotechsUser = await authenticationService
                                                    .RegisterAsync(new RegisterModel()
                                                    {
                                                        UserName    = Email.Text,
                                                        Email       = Email.Text,
                                                        Password    = ConfirmPassword.Password,
                                                        FirstName   = FirstName.Text,
                                                        MiddleName  = MiddleName.Text,
                                                        LastName    = LastName.Text,
                                                        PhoneNumber = PhoneNumber.Text,
                                                        Gender      = GenderToggleSwitch.IsOn,
                                                        RoleGuid    = AppConstants.TotechsIdentityPetaverseRoleGuid
                                                    });
                LoginOrSignUpProgressBar.Value = 30;
                if (registerTotechsUser != null)
                {
                    //Register petaverse account
                    var petaverseUserGuid = await petaverseUserService.RegisterPetaverseUserAsync(new User()
                    {
                        Guid                     = registerTotechsUser.Guid,
                        PetaverseProfileImageUrl = "https://i.imgur.com/deS4147.png"
                    });

                    //Process Login
                    if (registerTotechsUser.Guid.Equals(petaverseUserGuid))
                    {
                        var petaverseUser = await ProcessLogin(registerTotechsUser);
                        LoginComplete(petaverseUser);
                    }
                }
                else
                {
                    LoginOrSignUpIndeterminateBar.ShowError = true;
                    LoginOrSignUpProgressBar.Value = 0;

                    LoginOrSignUpProgressBar.Visibility = Visibility.Collapsed;
                    LoginOrSignUpIndeterminateBar.Visibility = Visibility.Collapsed;
                }

            }
            else
            {
                if (!String.IsNullOrEmpty(PhoneNumber.Text) && !String.IsNullOrEmpty(Password.Password))
                {

                    var pricipalUserInfo = await authenticationService.Authenticate(new LoginModel()
                    {
                        PhoneNumber = PhoneNumber.Text,
                        Password = Password.Password
                    });
                    LoginOrSignUpProgressBar.Value = 30;

                    if (pricipalUserInfo != null)
                    {
                        var petaverseUser = await ProcessLogin(pricipalUserInfo.UserInfo);

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

        private async Task<User> ProcessLogin(UserPrincipal pricipalUserInfo)
        {
            var petaverseUser = await petaverseUserService.LoginPetaverseByGuidAsync(pricipalUserInfo.Guid);
            if (petaverseUser != null)
            {
                LoginOrSignUpProgressBar.Value += 50;

                petaverseUser.FillPricipalUserInfo(pricipalUserInfo);

                LoginOrSignUpProgressBar.Value += 10;

                await currentUserService.SaveLocalUserAsync(petaverseUser);

                currentUserService.WriteLocalUserGuidToAppSettings(pricipalUserInfo.Guid);

                LoginOrSignUpProgressBar.Value += 10;
                return petaverseUser;
            }
            else
            {
                LoginOrSignUpProgressBar.Value = 0;
                LoginOrSignUpIndeterminateBar.Visibility = Visibility.Collapsed;
                return null;
            };
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
