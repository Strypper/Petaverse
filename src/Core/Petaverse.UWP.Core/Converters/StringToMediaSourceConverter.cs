namespace Petaverse.UWP.Core;

public class StringToMediaSourceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var videoUrl = value as String;
        return videoUrl != null ? videoUrl != "" ? MediaSource.CreateFromUri(new Uri(videoUrl)) : null : null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
