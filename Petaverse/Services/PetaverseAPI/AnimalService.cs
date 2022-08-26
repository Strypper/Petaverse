using Petaverse.ContentDialogs;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using Petaverse.Refits;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petaverse.Services.PetaverseAPI
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalData _animalData;
        public AnimalService(HttpClient httpClient)
        {
            _animalData = RestService.For<IAnimalData>(httpClient);
        }

        public async Task<Animal?> CreateAsync(CreatePetDTO petInfo)
        {
            try
            {
                var animalId = await _animalData.Create(petInfo);
                return animalId != 0 ? await _animalData.GetById(animalId) : null;
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
        }

        public async Task<ObservableCollection<Animal>> GetAllAnimalsAsync()
        {
            try
            {
                return await _animalData.GetAllAnimal();
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
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

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _animalData.DeleteAnimal(id);
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
            }
        }

        public Task<Animal> UpdateAsync(Animal petInfo)
        {
            throw new NotImplementedException();
        }
    }
}
