using Petaverse.ContentDialogs;
using Petaverse.ViewModels;
using Windows.UI.Xaml.Controls;
using System;

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

        private async void AddNewPet_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
              var addPetContentDialog = new AddPetContentDialog();
                  addPetContentDialog.PrimaryButtonClick += AddPetContentDialog_PrimaryButtonClick;
            await addPetContentDialog.ShowAsync();
        }

        private async void AddPetContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var petInfo = (sender as AddPetContentDialog).PetInfo;
            var createdPetInfo = await profilePageViewModel.CreatePetAsync(petInfo);
            if (createdPetInfo != null)
                profilePageViewModel.CurrentUser.Pets.Add(createdPetInfo);
        }
    }
}
