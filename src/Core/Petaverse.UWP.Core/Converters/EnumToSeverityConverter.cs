namespace Petaverse.UWP.Core;

public class EnumToSeverityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var severity = (Severity)value;
        switch (severity)
        {
            case Severity.Error:
                return InfoBarSeverity.Error;

            case Severity.Warning:
                return InfoBarSeverity.Warning;

            case Severity.Informational:
                return InfoBarSeverity.Informational;

            case Severity.Success:
                return InfoBarSeverity.Success;

            default: return InfoBarSeverity.Success;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
