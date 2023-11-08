using Petaverse.ViewModels;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.PersonalProfile;

public sealed partial class ProfilePage : Page
{
    #region [ Fields ]

    private readonly ProfilePageViewModel viewModel;
    #endregion

    #region [ CTors ]

    public ProfilePage()
    {
        this.InitializeComponent();
        viewModel = Ioc.Default.GetRequiredService<ProfilePageViewModel>();
    }
    #endregion

    #region [ Override ]

    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        var item = e.Parameter as ProfilePageParameter;
        if (item is null)
            return;
        await viewModel.LoadDataAsync(item);

        var imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
        if (imageAnimation is not null)
        {
            UserInfoPanel.StartConnectedAnimation(imageAnimation);

            //Remove this when out of PoC
            viewModel.UserInfo.ProfilePicUrl = item.AvatarUrl;
        }
    }
    #endregion

    #region [ Event Handlers ]

    private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {

    }

    private void UserInfoPanelUserControl_LogoutEventHandler()
    {
        CoreApplication.Exit();
    }


    private void PetGalleryPage_SelectPhoto(Models.DTOs.PetaverseMedia petaverseMedia)
    {
        viewModel.OverLayPopUpVisibility = true;
        var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
        if (anim != null)
        {
            anim.TryStart(PetMedia);
        }
        viewModel.PetaverseMedia = petaverseMedia;
    }

    private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        viewModel.OverLayPopUpVisibility = false;
    }

    private async void PetGalleryPage_DeletePetClick(string petId)
        => await viewModel.DeletePetAsync(petId);
    #endregion

}