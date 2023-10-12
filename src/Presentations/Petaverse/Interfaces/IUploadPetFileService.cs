using Petaverse.Models.Others;
using Windows.Storage;

namespace Petaverse.Interfaces;

public interface IUploadPetFileService
{
    public Task<List<Models.DTOs.PetaverseMedia>> UploadMultiplePetFilesAsync(int petId, List<PetPhotosStream> uploadFiles);
    public Task<Models.DTOs.PetaverseMedia> CreatePetAvatarAsync(Models.DTOs.Animal petInfo, StorageFile avatar);
    public Task<PetShortSAS> UploadVideoAsync(int petShortId, BlobClientSAS blobClientSAS, StorageFile video);
}
