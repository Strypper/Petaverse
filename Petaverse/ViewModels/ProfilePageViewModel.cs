using CommunityToolkit.Mvvm.ComponentModel;
using Petaverse.Models.FEModels;
using Petaverse.Refits;
using PetaVerse.Models.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Petaverse.ViewModels
{
    public partial class ProfilePageViewModel : ViewModelBase
    {
        [ObservableProperty]
        User currentUser;


        private readonly IAnimalData animalData = RestService.For<IAnimalData>(new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
        })
        {
            BaseAddress = new Uri("https://localhost:44371/api")
        });

        public ProfilePageViewModel()
        {

        }

        public async Task<User> LoadFakeUserData()
        {
            var loremIpsum = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            var bravo = new Animal()
            {
                Name   = "Bravo",
                PetAvatar = "https://intranetblobstorages.blob.core.windows.net/petaverse/Bravo.jpg",
                Gender = true,
                Bio    = loremIpsum
            };
            var snow = new Animal()
            {
                Name   = "Snow",
                PetAvatar = "https://intranetblobstorages.blob.core.windows.net/petaverse/Snow.jpg",
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
                Pets = await animalData.GetAllByUserId(2)
            };
            return fakeUser;
        }

        private async Task<IEnumerable<Animal>> GetAnimalAsync()
        {
            try
            {
                var res = await animalData.GetAllByUserId(2);
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

        public async Task<Animal> CreatePetAsync(FEPetInfo petInfo) 
            => await animalData.Create(petInfo);
    }
}
