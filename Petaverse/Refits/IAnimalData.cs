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

        [Get("/Animal/Get/{id}")]
        Task<Animal> GetById(int id);

        [Get("/Animal/GetAllByUserGuid/{userGuid}")]
        Task<ObservableCollection<Animal>> GetAllByUserGuid(string userGuid);

        [Post("/Animal/Create")]
        Task<Animal> Create(CreatePetDTO petInfo);

        [Delete("/Animal/Delete/{id}")]
        Task<HttpResponseMessage> DeleteAnimal(int id);
    }
}
