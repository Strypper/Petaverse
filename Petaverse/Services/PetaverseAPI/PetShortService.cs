using Petaverse.ContentDialogs;
using Petaverse.Interfaces;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using Petaverse.Refits;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Storage;

namespace Petaverse.Services.PetaverseAPI
{
    public class PetShortService : IPetShortService
    {
        private readonly HttpClient            _httpClient;
        private readonly IPetShortData         _petShortData;
        private readonly IUploadPetFileService _uploadPetFileService;
        public PetShortService(HttpClient            httpClient,
                               IUploadPetFileService uploadPetFileService)
        {
            _httpClient           = httpClient;
            _petShortData         = RestService.For<IPetShortData>(httpClient);
            _uploadPetFileService = uploadPetFileService;
        }

        public async Task<ObservableCollection<PetShort>> GetAllPetShortsAsync()
        {
            try
            {
                return await _petShortData.GetAllPetShort();
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
        }

        public async Task<PetShort?> CreateAsync(CreatePetShortDTO petInfo)
        {
            try
            {
                var petShortId = await _petShortData.Create(petInfo);
                return petShortId != 0 ? await _petShortData.GetById(petShortId) : null;
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
        }

        public async Task<PetShort?> UploadVideo(PetShort    petShort, 
                                                 StorageFile video)
        {
            try
            {
                var petaverseMedia = await _uploadPetFileService.UploadVideoAsync(petShort, video);
                return petaverseMedia != null  
                            ? await _petShortData.GetById(petShort.Id) 
                            : null;
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ObservableCollection<PetShort>> GetAllByUserGuidAsync(string userGuid)
        {
            throw new System.NotImplementedException();
        }

        public Task<PetShort> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<PetShort> UpdateAsync(PetShort petInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}
