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

    #region [ Events Handler ]

    private void HomeSecondItemUserControl_SelectItem(Home_SecondSectionItemModel item)
    {
        Frame.Navigate(typeof(FosterCenterPage), item, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
    }
    #endregion

}
