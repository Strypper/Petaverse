using Newtonsoft.Json;
using Petaverse.Interfaces;
using Petaverse.Models.Others;
using PetaVerse.Models.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petaverse.Services
{
    public class HttpClientUploadPetFileService : IUploadPetFileService
    {
        private HttpClient _httpClient;
        public HttpClientUploadPetFileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PetaverseMedia>> UploadMultiplePetFilesAsync(string uploadUrl, int petId, List<PetPhotosStream> uploadFiles)
        {
            var multipartFormContent = new MultipartFormDataContent();

            uploadFiles.ForEach(file =>
            {
                file.Stream.Position = 0;
                var media = new StreamContent(file.Stream);
                media.Headers.Add("Content-Type", "image/jpeg");
                multipartFormContent.Add(media, name: "medias", fileName: $"{file.FileName}");
            });

            var result = await _httpClient.PostAsync($"https://localhost:44371/api/Animal/UploadAnimalMedias/{petId}", multipartFormContent);
            string stringReadResult = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PetaverseMedia>>(stringReadResult);
        }
    }
}
