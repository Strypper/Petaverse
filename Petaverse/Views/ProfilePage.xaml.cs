using Petaverse.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Petaverse.Views
{
    public sealed partial class ProfilePage : Page
    {
        public ProfilePageViewModel profilePageViewModel { get; set; }
        public ProfilePage()
        {
            this.InitializeComponent();
            profilePageViewModel = new ProfilePageViewModel();
        }

        private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            profilePageViewModel.CurrentUser = await profilePageViewModel.LoadFakeUserData();
        }
    }
}
