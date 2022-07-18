using System;
using Windows.Media.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Petaverse.Converters
{
    public class StringToGlyphConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var icon = value as String;
            switch (icon)
            {
                case "CatIcon":
                    return "\U0001F408";
                case "DogIcon":
                    return "\U0001F415";
                case "FishIcon":
                    return "\U0001F41F";
                case "BirdIcon":
                    return "\U0001F426";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
