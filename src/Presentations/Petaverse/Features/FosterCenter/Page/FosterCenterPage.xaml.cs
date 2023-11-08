using Petaverse.Home;
using Petaverse.PersonalProfile;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.FosterCenter;

public sealed partial class FosterCenterPage : Page
{

    #region [ Fields ]

    private readonly FosterCenterPageViewModel viewModel;
    #endregion

    #region [ Properties ]

    MemberProfilePreviewModel animatedItem;
    #endregion

    #region [ CTor ]

    public FosterCenterPage()
    {
        this.InitializeComponent();

        viewModel = Ioc.Default.GetRequiredService<FosterCenterPageViewModel>();
    }
    #endregion

    #region [ Overrides ]

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        var item = e.Parameter as Home_SecondSectionItemModel;
        if (item is null)
            return;

        viewModel.FosterCenterLogo = item.FosterCenterLogo;
        viewModel.FosterCenterName = item.FosterCenterName;
        viewModel.IsFollowed = item.IsUserFollowing;

    }
    #endregion

    private void Members_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (Members.ContainerFromItem(e.ClickedItem) is GridViewItem container)
        {
            animatedItem = container.Content as MemberProfilePreviewModel;
            ProfilePageParameter parameter = new()
            {
                ProfileId = animatedItem.Id,
                AvatarUrl = animatedItem.UserAvatarUrl,
                IsIncludePetInformation = true
            };

            Members.PrepareConnectedAnimation("ForwardConnectedAnimation", animatedItem, "AvatarPicture");
            Frame.Navigate(typeof(ProfilePage), parameter, new SuppressNavigationTransitionInfo());
        }

    }

    private async void Members_Loaded(object sender, RoutedEventArgs e)
    {
        if (animatedItem != null)
        {
            // If the connected item appears outside the viewport, scroll it into view.
            Members.ScrollIntoView(animatedItem, ScrollIntoViewAlignment.Default);
            Members.UpdateLayout();

            // Play the second connected animation.
            ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
            if (animation != null)
            {
                // Setup the "back" configuration if the API is present.
                if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
                {
                    animation.Configuration = new DirectConnectedAnimationConfiguration();
                }

                await Members.TryStartConnectedAnimationAsync(animation, animatedItem, "AvatarPicture");
            }

            // Set focus on the list
            Members.Focus(FocusState.Programmatic);
        }

    }
}
