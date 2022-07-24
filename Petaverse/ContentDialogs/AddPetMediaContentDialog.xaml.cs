using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using System;
using System.Net.Http;

namespace Petaverse.ContentDialogs
{
    public sealed partial class AddPetMediaContentDialog : ContentDialog
    {
        public ObservableCollection<BitmapImage> UploadMedia   { get; set; } = new ObservableCollection<BitmapImage>();
        public List<PetPhotosStream>             UploadFiles   { get; set; } = new List<PetPhotosStream>();

        public AddPetMediaContentDialog()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var client = new HttpClient(new HttpClientHandler(){ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true});
            var multipartFormContent = new MultipartFormDataContent();

            UploadFiles.ForEach(file =>
            {
                file.Stream.Position = 0;
                var media = new StreamContent(file.Stream);
                media.Headers.Add("Content-Type", "image/jpeg");
                //media.Headers.ContentLength = file.Stream.Length;
                multipartFormContent.Add(media, name: "medias", fileName: $"{file.FileName}");
            });

            var result = await client.PostAsync("https://localhost:44371/api/Animal/UploadAnimalMedias/2", multipartFormContent);
            string stringReadResult = await result.Content.ReadAsStringAsync();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private async void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker();
            filePicker.ViewMode = PickerViewMode.Thumbnail;

            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".png");

            var files = await filePicker.PickMultipleFilesAsync();
            foreach (var file in files)
            {
                var   stream      = (await file.OpenStreamForReadAsync()).AsRandomAccessStream();
                var   imageSource = new BitmapImage();
                await imageSource.SetSourceAsync(stream);

                UploadMedia.Add(imageSource);
                UploadFiles.Add(new PetPhotosStream() { FileName = file.Name, Stream = stream.AsStream() });
                //UploadStreams.Add(new StreamPart(stream.AsStream(), "Bravo " + file.Name, "image/jpeg"));
            }
        }

        public class PetPhotosStream
        {
            public string FileName { get; set; }
            public Stream Stream   { get; set; }
        }
    }
}
