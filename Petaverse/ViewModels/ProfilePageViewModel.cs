using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Petaverse.ContentDialogs;
using Petaverse.Interfaces;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using Petaverse.Refits;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace Petaverse.ViewModels
{
    public partial class ProfilePageViewModel : ViewModelBase
    {
        [ObservableProperty]
        User currentUser;

        [ObservableProperty]
        bool infoBarIsOpen;

        [ObservableProperty]
        string infoBarTitle;

        [ObservableProperty]
        string infoBarMessage;

        [ObservableProperty]
        InfoBarSeverity infoBarServerity;

        string currentUserGuid;

        private readonly IAnimalService        _animalService;
        private readonly ICurrentUserService   _currentUserService;
        private readonly IUploadPetFileService _uploadPetFileService;

        public ProfilePageViewModel()
        {
            _animalService        = Ioc.Default.GetRequiredService<IAnimalService>();
            _currentUserService   = Ioc.Default.GetRequiredService<ICurrentUserService>();
            _uploadPetFileService = Ioc.Default.GetRequiredService<IUploadPetFileService>();


            currentUserGuid = _currentUserService.GetLocalUserGuidFromAppSettings();
        }

        [RelayCommand]
        async Task OpenCreatePetContentDialog()
            => await new AddPetContentDialog(){CreatePetCommand = CreatePetCommand}.ShowAsync();

        public async Task<User> LoadFakeUserData()
        {
            //var loremIpsum = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            //var bravo = new Animal()
            //{
            //    Name   = "Bravo",
            //    PetAvatar = "https://intranetblobstorages.blob.core.windows.net/petaverse/Bravo.jpg",
            //    Gender = true,
            //    Bio    = loremIpsum
            //};
            //var snow = new Animal()
            //{
            //    Name   = "Snow",
            //    PetAvatar = "https://intranetblobstorages.blob.core.windows.net/petaverse/Snow.jpg",
            //    Gender = true,
            //    Bio    = loremIpsum
            //};
            //var fakeUser = new User() 
            //{
            //    FirstName = "Strypper",
            //    LastName = "Jason",
            //    Email = "FutureWingsStrypper@outlook.com",
            //    PhoneNumber = "0348164682",
            //    Gender = true,
            //    ProfilePicUrl = "https://intranetblobstorages.blob.core.windows.net/avatarstorage/Viet.jpg",
            //    IsActive = true,
            //    IsDeleted = false,
            //    //Pets = await animalData.GetAllByUserId(2)
            //};
            return null;
        }

        public async Task<User> LoadUserDataAsync()
        {
            if (currentUserGuid != null && !String.IsNullOrEmpty(currentUserGuid))
            {
                var requestUser  = await _currentUserService.GetLocalUserAsync(currentUserGuid);
                requestUser.Pets = await _animalService.GetAllByUserGuidAsync(currentUserGuid);
                return requestUser;
            }
            else return null;
        }

        private async Task<IEnumerable<Animal>> GetAnimalAsync()
        {
            try
            {
                var res = await _animalService.GetAllByUserGuidAsync(currentUserGuid);
                return res;
            }
            catch (ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                await new ContentDialog()
                {
                    Title = "Unable to get your pets",
                    Content = "Please check your internet connection"
                }.ShowAsync();
                // Throw a normal exception
                throw new Exception(message);
            }
        }

        //<Animal?>
        [RelayCommand]
        public async Task<Animal> CreatePetAsync(CreatePetDTO petInfo)
        {
            var newPet = await _animalService.CreateAsync(petInfo);
            if (newPet != null)
            {
                var avatarUrl = await _uploadPetFileService.CreatePetAvatarAsync(newPet, petInfo.PetAvatar);
                if (avatarUrl != null)
                {
                    newPet.PetAvatar = avatarUrl;
                    CurrentUser.Pets.Add(newPet);
                    return newPet;
                }
                else
                {
                    CreateInfoBar(ProfilePageConstant.ErrorCantCreatePetAvatarTitle
                                 , ProfilePageConstant.ErrorCantCreatePetAvatarContent
                                 , InfoBarSeverity.Warning);
                    return null;
                }
            }
            else
            {
                CreateInfoBar(ProfilePageConstant.ErrorCantCreatePetTitle
                             , ProfilePageConstant.ErrorCantCreatePetContent
                             , InfoBarSeverity.Error);
                return null;
            }
        }

        void CreateInfoBar(string title, string message, InfoBarSeverity infoBarSeverity)
        {
            InfoBarTitle = title;
            InfoBarMessage = message;
            InfoBarServerity = infoBarServerity;

            InfoBarIsOpen = true;
        }
    }

    public class ProfilePageConstant
    {
        public const string ErrorCantCreatePetTitle = "Can't create this pet";
        public const string ErrorCantCreatePetAvatarTitle = "Can't create your pet avatar";

        public const string ErrorCantCreatePetContent = "Please try again or report us";
        public const string ErrorCantCreatePetAvatarContent = "We created your pet but the avatar couldn't upload please try again";
    }
}
