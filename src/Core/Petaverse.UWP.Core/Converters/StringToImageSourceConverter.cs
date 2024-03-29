﻿namespace Petaverse.UWP.Core;

public class StringToImageSourceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (string.IsNullOrEmpty(value as string))
        {
            return null;
        }
        else return new BitmapImage(new Uri(value as string, UriKind.Absolute));
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
