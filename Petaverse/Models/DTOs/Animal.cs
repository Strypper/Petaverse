
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;

namespace PetaVerse.Models.DTOs
{
    public class Animal : BaseEntity
    {
        public string   Name        { get; set; } = string.Empty;
        public string   Bio         { get; set; } = string.Empty;
        public string   PetAvatar   { get; set; } = string.Empty;
        public string   PetColor    { get; set; }
        public bool     Gender      { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int      Age         { get; set; }
        public Breed    Breed       { get; set; }
        public Species  Species     { get; set; }

        public virtual ICollection<PetaverseMedia> PetPhotos { get; set; } = new ObservableCollection<PetaverseMedia>();
    }

    public class UploadAnimalMedia
    {
        public int                      PetId { get; set; }

        public ICollection<BitmapImage> PetPhotos { get; set; } = new ObservableCollection<BitmapImage>();
    }
}
