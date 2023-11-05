using Petaverse.Home;

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

}
