using Petaverse.Home;
using Petaverse.PersonalProfile;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.FosterCenter;

public sealed partial class FosterCenterPage : Page
{

    #region [ Fields ]

    private readonly FosterCenterPageViewModel viewModel;
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
            var item = container.Content as MemberProfilePreviewModel;
            ProfilePageParameter parameter = new()
            {
                ProfileId = item.Id,
                AvatarUrl = item.UserAvatarUrl,
                IsIncludePetInformation = true
            };

            Members.PrepareConnectedAnimation("ForwardConnectedAnimation", item, "AvatarPicture");
            Frame.Navigate(typeof(ProfilePage), parameter, new SuppressNavigationTransitionInfo());
        }

    }
}
