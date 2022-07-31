using System;
using System.Net.Http;
using Newtonsoft.Json;
using Petaverse.Enums;
using Petaverse.Interfaces;
using PetaVerse.Models.DTOs;
using System.Threading.Tasks;
using Petaverse.Models.Others;
using System.Collections.Generic;
using Petaverse.ContentDialogs;
using Refit;

namespace Petaverse.Services
{
    public class HttpClientUploadPetFileService : IUploadPetFileService
    {
        private HttpClient _httpClient;
        public HttpClientUploadPetFileService(Func<HttpClientEnum, HttpClient> httpClient)
        {
            _httpClient = httpClient(HttpClientEnum.Petaverse);
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

            try
            {
                var result = await _httpClient.PostAsync($"{uploadUrl}{petId}", multipartFormContent);
                string stringReadResult = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PetaverseMedia>>(stringReadResult);
            }
            catch (Exception ex)
            {
                await new HttpRequestErrorContentDialog()
                {
                    Title = "Can't upload these photos"
                }.ShowAsync();
                return null;
            }
        }
    }
}
