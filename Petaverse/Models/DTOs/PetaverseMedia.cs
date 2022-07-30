using System;
using Windows.UI.Xaml.Media.Imaging;

namespace PetaVerse.Models.DTOs
{
    public class PetaverseMedia : BaseEntity
    {
        public string       MediaUrl    { get; set; } = string.Empty;
        public DateTime     TimeUpload  { get; set; }
        public MediaType    Type        { get; set; }

        public BitmapImage  LocalImage { get; set; }
    }
    public enum MediaType
    {
        Video, Photo
    }
}
