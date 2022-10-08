using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Petaverse.Refits
{
    public interface IPetShortData
    {
        [Get("/PetShorts/GetAll")]
        Task<List<PetShort>> GetAllPetShort();

        [Get("/PetShorts/GetById/{petShortId}")]
        Task<PetShort> GetById(int petShortId);

        [Post("/PetShorts/Create")]
        Task<int> Create(CreatePetShortDTO createPetShortDTO);


    }
}
