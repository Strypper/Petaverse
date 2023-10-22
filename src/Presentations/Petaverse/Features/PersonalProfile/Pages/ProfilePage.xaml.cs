using Petaverse.ViewModels;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.PersonalProfile;

public sealed partial class ProfilePage : Page
{
    public ProfilePageViewModel profilePageViewModel { get; set; }
    public ProfilePage()
    {
        this.InitializeComponent();
        profilePageViewModel = new ProfilePageViewModel();
    }

    private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        profilePageViewModel.CurrentUser = await profilePageViewModel.LoadUserDataAsync();
    }

    private void UserInfoPanelUserControl_LogoutEventHandler()
    {
        CoreApplication.Exit();
    }

    private async void PetGalleryPage_DeletePetClick(int petId)
        => await profilePageViewModel.DeletePetAsync(petId);




    private void PetGalleryPage_SelectPhoto(Models.DTOs.PetaverseMedia petaverseMedia)
    {
        profilePageViewModel.OverLayPopUpVisibility = true;
        var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
        if (anim != null)
        {
            anim.TryStart(PetMedia);
        }
        profilePageViewModel.PetaverseMedia = petaverseMedia;
    }

    private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        profilePageViewModel.OverLayPopUpVisibility = false;
    }
}