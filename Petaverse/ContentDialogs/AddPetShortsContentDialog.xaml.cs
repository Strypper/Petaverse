using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Tools;

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
    }
}
