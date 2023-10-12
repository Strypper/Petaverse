using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Tools;
using System;
using Windows.Media.Core;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml;
using Petaverse.Interfaces;
using Petaverse.Services.PetaverseAPI;
using Petaverse.Services;
using Petaverse.Models.FEModels;
using System.Linq;
using Windows.Storage;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Petaverse.ContentDialogs
{
    [INotifyPropertyChanged]
    public sealed partial class AddPetShortsContentDialog : ContentDialog
    {
        [ObservableProperty]
        Models.DTOs.User currentUser;

        [ObservableProperty]
        StorageFile video;


        PetShortDialogValidationForm ValidationForm { get; set; } = new PetShortDialogValidationForm();

        public readonly IPetShortService _petShortService;
        private readonly IUploadPetFileService _uploadPetFileService;
        public AddPetShortsContentDialog()
        {
            this.InitializeComponent();

            _petShortService      = Ioc.Default.GetRequiredService<IPetShortService>();
            _uploadPetFileService = Ioc.Default.GetRequiredService<IUploadPetFileService>();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var petShort = new CreatePetShortDTO()
            {
                Title = TitleTextBox.Text,
                PublisherGuid = CurrentUser.Guid,
                PetIds = PetList.SelectedItems.Cast<Models.DTOs.Animal>().Select(pet => pet.Id).ToList(),
                RepresentativePetId = (SelectedPets.SelectedItem as Models.DTOs.Animal).Id
            };
            var newPetShortWithoutVideo = await _petShortService.CreateAsync(petShort);
            if (newPetShortWithoutVideo != null && !string.IsNullOrEmpty(TitleTextBox.Text) && (SelectedPets.SelectedItem as Models.DTOs.Animal).Id != 0)
            {
                var petShortSAS = await _petShortService.GetPetShortSAS(newPetShortWithoutVideo.Id);
                var completePetShort = await _petShortService.UploadVideo(petShortSAS, video);
            }
            //ValidationForm.Validate();

            //if (ValidationForm.HasErrors)
            //{
            //    Debug.WriteLine("Bruhhh");
            //}

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void Avatars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PetList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void UploadVideo_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.FileTypeFilter.Add(".mp4");

            video = await picker.PickSingleFileAsync();
            if (video != null)
            {
                PreviewMediaPlayer.Source = MediaSource.CreateFromStorageFile(video);
                CommandButtons.Visibility = Visibility.Collapsed;
            }
        }
    }

    public partial class PetShortDialogValidationForm : ObservableValidator
    {
        public PetShortDialogValidationForm()
        {

        }

        [ObservableProperty]
        [Required]
        [MinLength(100)]
        [MaxLength(100)]
        private string? title;

        public void Validate() => ValidateAllProperties();
    }
}
