using Windows.UI.Xaml.Data;

namespace Petaverse.UWP.Core;

public class BoolToIsFollowStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool isFollowed)
        {
            return isFollowed ? "Followed" : "Follow";
        }

        else return "Follow";
    }


    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is string isFollowString)
        {
            return isFollowString == "Followed";
        }

        else return false;
    }
}
