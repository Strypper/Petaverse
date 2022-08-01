using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Petaverse.Converters
{
    class FromHexToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var hex = value as String;

            if(hex != null && !string.IsNullOrWhiteSpace(hex) && !string.IsNullOrEmpty(hex))
            {
                hex = hex.Replace("#", string.Empty);
                // from #RRGGBB string
                var r = (byte)System.Convert.ToUInt32(hex.Substring(0, 2), 16);
                var g = (byte)System.Convert.ToUInt32(hex.Substring(2, 2), 16);
                var b = (byte)System.Convert.ToUInt32(hex.Substring(4, 2), 16);
                //get the color
                Color color = Color.FromArgb(155, r, g, b);

                return new SolidColorBrush(color);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
