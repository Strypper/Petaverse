using Refit;
using System;
using System.Net.Http;
using Petaverse.Refits;
using System.Threading.Tasks;
using Petaverse.ContentDialogs;
using System.Collections.Generic;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;

namespace Petaverse.Services.PetaverseAPI
{
    public class SpeciesService : ISpeciesService
    {
        private readonly HttpClient _httpClient;
        private readonly ISpeciesData _speciesData;

        public SpeciesService(HttpClient httpClient) 
        {
            _httpClient  = httpClient;
            _speciesData = RestService.For<ISpeciesData>(httpClient);
        }

        public async Task<ICollection<Species>> GetAllAsync()
        {
            try
            {
                return await _speciesData.GetAllAsync();
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
            catch (Exception ex)
            {
                await new ServerNotFoundContentDialog()
                {
                    HttpClientInfo = _httpClient,
                    Action = "Trying to get all the species from PetaverseAPI",
                    DestinationTryingToReach = "/Species/GetAll",
                    ServiceImageUrl = "https://i.imgur.com/EieEOMK.png",
                    ProblemsCouldCauseList = new List<string>() { "PetaverseAPI is shutted down", "Wrong URL" },
                    SolutionsList = new List<string>() { "Start the PetaverseAPI", "Contact to IT" }
                }
                .ShowAsync();
                return null;
            }
        }

        public async Task<Species> GetByIdAsync(int id)
        {
            try
            {
                return await _speciesData.GetByIdAsync(id);
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
        }


        public async Task<Species?> CreateAsync(Species dto)
        {
            try
            {
                return await _speciesData.CreateAsync(dto);
            }
            catch (ApiException ex)
            {
                await new HttpRequestErrorContentDialog() { Exception = ex }.ShowAsync();
                return null;
            }
        }

        public Task<Species> DeleteAsync(Species dto)
        {
            throw new System.NotImplementedException();
        }
        public Task<Species> UpdateAsync(Species dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
