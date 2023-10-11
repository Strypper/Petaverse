using System;
using Windows.UI.Xaml.Data;

namespace Petaverse.Converters
{
    public class BoolToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var gender = (bool)value;
            return gender == true ? "\u2642" : "\u2640";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
