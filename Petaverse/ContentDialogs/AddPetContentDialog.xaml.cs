using Petaverse.Interfaces;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.FEModels;
using Petaverse.Services;
using Petaverse.Helpers;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.Foundation;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using System.Collections.Specialized;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Petaverse.Models.DTOs;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Threading.Tasks;

namespace Petaverse.ContentDialogs
{
    [INotifyPropertyChanged]
    public sealed partial class AddPetContentDialog : ContentDialog, INotifyDataErrorInfo
    {
        public bool IsPrimaryEnable => !HasErrors;
        public bool HasErrors => _validationService.HasErrors;

        private readonly ValidationService   _validationService;
        private readonly IAnimalService      _animalService;
        private readonly ISpeciesService     _speciestService;
        private readonly ICurrentUserService _currentUserService;

        private StorageFile catPhoto;

        [ObservableProperty]
        private ObservableCollection<Animal> ownedPets = new ObservableCollection<Animal>();

        [ObservableProperty]
        private CreatePetDTO petInfo = new CreatePetDTO();

        [ObservableProperty]
        private ObservableCollection<Species> species = new ObservableCollection<Species>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> errorsList = new ObservableCollection<ValidationProperty>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> nameErrorsList = new ObservableCollection<ValidationProperty>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> ageErrorsList = new ObservableCollection<ValidationProperty>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> breedErrorList = new ObservableCollection<ValidationProperty>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> bioErrorsList = new ObservableCollection<ValidationProperty>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> petAvatarErrorsList = new ObservableCollection<ValidationProperty>();



        public IRelayCommand<CreatePetDTO> CreatePetCommand
        {
            get { return (IRelayCommand<CreatePetDTO>)GetValue(CreatePetCommandProperty); }
            set { SetValue(CreatePetCommandProperty, value); }
        }

        public static readonly DependencyProperty CreatePetCommandProperty =
            DependencyProperty.Register("CreatePetCommand", typeof(IRelayCommand<CreatePetDTO>), typeof(AddPetContentDialog), null);



        public AddPetContentDialog()
        {
            this.InitializeComponent();
            //this.SpeciesComboBox.SelectionChanged += (sender, e) => colorStoryboard.Begin();
            this._animalService      = Ioc.Default.GetRequiredService<IAnimalService>();
            this._currentUserService = Ioc.Default.GetRequiredService<ICurrentUserService>();
            this._speciestService    = Ioc.Default.GetRequiredService<ISpeciesService>();

            this._validationService  = new ValidationService();
            this._validationService.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            this.ErrorsList.CollectionChanged += ErrorsList_CollectionChanged;

        }

        async void AddPetDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //Get the text from rich edit box
            StoryEditBox.Document.GetText(Windows.UI.Text.TextGetOptions.None, out string story);

            //Crop Image
            if(CatAvatar != null)
            {
                var croppedAvatar = await CropImage(catPhoto, AvatarCropper);
                PetInfo.PetAvatar = croppedAvatar;
            }

            PetInfo.Name = Name;
            PetInfo.Age = Age;
            PetInfo.Bio = story;
            PetInfo.BreedId = SelectedBreed.Id;
            PetInfo.OwnerGuids = _currentUserService.GetLocalUserGuidFromAppSettings();
            PetInfo.PetColor = String.Join(",", BreedColorGridView.SelectedItems.ToList());

            CreatePetCommand.Execute(PetInfo);
        }
        async void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var species = await _speciestService.GetAllAsync();
            if (species != null)
                species.ToList().ForEach(s => Species.Add(s));
            SpeciesComboBox.SelectedIndex = species.Count > 0 ? 0 : -1;
            InitializeErrors();

