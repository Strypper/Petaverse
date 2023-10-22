using Microsoft.UI.Xaml.Controls;
using Petaverse.Home;
using Petaverse.PersonalProfile;
using Windows.UI.Core;

namespace Petaverse.ApplicationStructure;

public sealed partial class TheMainFrame : Page
{
    #region [ CTor ]

    public TheMainFrame()
    {
        this.InitializeComponent();

        PetaverseNavigateViewItems = PetaverseNavigationItemUtil.InitPetaverseNavigationItems();
        PetaverseNavigateViewFooterItems = PetaverseNavigationItemUtil.InitPetaverseFooterNavigationItems();

        if (Environment.OSVersion.Version.Build >= 22000)
        {
            SetValue(BackdropMaterial.ApplyToRootOrPageBackgroundProperty, true);
        }

        Window.Current.SetTitleBar(TitleBarGrid);

        Window.Current.Activated += (s, e) =>
        {
            TitleBarGrid.Opacity = e.WindowActivationState != CoreWindowActivationState.Deactivated ? 1 : 0.5;
        };
    }
    #endregion

    #region [ Properties ]

    public ObservableCollection<NavigationViewItem> PetaverseNavigateViewItems { get; set; }
    public ObservableCollection<NavigationViewItem> PetaverseNavigateViewFooterItems { get; set; }


    #endregion

    #region [ Event Handlers ]

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        ContentFrame.Navigate(typeof(HomePage));
    }

    private void NavigationViewControl_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
    {

        var item = args.SelectedItem as NavigationViewItem;
        if (item != null)
            ContentFrame.Navigate(item.DestinationPage);
    }

    private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
    {
        if (ContentFrame.CanGoBack)
            BackButton.Visibility = Visibility.Visible;
        else
            BackButton.Visibility = Visibility.Collapsed;

        var navigatedPage = e.Content as Page;
        UpdateNavigationViewSelection(navigatedPage);
    }

    private void UpdateNavigationViewSelection(Page page)
    {
        var selectedItem = PetaverseNavigateViewItems.FirstOrDefault(x => x.DestinationPage == page.GetType());
        if (selectedItem is not null)
        {
            NavigationViewControl.SelectedItem = selectedItem;
        }
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (ContentFrame.CanGoBack)
        {
            ContentFrame.GoBack();
        }
    }

    private void ProfileMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
    {
        ContentFrame.Navigate(typeof(ProfilePage));
    }
    #endregion

}
