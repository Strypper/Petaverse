using Petaverse.BlackListDetail;
using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.BlackList;

public sealed partial class BlackListPage : Page
{

    #region [ CTor ]

    public BlackListPage()
    {
        this.InitializeComponent();
    }
    #endregion

    private void PetaverseContainer_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        Frame.Navigate(typeof(BlackListDetailPage), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
    }
}
