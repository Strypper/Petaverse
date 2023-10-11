using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using Petaverse.Models.Others;
using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petaverse.Refits
{
    public interface IPetShortData
    {
        [Get("/PetShorts/GetPetShortSAS/{petShortId}")]
        Task<PetShortSAS> GetPetShortSAS(int petShortId);

        [Get("/PetShorts/GetAll")]
        Task<ObservableCollection<PetShort>> GetAllPetShort();

        [Get("/PetShorts/GetById/{petShortId}")]
        Task<PetShort> GetById(int petShortId);

        [Post("/PetShorts/Create")]
        Task<int> Create(CreatePetShortDTO createPetShortDTO);

        [Post("/PetShorts/UpdatePetShortVideo/{petShortId}")]
        Task<HttpStatusCode> UpdatePetShortVideo(int petShortId, string videoUrl);
    }
}
