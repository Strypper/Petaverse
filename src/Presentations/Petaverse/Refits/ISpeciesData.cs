namespace Petaverse.Refits;

public interface ISpeciesData
{
    [Get("/Species/GetAll")]
    Task<ObservableCollection<Models.DTOs.Species>> GetAllAsync();

    [Get("/Species/Get/{id}")]
    Task<Models.DTOs.Species> GetByIdAsync(int id);

    [Get("/Species/GetAllSpeciessWithMembers")]
    Task<List<Models.DTOs.Species>> GetAllSpeciessWithMembersAsync();

    [Post("/Species/Create")]
    Task<Models.DTOs.Species?> CreateAsync(Models.DTOs.Species dto);
}
