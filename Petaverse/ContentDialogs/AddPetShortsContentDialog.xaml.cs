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

namespace Petaverse.ContentDialogs
{
    [INotifyPropertyChanged]
    public sealed partial class AddPetShortsContentDialog : ContentDialog
    {
        [ObservableProperty]
        User currentUser;
        public AddPetShortsContentDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
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
