using Petaverse.Models.DTOs;
using Petaverse.Models.FEModels;
using Petaverse.Models.Others;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace Petaverse.Interfaces
{
    public interface IUploadPetFileService
    {
        public Task<List<PetaverseMedia>> UploadMultiplePetFilesAsync(int petId, List<PetPhotosStream> uploadFiles);
        public Task<PetaverseMedia> CreatePetAvatarAsync(Animal petInfo, StorageFile avatar);
        public Task<PetaverseMedia> UploadVideoAsync(PetShort petShort, StorageFile video);
    }
}
