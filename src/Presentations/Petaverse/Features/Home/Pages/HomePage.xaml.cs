using Petaverse.FosterCenter;
using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.Home;

public sealed partial class HomePage : Page
{
    #region [ Fields ]

    private readonly HomePageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public HomePage()
    {
        this.InitializeComponent();

        viewModel = Ioc.Default.GetRequiredService<HomePageViewModel>();
    }
    #endregion

    #region [ Overrides ]

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs navigationEvent)
    {
        base.OnNavigatingFrom(navigationEvent);

        if (navigationEvent.NavigationMode == NavigationMode.Back)
        {
            // set the cache mode
            NavigationCacheMode = NavigationCacheMode.Disabled;

            ResetPageCache();
        }
    }
    #endregion

    #region [ Events Handler ]

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await viewModel.LoadDataAsync();
        viewModel.AutoUpdateFirstItemsIndex();
    }

    private void HomeSecondItemUserControl_SelectItem(Home_SecondSectionItemModel item)
    {
        Frame.Navigate(typeof(FosterCenterPage), item, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
    }
    private void HomeFirstItemUserControl_PointerWheelChanged(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        => e.Handled = true;
    #endregion

    #region [ Methods ]

    private void ResetPageCache()
    {
        int cacheSize = ((Frame)Parent).CacheSize;

        ((Frame)Parent).CacheSize = 0;
        ((Frame)Parent).CacheSize = cacheSize;
    }
    #endregion

}
