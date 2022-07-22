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
    }
}
