using System;
using System.Net.Http;
using Newtonsoft.Json;
using Petaverse.Interfaces;
using System.Threading.Tasks;
using Petaverse.Models.Others;
using System.Collections.Generic;
using Petaverse.ContentDialogs;
using Windows.Storage;
using System.IO;
using Petaverse.Models.DTOs;

namespace Petaverse.Services
{
    public class HttpClientUploadPetFileService : IUploadPetFileService
    {
        private HttpClient _httpClient;
        public HttpClientUploadPetFileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PetaverseMedia>> UploadMultiplePetFilesAsync(int petId, List<PetPhotosStream> uploadFiles)
        {
            var multipartFormContent = new MultipartFormDataContent();

            uploadFiles.ForEach(file =>
            {
                file.Stream.Position = 0;
                var media = new StreamContent(file.Stream);
                media.Headers.Add("Content-Type", "image/jpeg");
                multipartFormContent.Add(media, name: "medias", fileName: $"{file.FileName}");
            });

            try
            {
                var result = await _httpClient.PostAsync($"api/Animal/UploadAnimalMedias/{petId}", multipartFormContent);
                string stringReadResult = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PetaverseMedia>>(stringReadResult);
            }
            catch (Exception ex)
            {
                await new HttpRequestErrorContentDialog()
                {
                    Title = "Can't upload these photos"
                }.ShowAsync();
                return new List<PetaverseMedia>();
            }
        }

        public async Task<PetaverseMedia> CreatePetAvatarAsync(Animal petInfo, StorageFile avatar)
        {
            if (avatar != null)
            {
                var multipartFormContent = new MultipartFormDataContent();

                var handle = avatar.CreateSafeFileHandle(options: FileOptions.RandomAccess);
                var stream = new FileStream(handle, FileAccess.ReadWrite) { Position = 0 };
                var media = new StreamContent(stream);
                media.Headers.Add("Content-Type", "image/jpeg");
                multipartFormContent.Add(media, name: "avatar", fileName: $"{petInfo.Name}");

                try
                {
                    var result = await _httpClient.PostAsync($"api/Animal/UploadPetAvatar/{petInfo.Id}", multipartFormContent);
                    string stringReadResult = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PetaverseMedia>(stringReadResult);
                }
                catch (Exception ex)
                {
                    await new HttpRequestErrorContentDialog()
                    {
                        Title = "Can't upload avatar"
                    }.ShowAsync();
                    return null;
                }
            }
            else return null;
        }

        public async Task<PetaverseMedia> UploadVideoAsync(PetShort petShort, StorageFile video)
        {
            if (video != null)
            {
                var multipartFormContent = new MultipartFormDataContent();

                var handle = video.CreateSafeFileHandle(options: FileOptions.RandomAccess);
                var stream = new FileStream(handle, FileAccess.ReadWrite) { Position = 0 };
                var media = new StreamContent(stream);
                media.Headers.Add("Content-Type", "video/mp4");
                multipartFormContent.Add(media, name: "video", fileName: $"{petShort.Title}");

                try
                {
                    var result = await _httpClient.PostAsync($"api/PetShort/UploadPetAvatar/{petShort.Id}", multipartFormContent);
                    string stringReadResult = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PetaverseMedia>(stringReadResult);
                }
                catch (Exception ex)
                {
                    await new HttpRequestErrorContentDialog()
                    {
                        Title = "Can't upload video"
                    }.ShowAsync();
                    return null;
                }
            }
            else return null;
        }
    }
}