            await ApplicationData.Current.TemporaryFolder.DeleteAsync();
            OwnedPets = await _animalService.GetAllByUserGuidAsync(_currentUserService
                                                                        .GetLocalUserGuidFromAppSettings());
        }
        void ClearDateAndAgeButton_Click(object sender, RoutedEventArgs e)
        {
            Age = 0;
            AgeNumberBox.IsEnabled = true;
            DateOfBirthDatePicker.SelectedDate = null;
        }
        void DatePicker_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            var dateTime = sender.SelectedDate?.DateTime;
            Age = dateTime.GetAgeSupportNullDateTime();
            AgeNumberBox.IsEnabled = false;
        }
        async void AvatarUserControl_OpenFileEventHandler(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            catPhoto = await picker.PickSingleFileAsync();
            if (catPhoto != null)
            {
                await AvatarCropper.LoadImageFromFile(catPhoto);
                CatAvatar = catPhoto;
            }
        }
        async void AvatarUserControl_OpenCameraEventHandler(object sender, RoutedEventArgs e)
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
        async Task<StorageFile> CropImage(StorageFile storageFile, ImageCropper imageCropper)
        {
            var copiedStorageFile = await storageFile.CopyAsync(ApplicationData.Current.TemporaryFolder);
            using (var fileStream = await copiedStorageFile.OpenAsync(FileAccessMode.ReadWrite, StorageOpenOptions.None))
            {
                await imageCropper.SaveAsync(fileStream, BitmapFileFormat.Png);
            }
            return copiedStorageFile;
        }

        [ObservableProperty]
        Breed selectedBreed;

        partial void OnSelectedBreedChanged(Breed value)
        {
            _validationService.ClearErrors(nameof(SelectedBreed));
            ErrorsList.ToList()
                      .Where(error => error.PropId == 0)
                      .All(error => ErrorsList.Remove(error));
            if(value == null)
            {
                _validationService.AddError(nameof(SelectedBreed), "You need to select a breed type for you pet");

                var errors = GetErrors(nameof(SelectedBreed)).OfType<string>().ToList();
                errors.ForEach(error => ErrorsList.Add(new ValidationProperty(0, error)));
            }
        }

        [ObservableProperty]
        string name = string.Empty;

        partial void OnNameChanging(string value)
        {
            _validationService.ClearErrors(nameof(Name));
            ErrorsList.ToList()
                      .Where(error => error.PropId == 1)
                      .All(error => ErrorsList.Remove(error));

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                _validationService.AddError(nameof(Name), "You must provide your pet a name");

                var errors = GetErrors(nameof(Name)).OfType<string>().ToList();
                errors.ForEach(error => ErrorsList.Add(new ValidationProperty(1, error)));

            }
            else if (value.Length < 3)
            {
                _validationService.AddError(nameof(Name), "Your pet name is a little short");

                var errors = GetErrors(nameof(Name)).OfType<string>().ToList();
                errors.ForEach(error => ErrorsList.Add(new ValidationProperty(1, error)));
            }
            else if (OwnedPets.Any(pet => pet.Name == value))
            {
                _validationService.AddError(nameof(Name), $"Wait! ain't {value} is already in your profile ?");

                var errors = GetErrors(nameof(Name)).OfType<string>().ToList();
                errors.ForEach(error => ErrorsList.Add(new ValidationProperty(1, error)));
            }
        }

        [ObservableProperty]
        double age;

        partial void OnAgeChanging(double value)
        {
            _validationService.ClearErrors(nameof(Age));
            ErrorsList.ToList()
                      .Where(error => error.PropId == 2)
                      .All(error => ErrorsList.Remove(error));
            if (value > 20)
            {
                _validationService.AddError(nameof(Age), "This breed life span only from 12 to 18 years 😅");

                var errors = GetErrors(nameof(Age)).OfType<string>().ToList();
                errors.ForEach(error => ErrorsList.Add(new ValidationProperty(2, error)));
            }
        }

        [ObservableProperty]
        StorageFile catAvatar;

        partial void OnCatAvatarChanged(StorageFile value)
        {
            _validationService.ClearErrors(nameof(CatAvatar));
            ErrorsList.ToList()
                      .Where(error => error.PropId == 3)
                      .All(error => ErrorsList.Remove(error));
            if (value == null)
            {
                _validationService.AddError(nameof(CatAvatar), "You need to provide your cat an avatar !");

                var errors = GetErrors(nameof(CatAvatar)).OfType<string>().ToList();
                errors.ForEach(error => ErrorsList.Add(new ValidationProperty(3, error)));
            }
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


        void InitializeErrors()
        {
            _validationService.AddError(nameof(SelectedBreed), "How exciting what is the breed of your pet ?");
            var selectedBreederrors = GetErrors(nameof(SelectedBreed)).OfType<string>().ToList();
            selectedBreederrors.ForEach(error => ErrorsList.Add(new ValidationProperty(0, error)));

            _validationService.AddError(nameof(Name), "Give it a name ! give it a name 🤩");
            var nameErrors = GetErrors(nameof(Name)).OfType<string>().ToList();
            nameErrors.ForEach(error => ErrorsList.Add(new ValidationProperty(1, error)));


            _validationService.AddError(nameof(CatAvatar), "Someone gonna need a beautiful face");
            var catAvatarerrors = GetErrors(nameof(CatAvatar)).OfType<string>().ToList();
            catAvatarerrors.ForEach(error => ErrorsList.Add(new ValidationProperty(3, error)));
        }

        public IEnumerable GetErrors(string propertyName)
            => _validationService.GetErrors(propertyName);

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(IsPrimaryEnable));
        }

        private void ErrorsList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    var validationProp = item as ValidationProperty;
                    switch (validationProp.PropId)
                    {
                        case 0:
                            BreedErrorList.Add(validationProp);
                            break;
                        case 1:
                            NameErrorsList.Add(validationProp);
                            break;

                        case 2:
                            AgeErrorsList.Add(validationProp);
                            break;

                        case 3:
                            PetAvatarErrorsList.Add(validationProp);
                            break;
                    }
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    var validationProp = item as ValidationProperty;
                    switch (validationProp.PropId)
                    {
                        case 0:
                            BreedErrorList.Remove(validationProp);
                            break;
                        case 1:
                            NameErrorsList.Remove(validationProp);
                            break;

                        case 2:
                            AgeErrorsList.Remove(validationProp);
                            break;

                        case 3:
                            PetAvatarErrorsList.Remove(validationProp);
                            break;
                    }
                }
            }
        }

    }

    public class ValidationProperty
    {
        public int PropId { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationProperty(int propId, string errorMessage)
        {
            PropId = propId;
            ErrorMessage = errorMessage;
        }
    }

    public class ErrorListToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var errorCount = (int)value;
            return errorCount != 0 
                        ? new SolidColorBrush(Colors.Yellow) 
                        : new SolidColorBrush(Color.FromArgb(255, 146, 228, 146));
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
            return breed != null
                    ? (!string.IsNullOrEmpty(breed.Color) && breed.Color != "#ANY")
                        ? breed.Color.Split(',').ToList()
                        : null
                    : null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class BreedToBreedIdConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var breedId = (int)value;
            var breedCollection = (List<Breed>)parameter;
            return breedId != 0 ? breedCollection.FirstOrDefault(b => b.Id == breedId) : null;

            //throw new NotImplementedException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var breed = (Breed)value;
            return breed != null ? breed.Id : 0;
        }
    }

    public class SpeciesToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var species = (Species)value;
            if (species != null)
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

    public class CreatePetDTOToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var pet = (CreatePetDTO)value;
            if (pet != null)
                return (!string.IsNullOrEmpty(pet.Name) && !string.IsNullOrEmpty(pet.Bio))
                        ? true : false;
            else return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var time = (DateTime)value;
                return time != null ? time.ToUniversalTime() <= DateTimeOffset.MinValue.UtcDateTime
                                        ? DateTimeOffset.MinValue
                                        : new DateTimeOffset(time)
                                    : null;
            }
            else return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var time = (DateTimeOffset)value;
                return time != null ? time.DateTime : null;
            }
            else return null;
        }
    }
}
