﻿using System;
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
using System.Net.Http.Headers;
using Azure.Storage.Blobs;
using System.Text;

namespace Petaverse.Services
{
    public class HttpClientUploadPetFileService : IUploadPetFileService
    {
        private HttpClient _httpClient;
        public HttpClientUploadPetFileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Models.DTOs.PetaverseMedia>> UploadMultiplePetFilesAsync(int petId, List<PetPhotosStream> uploadFiles)
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
                return JsonConvert.DeserializeObject<List<Models.DTOs.PetaverseMedia>>(stringReadResult);
            }
            catch (Exception ex)
            {
                await new HttpRequestErrorContentDialog()
                {
                    Title = "Can't upload these photos"
                }.ShowAsync();
                return new List<Models.DTOs.PetaverseMedia>();
            }
        }

        public async Task<Models.DTOs.PetaverseMedia> CreatePetAvatarAsync(Models.DTOs.Animal petInfo, StorageFile avatar)
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
                    return JsonConvert.DeserializeObject<Models.DTOs.PetaverseMedia>(stringReadResult);
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

        public async Task<PetShortSAS> UploadVideoAsync(int petShortId,
                                                        BlobClientSAS blobClientSAS, 
                                                        StorageFile video)
        {
            if (video != null)
            {
                var handle = video.CreateSafeFileHandle(options: FileOptions.RandomAccess);
                var stream = new FileStream(handle, FileAccess.Read) { Position = 0 };

                try
                {
                    var client = new BlobClient(blobClientSAS.SASUri, null);

                    // Upload stream
                    var blobInfo = await client.UploadAsync(stream);
                    if (blobInfo != null)
                    {
                        return new PetShortSAS()
                        {
                            SASUri = blobClientSAS.SASUri,
                            BlobUrl = blobClientSAS.BlobUrl,
                            PetShortId = petShortId
                        };
                    }
                    else return null;
                }
                catch (Azure.RequestFailedException ex)
                {
                    await new HttpRequestErrorContentDialog()
                    {
                        Title = "Can't upload video",
                        Content = ex.ErrorCode
                    }.ShowAsync();
                    return null;
                }
            }
            else return null;
        }
    }
}
