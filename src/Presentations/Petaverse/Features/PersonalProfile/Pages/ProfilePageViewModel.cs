using CommunityToolkit.Mvvm.Input;
using Petaverse.Models.FEModels;
using Petaverse.PersonalProfile;

namespace Petaverse.ViewModels
{
    public partial class ProfilePageViewModel : ViewModelBase
    {

        #region [ Properties ]

        [ObservableProperty]
        UserModel userInfo;

        [ObservableProperty]
        bool infoBarIsOpen;

        [ObservableProperty]
        string infoBarTitle;

        [ObservableProperty]
        string infoBarMessage;

        [ObservableProperty]
        string infoBarColor;

        [ObservableProperty]
        string infoBarIcon;

        [ObservableProperty]
        bool overLayPopUpVisibility;

        [ObservableProperty]
        Models.DTOs.PetaverseMedia petaverseMedia;
        #endregion

        #region [ Fields ]

        private readonly IProfilePageService profilePageService;
        #endregion

        public ProfilePageViewModel(IProfilePageService profilePageService)
        {
            this.profilePageService = profilePageService;
        }

        [RelayCommand]
        async Task OpenCreatePetContentDialog()
            => await new AddPetContentDialog(){CreatePetCommand = CreatePetCommand}.ShowAsync();

        public async Task<Models.DTOs.User> LoadUserDataAsync()
        {
            IsBusy = true;
            if (currentUserGuid != null && !String.IsNullOrEmpty(currentUserGuid))
            {
                var requestUser  = await _currentUserService.GetLocalUserAsync(currentUserGuid);
                requestUser.Pets = await _animalService.GetAllByUserGuidAsync(currentUserGuid);
                IsBusy = false;
                return requestUser;
            }
            else {
                IsBusy = false;
                CreateInfoBar(ProfilePageConstant.SuccessRemovePetTitle
                             ,ProfilePageConstant.SuccessRemovePetContent
                             ,ProfilePageConstant.ErrorColor
                             ,ProfilePageConstant.BrokenHeartIcon);
                return null;
            };
        }

        private async Task<IEnumerable<Models.DTOs.Animal>> GetAnimalAsync()
        {
            IsBusy = true;
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
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task CreatePetAsync(CreatePetDTO petInfo)
        {
            IsBusy = true;
            //var newPet = await _animalService.CreateAsync(petInfo);
            //if (newPet != null)
            //{
            //    var avatarUrl = await _uploadPetFileService.CreatePetAvatarAsync(newPet, petInfo.PetAvatar);
            //    if (avatarUrl != null)
            //    {
            //        newPet.PetAvatar = avatarUrl;
            //        UserInfo.Pets.Add(newPet);
            //        CreateInfoBar(ProfilePageConstant.SuccessCreatePetAvatarTitle
            //                     ,ProfilePageConstant.SuccessCreatePetContent
            //                     ,ProfilePageConstant.SuccessColor
            //                     ,ProfilePageConstant.SuccessIcon);
            //    }
            //    else
            //    {
            //        CreateInfoBar(ProfilePageConstant.ErrorCantCreatePetAvatarTitle
            //                     ,ProfilePageConstant.ErrorCantCreatePetAvatarContent
            //                     ,ProfilePageConstant.WarningColor
            //                     ,ProfilePageConstant.WarningIcon);
            //    }
            //}
            //else
            //{
            //    CreateInfoBar(ProfilePageConstant.ErrorCantCreatePetTitle
            //                 ,ProfilePageConstant.ErrorCantCreatePetContent
            //                 ,ProfilePageConstant.ErrorColor
            //                 ,ProfilePageConstant.ErrorIcon);
            //}
            //await ApplicationData.Current.TemporaryFolder.DeleteAsync();
            IsBusy = false;
        }

        [RelayCommand]
        public async Task DeletePetAsync(string petId)
        {
            IsBusy = true;
            //HTTP delete the pet

            var deletedPet = UserInfo.Pets.FirstOrDefault(pet => pet.Id == petId);
            UserInfo.Pets.Remove(deletedPet);
            CreateInfoBar(ProfilePageConstant.SuccessRemovePetTitle
                         ,ProfilePageConstant.SuccessRemovePetContent
                         ,ProfilePageConstant.ErrorColor
                         ,ProfilePageConstant.BrokenHeartIcon);
            IsBusy = false;
        }

        [RelayCommand]
        public async Task DismissStatusInfo()
        {
            InfoBarIsOpen = false;
        }

        void CreateInfoBar(string title, string message, string infoBarColor, string icon)
        {
            InfoBarTitle   = title;
            InfoBarMessage = message;
            InfoBarColor   = infoBarColor;
            InfoBarIcon    = icon;

            InfoBarIsOpen = true;
        }
    }

    public class ProfilePageConstant
    {
        public const string SuccessCreatePetAvatarTitle = "Yay new pet added !";
        public const string ErrorCantCreatePetTitle = "Can't create this pet";
        public const string ErrorCantCreatePetAvatarTitle = "Can't create your pet avatar";


        public const string SuccessRemovePetTitle = "Rest in peace";
        public const string SuccessRemovePetContent = "No longer at your side, but always in your heart!";

        public const string SuccessCreatePetContent = "Cool let explore our new friend";
        public const string ErrorCantCreatePetContent = "Please try again or report us";
        public const string ErrorCantCreatePetAvatarContent = "We created your pet but the avatar couldn't upload please try again";

        public const string SuccessColor = "#2de99a";
        public const string WarningColor = "#ffd669";
        public const string ErrorColor = "#ff6a98";

        public const string SuccessIcon     = "\uEC61";
        public const string WarningIcon     = "\uE7BA";
        public const string ErrorIcon       = "\uEA39";
        public const string BrokenHeartIcon = "\uE00C";
    }
}
