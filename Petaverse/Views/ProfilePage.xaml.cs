using Petaverse.ContentDialogs;
using Petaverse.ViewModels;
using Windows.UI.Xaml.Controls;
using System;
using Windows.ApplicationModel.Core;
using PetaVerse.Models.DTOs;

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
            profilePageViewModel.CurrentUser = await profilePageViewModel.LoadUserDataAsync();
        }

        private async void AddNewPet_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var addPetContentDialog = new AddPetContentDialog();
            addPetContentDialog.PrimaryButtonClick += AddPetContentDialog_PrimaryButtonClick;
            await addPetContentDialog.ShowAsync();
        }

        private void AddPetContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var petInfo = (sender as AddPetContentDialog).PetInfo;
            //var createdPetInfo = await profilePageViewModel.CreatePetAsync(petInfo);
            //if (createdPetInfo != null)
            //    profilePageViewModel.CurrentUser.Pets.Add(createdPetInfo);
            var sampleData = new Animal()
            {
                Id = 11,
                Name = petInfo.Name,
                Bio = petInfo.Bio,
                //PetAvatar = "https://intranetblobstorages.blob.core.windows.net/petaverse/Yumi.jpg"
                //Breed = profilePageViewModel.
            };
            profilePageViewModel.CurrentUser.Pets.Add(sampleData);
        }

        private void UserInfoPanelUserControl_LogoutEventHandler()
        {
            CoreApplication.Exit();
        }
    }
}
//{
//    "id": 0,
//  "name": "Yumi",
//  "bio": "Abandoned from his mother, Yumi was a brave cat and often stick with the people who help her. A very active and lovely cat",
//  "petAvatar": "https://intranetblobstorages.blob.core.windows.net/petaverse/Yumi.jpg",
//  "petColor": "#43423d, #8c816f",
//  "gender": false,
//  "age": 1,
//  "speciesId": 1,
//  "breedId": 4
//}