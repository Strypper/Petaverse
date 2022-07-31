using Petaverse.Models.FEModels;
using Petaverse.Refits;
using PetaVerse.Models.DTOs;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Windows.Foundation;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Petaverse.ContentDialogs
{
    public sealed partial class AddPetContentDialog : ContentDialog
    {
        public ObservableCollection<Species> Species { get; set; } = new ObservableCollection<Species>();
        public FEPetInfo                     PetInfo { get; set; }

        private readonly ISpeciesData speciestData = RestService.For<ISpeciesData>(new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
        })
        {
            BaseAddress = new Uri("https://localhost:44371/api")
        });

        private StorageFile catPhoto;

        public AddPetContentDialog()
        {
            this.InitializeComponent();

            SpeciesComboBox.SelectionChanged += (sender, e) => colorStoryboard.Begin();
        }

        private async void ContentDialog_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var species = await speciestData.GetAllSpecies();
            if (species != null)
                species.ForEach(s => Species.Add(s));
            SpeciesComboBox.SelectedIndex = species.Count > 0 ? 0 : -1;
            AddPetDialog.RequestedTheme = Windows.UI.Xaml.ElementTheme.Light;
        }

        private void AddPetDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var petStory = String.Empty;
            StoryEditBox.Document.GetText(TextGetOptions.None, out petStory);
            PetInfo = new FEPetInfo()
            {
                Name = PetName.Text,
                Bio = petStory,
                PetColor = String.Join(",", BreedColorGridView.SelectedItems.ToList()),
                Gender = GenderToggleSwitch.IsOn,
                DateOfBirth = PetDateOfBirthDatePicker.Date.DateTime,
                Age = (int)AgeNumberBox.Value,
                BreedId = (BreedCombobox.SelectedItem as Breed).Id,
                SpeciesId = (SpeciesComboBox.SelectedItem as Species).Id
            };
        }

        private async void AvatarUserControl_OpenFileEventHandler(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            catPhoto = await picker.PickSingleFileAsync();
            if(catPhoto != null)
            {
                await AvatarCropper.LoadImageFromFile(catPhoto);
                PetInfo.PetAvatar = catPhoto;
            }
        }

        private async void AvatarUserControl_OpenCameraEventHandler(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            catPhoto = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (catPhoto == null)
            {
                // User cancelled photo capture
                return;
            }
            else
            {

            }
        }

        private void ClearDateAndAgeButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PetDateOfBirthDatePicker.SelectedDate = null;
            AgeNumberBox.Value = 0;
        }
    }

    public class SpeciesToBreedsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var species = (Species)value;
            return species != null ? species.Breeds : null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class BreedToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var breed = (Breed)value;
            return breed != null ? breed.Color.Split(',').ToList() : null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class SpeciesToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var species = (Species)value;
            if(species != null)
            {
                var hex = species.Color;
                hex = hex.Replace("#", string.Empty);
                // from #RRGGBB string
                var r = (byte)System.Convert.ToUInt32(hex.Substring(0, 2), 16);
                var g = (byte)System.Convert.ToUInt32(hex.Substring(2, 2), 16);
                var b = (byte)System.Convert.ToUInt32(hex.Substring(4, 2), 16);
                //get the color
                return Color.FromArgb(255, r, g, b);
            }

            else return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
