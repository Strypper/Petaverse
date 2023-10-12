namespace Petaverse.Services.PetaverseAPI;

public class SpeciesService : ISpeciesService
{
    private readonly HttpClient _httpClient;
    private readonly ISpeciesData _speciesData;

    public SpeciesService(HttpClient httpClient) 
    {
        _httpClient  = httpClient;
        _speciesData = RestService.For<ISpeciesData>(httpClient);
    }

    public async Task<ICollection<Models.DTOs.Species>> GetAllAsync()
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

    public async Task<Models.DTOs.Species> GetByIdAsync(int id)
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


    public async Task<Models.DTOs.Species?> CreateAsync(Models.DTOs.Species dto)
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

    public Task<Models.DTOs.Species> DeleteAsync(Models.DTOs.Species dto)
    {
        throw new System.NotImplementedException();
    }
    public Task<Models.DTOs.Species> UpdateAsync(Models.DTOs.Species dto)
    {
        throw new System.NotImplementedException();
    }
}
