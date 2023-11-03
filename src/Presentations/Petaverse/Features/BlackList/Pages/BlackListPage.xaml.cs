using Microsoft.Toolkit.Uwp.UI.Animations;
using Petaverse.BlackListDetail;
using Petaverse.Home;
using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.BlackList;

public sealed partial class BlackListPage : Page
{

    #region [ Fields ]

    private readonly BlackListPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public BlackListPage()
    {
        this.InitializeComponent();
        viewModel = Ioc.Default.GetRequiredService<BlackListPageViewModel>();   
    }
    #endregion

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

    }

    #region [ Event Handlers ]

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {

    }

    private void BlackListItemUserControl_SelectItem(BlackListItemModel item)
    {
        Frame.SetListDataItemForNextConnectedAnimation(item);
        Frame.Navigate(typeof(BlackListDetailPage), item, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
    }

    #endregion

}
