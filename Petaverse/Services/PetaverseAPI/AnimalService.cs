using Petaverse.ContentDialogs;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.FEModels;
using Petaverse.Refits;
using PetaVerse.Models.DTOs;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petaverse.Services.PetaverseAPI
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalData _animalData = RestService.For<IAnimalData>(new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
        })
        {
            BaseAddress = new Uri("https://localhost:44371/api")
        });
        public AnimalService()
        {

        }
        public async Task<Animal?> CreateAsync(FEPetInfo petInfo)
        {
            try
            {
                return await _animalData.Create(petInfo);
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
        }

        public Task<ObservableCollection<Animal>> GetAllAnimalsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ObservableCollection<Animal?>> GetAllByUserGuidAsync(string userGuid)
        {
            try
            {
                return await _animalData.GetAllByUserGuid(userGuid);
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
        }

        public Task<Animal> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
