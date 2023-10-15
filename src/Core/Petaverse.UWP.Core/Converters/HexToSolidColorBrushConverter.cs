namespace Petaverse.UWP.Core;

public class HexToSolidColorBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var hex = value as String;

        if (hex != null && !string.IsNullOrWhiteSpace(hex) && !string.IsNullOrEmpty(hex))
        {
            hex = hex.Replace("#", string.Empty).Trim();
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
