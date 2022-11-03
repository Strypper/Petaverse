using Petaverse.ContentDialogs;
using Petaverse.Interfaces;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using Petaverse.Models.Others;
using Petaverse.Refits;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
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
                //var result = await _petShortData.GetAllPetShort();
                return await _petShortData.GetAllPetShort();
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
            catch (Exception e)
            {
                await new ServerNotFoundContentDialog()
                {
                    HttpClientInfo = _httpClient,
                    Action = "Trying to get Pet Shorts",
                    ServiceImageUrl = "https://i.imgur.com/EieEOMK.png",
                    DestinationTryingToReach = "/Animal/GetAllByUserGuid/{userGuid}",
                    ProblemsCouldCauseList = new List<string>() { "Server is shutted down", "Wrong URL" },
                    SolutionsList = new List<string>() { "Start the server", "Contact to IT" }
                }
                .ShowAsync();
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

        public async Task<PetShort?> UploadVideo(PetShortSAS blobClientSAS, 
                                                 StorageFile video)
        {
            try
            {
                var petShortSAS = await _uploadPetFileService.UploadVideoAsync(blobClientSAS.PetShortId, blobClientSAS, video);
                var responseMessage =  await _petShortData.UpdatePetShortVideo(petShortSAS.PetShortId, petShortSAS.BlobUrl);
                return responseMessage != HttpStatusCode.OK  
                            ? await _petShortData.GetById(petShortSAS.PetShortId) 
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

        public Task<PetShortSAS> GetPetShortSAS(int petShortId)
            => _petShortData.GetPetShortSAS(petShortId);
    }
}
