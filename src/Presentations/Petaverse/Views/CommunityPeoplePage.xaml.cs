using Petaverse.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Petaverse.Views
{
    public sealed partial class CommunityPeoplePage : Page
    {
        public CommunityPeoplePageViewModel vm { get; set; } = new CommunityPeoplePageViewModel();
        public CommunityPeoplePage()
        {
            this.InitializeComponent();
            vm.InitFakeData();
        }
    }
}
