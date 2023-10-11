namespace Petaverse;

public sealed partial class AuthenticationPage : Page
{
    #region [ Fields ]

    private User currentUser;
    private readonly IAnimalService animalService;
    private readonly ICurrentUserService currentUserService;
    public ObservableCollection<NavigationViewItem> PetaverseNavigateViewItems { get; set; } = new ObservableCollection<NavigationViewItem>();
    #endregion

    #region [ CTors ]

    public AuthenticationPage()
    {
        this.InitializeComponent();
        animalService = Ioc.Default.GetRequiredService<IAnimalService>();
        currentUserService = Ioc.Default.GetRequiredService<ICurrentUserService>();
        PetaverseNavigateViewItems = PetaverseNavigationItemUtil.InitPetaverseNavigationItems();
    }
    #endregion

    #region [ Event Handlers ]

    private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        var currentUserGuid = currentUserService.GetLocalUserGuidFromAppSettings();
        if (!string.IsNullOrEmpty(currentUserGuid))
        {
            currentUser = await currentUserService.GetLocalUserAsync(currentUserGuid);
            this.ProccessLogin(currentUser);
        }
    }

    private void NavigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
    {
        var item = args.SelectedItem as NavigationViewItem;
        if (item != null)
            TheMainFrame.Navigate(item.DestinationPage);
    }

    private async void AddPet_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        var addPetContentDialog = new AddPetContentDialog();
        await addPetContentDialog.ShowAsync();
    }

    private void Profile_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        TheMainFrame.Navigate(typeof(ProfilePage));
        MainNavView.SelectedItem = null;
    }

    private void LoginUserControl_LoginSuccessEventHandler(User petaverseUser)
    {
        this.ProccessLogin(petaverseUser);
    }
    #endregion

    private void ProccessLogin(User petaverseUser)
    {
        if(petaverseUser != null)
        {
            MainNavView.SelectedItem = PetaverseNavigateViewItems.FirstOrDefault(item => item.Id == 2);
            if(!string.IsNullOrEmpty(petaverseUser.PetaverseProfileImageUrl) && !string.IsNullOrWhiteSpace(petaverseUser.PetaverseProfileImageUrl))
            {
                CurrentUserPersonPicture.ProfilePicture = new BitmapImage(new Uri(petaverseUser.PetaverseProfileImageUrl));
            }
            CurrentUserFullNameText.Text = petaverseUser.FullName;
            foreach (var item in PetaverseNavigateViewItems) { item.IsEnable = true; }
            NavigationViewPaneFooter.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        LoginControls.Visibility = Visibility.Collapsed;
    }

    //https://github.com/Strypper/Petaverse/issues/13
    private async void AddPetShort_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        if(currentUser is not null)
        {
            currentUser.Pets = await animalService.GetAllByUserGuidAsync(currentUserService.GetLocalUserGuidFromAppSettings());
            await new AddPetShortsContentDialog() { CurrentUser = currentUser }.ShowAsync();
        }
    }
}
