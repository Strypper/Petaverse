using Petaverse.Models.FEModels;
using PetaVerse.Models.DTOs;
using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petaverse.Refits
{
    public interface IAnimalData
    {
        [Get("/Animal/GetAll")]
        Task<List<Animal>> GetAllAnimal();

        [Get("/Animal/Get/{id}")]
        Task<Animal> GetById(int id);

        [Get("/Animal/GetAllByUserId/{userGuid}")]
        Task<ObservableCollection<Animal>> GetAllByUserId(string userGuid);

        [Post("/Animal/Create")]
        Task<Animal> Create(FEPetInfo petInfo);

        //[Post("/Animal/UploadAnimalMedias/{petId}")]
        //Task<List<Animal>> UploadAnimalMedias(int petId, IEnumerable<StreamPart> files);

        [Multipart("media")]
        [Post("/Animal/UploadAnimalMedias/upload-media")]
        Task<HttpResponseMessage> UploadAnimalMedias([AliasAs("file")] StreamPart file);
    }
}
