using PetaVerse.Models.DTOs;
using Refit;
using System.Collections.Generic;
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

        [Get("/Animal/GetAllByUserId/{userId}")]
        Task<List<Animal>> GetAllByUserId(int userId);

        //[Post("/Animal/UploadAnimalMedias/{petId}")]
        //Task<List<Animal>> UploadAnimalMedias(int petId, IEnumerable<StreamPart> files);

        [Multipart("media")]
        [Post("/Animal/UploadAnimalMedias/upload-media")]
        Task<HttpResponseMessage> UploadAnimalMedias([AliasAs("file")] StreamPart file);
    }
}
