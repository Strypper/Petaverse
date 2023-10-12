using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Petaverse.Interfaces.PetaverseAPI
{
    public interface IAnimalService
    {
        Task<ObservableCollection<Models.DTOs.Animal?>> GetAllAnimalsAsync();
        Task<Models.DTOs.Animal?> GetByIdAsync(int id);
        Task<ObservableCollection<Models.DTOs.Animal?>> GetAllByUserGuidAsync(string userGuid);
        Task<Models.DTOs.Animal?> CreateAsync(CreatePetDTO petInfo);
        Task DeleteAsync(int id);
        Task<Models.DTOs.Animal?> UpdateAsync(Models.DTOs.Animal petInfo);
    }
}
