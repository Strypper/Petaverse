using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Petaverse.Interfaces.PetaverseAPI
{
    public interface IAnimalService
    {
        Task<ObservableCollection<Animal?>> GetAllAnimalsAsync();
        Task<Animal?> GetByIdAsync(int id);
        Task<ObservableCollection<Animal?>> GetAllByUserGuidAsync(string userGuid);
        Task<Animal?> CreateAsync(CreatePetDTO petInfo);
    }
}
