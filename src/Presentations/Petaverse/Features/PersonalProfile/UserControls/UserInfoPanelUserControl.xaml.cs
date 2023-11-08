using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.PersonalProfile;

public sealed partial class UserInfoPanelUserControl : UserControl
{
    public delegate void LogoutDelegate();
    public event LogoutDelegate LogoutEventHandler;

    public List<string> Tags { get; set; } = new List<string>() { "Dog Lover", "Cat Lover", "Pet Hero", "Explorer", "Petaverse Core Creator" };
    public UserModel CurrentUser
    {
        get { return (UserModel)GetValue(CurrentUserProperty); }
        set { SetValue(CurrentUserProperty, value); }
    }

    public static readonly DependencyProperty CurrentUserProperty =
        DependencyProperty.Register("CurrentUser", typeof(UserModel), typeof(UserInfoPanelUserControl), null);

    private readonly ICurrentUserService currentUserService;

    public UserInfoPanelUserControl()
    {
        this.InitializeComponent();
        currentUserService = Ioc.Default.GetRequiredService<ICurrentUserService>();
    }

    private void Logout_Click(object sender, RoutedEventArgs e)
    {
        currentUserService.RemoveAllLocalData();
        LogoutEventHandler.Invoke();
    }

    public void StartConnectedAnimation(ConnectedAnimation animation)
    {
        if (animation is not null)
            animation.TryStart(AvatarPicture);

    }

    public void StartBackConnectedAnimation()
        => ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("BackConnectedAnimation", AvatarPicture);
}
