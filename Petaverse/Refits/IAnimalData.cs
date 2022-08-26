using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
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
        Task<ObservableCollection<Animal>> GetAllAnimal();

        [Get("/Animal/GetById/{animalId}")]
        Task<Animal> GetById(int animalId);

        [Get("/Animal/GetAllByUserGuid/{userGuid}")]
        Task<ObservableCollection<Animal>> GetAllByUserGuid(string userGuid);

        [Post("/Animal/Create")]
        Task<int> Create(CreatePetDTO petInfo);

        [Delete("/Animal/Delete/{id}")]
        Task<HttpResponseMessage> DeleteAnimal(int id);
    }
}
