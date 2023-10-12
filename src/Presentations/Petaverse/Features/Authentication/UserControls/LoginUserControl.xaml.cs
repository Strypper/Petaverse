namespace Petaverse;

public sealed partial class LoginUserControl : UserControl
{
    public delegate void LoginSuccessDelegate(Models.DTOs.User pricipalUserInfo);
    public event LoginSuccessDelegate LoginSuccessEventHandler;

    private readonly IUserData              userData;
    private readonly ICurrentUserService    currentUserService;
    private readonly IPetaverseUserService  petaverseUserService;
    private readonly IAuthenticationService authenticationService;

    private IPublicClientApplication PublicClientApp;
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
            var registerResponse = await authenticationService
                                                .RegisterPetaverseUserAsync(new()
                                                {
                                                    UserName    = Email.Text,
                                                    Email       = Email.Text,
                                                    Password    = ConfirmPassword.Password,
                                                    FirstName   = FirstName.Text,
                                                    MiddleName  = MiddleName.Text,
                                                    LastName    = LastName.Text,
                                                    PhoneNumber = PhoneNumber.Text,
                                                    Gender      = GenderToggleSwitch.IsOn
                                                });
            LoginOrSignUpProgressBar.Value = 30;
            if (registerResponse.IsSuccess)
            {

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

                var result = await authenticationService.AuthenticateWithPhoneNumberAsync(new()
                {
                    PhoneNumber = PhoneNumber.Text,
                    Password = Password.Password
                });
                LoginOrSignUpProgressBar.Value = 30;

                if (result.IsSuccess)
                {
                    LoginComplete(new()
                    {
                        Guid = result.Id,
                        UserName = result.UserName,
                        FirstName = result.FirstName,
                        MiddleName = result.MiddleName,
                        LastName = result.LastName,
                        Email = result.Email,
                        PhoneNumber = result.PhoneNumber,
                        ProfilePicUrl = result.AvatarUrl
                    });
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

    private async Task<Models.DTOs.User> ProcessLogin(UserPrincipal pricipalUserInfo)
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

    private void LoginComplete(Models.DTOs.User pricipalUserInfo)
    {
        if(pricipalUserInfo != null)
        {
            LoginOrSignUpProgressBar.Visibility = Visibility.Collapsed;
            LoginOrSignUpIndeterminateBar.Visibility = Visibility.Collapsed;
            Password.Password = String.Empty;

            LoginSuccessEventHandler.Invoke(pricipalUserInfo);
        }
    }

    private async void LoginWithMicrosoft_Click(object sender, RoutedEventArgs e)
    {

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
