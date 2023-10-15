namespace Petaverse.UWP.Core;

public class HexToWinUIColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var hex = value as String;

        if (hex != null && !string.IsNullOrWhiteSpace(hex) && !string.IsNullOrEmpty(hex))
        {
            hex = hex.Replace("#", string.Empty).Trim();
            byte a, r, g, b;

            if (hex.Length == 8) // ARGB
            {
                a = (byte)System.Convert.ToUInt32(hex.Substring(0, 2), 16);
                r = (byte)System.Convert.ToUInt32(hex.Substring(2, 2), 16);
                g = (byte)System.Convert.ToUInt32(hex.Substring(4, 2), 16);
                b = (byte)System.Convert.ToUInt32(hex.Substring(6, 2), 16);
            }
            else // RGB
            {
                a = 255; // default value for full opacity
                r = (byte)System.Convert.ToUInt32(hex.Substring(0, 2), 16);
                g = (byte)System.Convert.ToUInt32(hex.Substring(2, 2), 16);
                b = (byte)System.Convert.ToUInt32(hex.Substring(4, 2), 16);
            }

            //get the color
            Color color = Color.FromArgb(a, r, g, b);

            return color;
        }
        return null;
    }


    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
