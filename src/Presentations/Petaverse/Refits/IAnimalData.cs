using Petaverse.Models.FEModels;

namespace Petaverse.Refits;

public interface IAnimalData
{
    [Get("/Animal/GetAll")]
    Task<ObservableCollection<Models.DTOs.Animal>> GetAllAnimal();

    [Get("/Animal/GetById/{animalId}")]
    Task<Models.DTOs.Animal> GetById(int animalId);

    [Get("/Animal/GetAllByUserGuid/{userGuid}")]
    Task<ObservableCollection<Models.DTOs.Animal>> GetAllByUserGuid(string userGuid);

    [Post("/Animal/Create")]
    Task<int> Create(CreatePetDTO petInfo);

    [Delete("/Animal/Delete/{id}")]
    Task<HttpResponseMessage> DeleteAnimal(int id);
}
