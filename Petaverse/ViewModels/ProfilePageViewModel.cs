using Microsoft.Toolkit.Mvvm.ComponentModel;
using PetaVerse.Models.DTOs;
using System.Collections.Generic;

namespace Petaverse.ViewModels
{
    public partial class ProfilePageViewModel : ViewModelBase
    {
        [ObservableProperty]
        User currentUser;
        public ProfilePageViewModel()
        {
            CurrentUser = LoadFakeUserData();
        }

        private User LoadFakeUserData()
        {
            var loremIpsum = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            var bravo = new Animal()
            {
                Name   = "Bravo",
                Avatar = "https://intranetblobstorages.blob.core.windows.net/petaverse/Bravo.jpg",
                Gender = true,
                Bio    = loremIpsum
            };
            var snow = new Animal()
            {
                Name   = "Snow",
                Avatar = "https://intranetblobstorages.blob.core.windows.net/petaverse/Snow.jpg",
                Gender = true,
                Bio    = loremIpsum
            };
            var fakeUser = new User() 
            {
                firstName = "Strypper",
                lastName = "Jason",
                email = "FutureWingsStrypper@outlook.com",
                phoneNumber = "0348164682",
                gender = true,
                profilePicUrl = "https://intranetblobstorages.blob.core.windows.net/avatarstorage/Viet.jpg",
                IsActive = true,
                IsDeleted = false,
                Pets = new List<Animal>() { bravo, snow }
            };
            return fakeUser;
        }
    }
}
