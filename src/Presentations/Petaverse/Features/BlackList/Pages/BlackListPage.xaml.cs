using Petaverse.BlackListDetail;
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

    private void PetaverseContainer_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(BlackListDetailPage), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await viewModel.LoadDataAsync();
    }
}
