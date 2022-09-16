using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using Refit;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Petaverse.Refits
{
    public interface IPetShortData
    {
        [Get("/PetShort/GetAll")]
        Task<ObservableCollection<PetShort>> GetAllPetShort();

        [Get("/PetShort/GetById/{petShortId}")]
        Task<PetShort> GetById(int petShortId);

        [Post("/PetShort/Create")]
        Task<int> Create(CreatePetShortDTO createPetShortDTO);


    }
}
