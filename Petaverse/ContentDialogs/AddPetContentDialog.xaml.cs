using Petaverse.Interfaces;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.FEModels;
using Petaverse.Services;
using PetaVerse.Models.DTOs;
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

namespace Petaverse.ContentDialogs
{
    [INotifyPropertyChanged]
    public sealed partial class AddPetContentDialog : ContentDialog, INotifyDataErrorInfo
    {
        public bool IsPrimaryEnable => !HasErrors;
        public bool HasErrors => _validationService.HasErrors;

        private readonly ValidationService _validationService;
        private readonly ISpeciesService _speciestService;
        private readonly ICurrentUserService _currentUserService;
        private StorageFile catPhoto;

        [ObservableProperty]
        private CreatePetDTO petInfo;

        [ObservableProperty]
        private ObservableCollection<Species>            species    = new ObservableCollection<Species>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> errorsList = new ObservableCollection<ValidationProperty>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> nameErrorsList = new ObservableCollection<ValidationProperty>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> ageErrorsList = new ObservableCollection<ValidationProperty>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> dateOfBirthErrorsList = new ObservableCollection<ValidationProperty>();

        [ObservableProperty]
        private ObservableCollection<ValidationProperty> bioErrorsList = new ObservableCollection<ValidationProperty>();


        public static readonly DependencyProperty CreatePetCommandProperty =
            DependencyProperty.Register("CreatePetCommand",
                                        typeof(IRelayCommand<CreatePetDTO>),
                                        typeof(AddPetContentDialog),
                                        new PropertyMetadata(0));

        public AddPetContentDialog()
        {
            this.InitializeComponent();
            //this.SpeciesComboBox.SelectionChanged += (sender, e) => colorStoryboard.Begin();
            this._currentUserService = Ioc.Default.GetRequiredService<ICurrentUserService>();
            this._speciestService    = Ioc.Default.GetRequiredService<ISpeciesService>();

            this._validationService  = new ValidationService();
            this._validationService.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            this.ErrorsList.CollectionChanged += ErrorsList_CollectionChanged;
        }

        void AddPetDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            PetInfo.OwnerGuids = _currentUserService.GetLocalUserGuidFromAppSettings();
            PetInfo.PetColor = String.Join(",", BreedColorGridView.SelectedItems.ToList());
            //CreatePetCommand.Execute(PetInfo);
        }

        void ClearDateAndAgeButton_Click(object sender, RoutedEventArgs e)
        {
            //PetInfo.DateOfBirth = DateTime.UtcNow;
            //PetInfo.Age = 0;

        }

        async void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var species = await _speciestService.GetAllAsync();
            if (species != null)
                species.ToList().ForEach(s => Species.Add(s));
            SpeciesComboBox.SelectedIndex = species.Count > 0 ? 0 : -1;
            //AddPetDialog.RequestedTheme = ElementTheme.Default;
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
                PetInfo.PetAvatar = catPhoto;
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

        [ObservableProperty]
        string name;

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
            else if (value.Length < 5)
            {
                _validationService.AddError(nameof(Name), "Your pet name is a little short");

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
            if (value > 50)
            {
                _validationService.AddError(nameof(Age), "Invalid price. The max product price is $50.00.");

                var errors = GetErrors(nameof(Age)).OfType<string>().ToList();
                errors.ForEach(error => ErrorsList.Add(new ValidationProperty(2, error)));
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

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
                        case 1:
                            NameErrorsList.Add(validationProp);
                            break;

                        case 2:
                            AgeErrorsList.Add(validationProp);
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
                        case 1:
                            NameErrorsList.Remove(validationProp);
                            break;

                        case 2:
                            AgeErrorsList.Remove(validationProp);
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
            var time = (DateTime)value;
            return time != null ? time.ToUniversalTime() <= DateTimeOffset.MinValue.UtcDateTime
                                    ? DateTimeOffset.MinValue
                                    : new DateTimeOffset(time)
                                : null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var time = (DateTimeOffset)value;
            return time != null ? time.DateTime : null;
        }
    }
}
