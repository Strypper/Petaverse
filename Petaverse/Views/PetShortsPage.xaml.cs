using Petaverse.Models.DTOs;
using Petaverse.ViewModels;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Petaverse.Views
{
    public sealed partial class PetShortsPage : Page
    {
        public PetShortsPageViewModel petShortPageViewModel { get; set; } = new PetShortsPageViewModel();
        public PetShortsPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await petShortPageViewModel.InitFirstVideo();
        }

        private void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (var petShort in petShortPageViewModel.PetShorts)
            //{
            //    petShort.MediaUrl = petShort.Media.MediaUrl;
            //}
            //if (petShortPageViewModel.PetShorts.Count > 0 && petShortPageViewModel.CurrentPetShort != null)
            //{
            //    var petShort = petShortPageViewModel.PetShorts.FirstOrDefault(petShort => petShort.Id == petShortPageViewModel.CurrentPetShort.Id);
            //    petShort.MediaUrl = "https://intranetblobstorages.blob.core.windows.net/backgroundvideo/BravoShortVideo.mp4";
            //}
            var flipView = (FlipView)sender;
            var selectedView = flipView.SelectedItem as PetShort;
            if (selectedView != null && petShortPageViewModel.CurrentPetShort != null)
            {
                if (string.IsNullOrEmpty(selectedView.MediaUrl) && petShortPageViewModel.CurrentPetShort.Media != null)
                {
                    selectedView.MediaUrl = petShortPageViewModel.CurrentPetShort.Media.MediaUrl;
                }
                foreach (var petShort in petShortPageViewModel.PetShorts.Where(ps => ps.Id != selectedView.Id))
                {
                    petShort.MediaUrl = string.Empty;
                }
            }
        }
    }

    public class FlipViewItemDTO
    {
        public PetShort PetShort { get; set; }
    }
}
