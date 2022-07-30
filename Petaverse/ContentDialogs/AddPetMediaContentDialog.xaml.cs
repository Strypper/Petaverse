using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using System;
using System.Net.Http;
using Petaverse.Models.Others;
using Petaverse.Interfaces;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace Petaverse.ContentDialogs
{
    public sealed partial class AddPetMediaContentDialog : ContentDialog
    {
        public ObservableCollection<BitmapImage> UploadMedia   { get; set; } = new ObservableCollection<BitmapImage>();
        public List<PetPhotosStream>             UploadFiles   { get; set; } = new List<PetPhotosStream>();

        public int PetId { get; set; }
        private IUploadPetFileService _uploadPetFileService;

        public AddPetMediaContentDialog(int petId)
        {
            this.PetId = petId;
            this.InitializeComponent();
            _uploadPetFileService = Ioc.Default.GetRequiredService<IUploadPetFileService>();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if(PetId != 0)
                await _uploadPetFileService.UploadMultiplePetFilesAsync("https://localhost:44371/api/Animal/UploadAnimalMedias/", PetId, UploadFiles);
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
    }
}
