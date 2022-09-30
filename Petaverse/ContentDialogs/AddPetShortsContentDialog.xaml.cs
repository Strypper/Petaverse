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

namespace Petaverse.ContentDialogs
{
    [INotifyPropertyChanged]
    public sealed partial class AddPetShortsContentDialog : ContentDialog
    {
        [ObservableProperty]
        User currentUser;

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
                PetIds = PetList.SelectedItems.Cast<Animal>().Select(pet => pet.Id).ToList(),
                RepresentativePetId = (SelectedPets.SelectedItem as Animal).Id
            };
            //var newPetShort = await _petShortService.CreateAsync(new CreatePetShortDTO()
            //{
            //    Title = TitleTextBox.Text,
            //    PetIds = PetList.SelectedItems.Cast<Animal>().Select(pet => pet.Id).ToList(),
            //    RepresentativePetId = (SelectedPets.SelectedItem as Animal).Id
            //});
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

            var video = await picker.PickSingleFileAsync();
            if (video != null)
            {
                PreviewMediaPlayer.Source = MediaSource.CreateFromStorageFile(video);
                CommandButtons.Visibility = Visibility.Collapsed;
            }
        }
    }
}
