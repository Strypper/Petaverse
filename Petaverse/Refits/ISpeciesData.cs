using PetaVerse.Models.DTOs;
using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Petaverse.Refits
{
    public interface ISpeciesData
    {
        [Get("/Species/GetAll")]
        Task<List<Species>> GetAllSpecies();

        [Get("/Species/Get/{id}")]
        Task<Species> Get(int id);

        [Get("/Species/GetAllSpeciessWithMembers")]
        Task<List<Species>> GetAllSpeciessWithMembers();
    }
}
