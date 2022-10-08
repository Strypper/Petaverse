using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;

namespace Petaverse.Interfaces.PetaverseAPI
{
    public interface IPetShortService
    {
        Task<List<PetShort>> GetAllPetShortsAsync();
        Task<PetShort?> GetByIdAsync(int id);
        Task<ObservableCollection<PetShort?>> GetAllByUserGuidAsync(string userGuid);
        Task<PetShort?> CreateAsync(CreatePetShortDTO createPetShortDTO);
        Task DeleteAsync(int id);
        Task<PetShort?> UpdateAsync(PetShort petInfo);
        public Task<PetShort?> UploadVideo(PetShort petShort, StorageFile video);
    }
}