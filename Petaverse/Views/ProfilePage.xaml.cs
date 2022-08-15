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