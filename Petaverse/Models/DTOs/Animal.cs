
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;

namespace PetaVerse.Models.DTOs
{
    public partial class Animal : BaseEntity
    {
        [ObservableProperty]
        string   name;
        [ObservableProperty]
        string   bio;
        [ObservableProperty]
        string   petAvatar;
        [ObservableProperty]
        string   sixDigitCode;
        [ObservableProperty]
        string   petColor;
        [ObservableProperty]
        bool     gender;
        [ObservableProperty]
        DateTime dateOfBirth;
        [ObservableProperty]
        int      age;
        [ObservableProperty]
        Breed    breed;
        [ObservableProperty]
        Species  species;

        [ObservableProperty]
        ObservableCollection<PetaverseMedia> petPhotos;
    }

    public class UploadAnimalMedia
    {
        public int                      PetId { get; set; }

        public ICollection<BitmapImage> PetPhotos { get; set; } = new ObservableCollection<BitmapImage>();
    }
}
 