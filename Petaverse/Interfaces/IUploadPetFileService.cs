using Petaverse.Models.FEModels;
using Petaverse.Models.Others;
using PetaVerse.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace Petaverse.Interfaces
{
    public interface IUploadPetFileService
    {
        public Task<List<PetaverseMedia>> UploadMultiplePetFilesAsync(int petId, List<PetPhotosStream> uploadFiles);
        public Task<string> CreatePetAvatarAsync(Animal petInfo, StorageFile avatar);
    }
}
