using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Petaverse.Models.DTOs
{
    public partial class Animal : BaseEntity
    {
        [ObservableProperty]
        string   name;
        [ObservableProperty]
        string   bio;
        [ObservableProperty]
        string   sixDigitCode;
        [ObservableProperty]
        string   petColor;
        [ObservableProperty]
        bool     gender;
        [ObservableProperty]
        DateTime dateOfBirth;
        [ObservableProperty]
        double   age;
        [ObservableProperty]
        Breed    breed;

        [ObservableProperty]
        PetaverseMedia petAvatar;

        [ObservableProperty]
        ObservableCollection<PetaverseMedia> petPhotos;
    }

    public class UploadAnimalMedia
    {
        public int                      PetId { get; set; }

        public ICollection<BitmapImage> PetPhotos { get; set; } = new ObservableCollection<BitmapImage>();
    }

    public enum AnimalSize
    {
        Tiny, Small, Medium, MediumLarge, Large
    }

    public enum Shedding
    {
        None, Minimal, Medium, Heavy
    }

    public enum Coat
    {
        Short, Medium, Long
    }

    public enum Energy
    {
        Low, Medium, Energy
    }
}
 