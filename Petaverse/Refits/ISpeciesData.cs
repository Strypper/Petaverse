using Petaverse.Models.DTOs;
using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Petaverse.Refits
{
    public interface ISpeciesData
    {
        [Get("/Species/GetAll")]
        Task<ObservableCollection<Species>> GetAllAsync();

        [Get("/Species/Get/{id}")]
        Task<Species> GetByIdAsync(int id);

        [Get("/Species/GetAllSpeciessWithMembers")]
        Task<List<Species>> GetAllSpeciessWithMembersAsync();

        [Post("/Species/Create")]
        Task<Species?> CreateAsync(Species dto);
    }
}
