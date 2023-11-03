
namespace Petaverse.UWP.Core;

public class DateTimeToTimeGapConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is DateTime dateTime)
        {
            TimeSpan timeDifference = DateTime.Now - dateTime;

            if (timeDifference.TotalDays >= 365)
            {
                int years = (int)(timeDifference.TotalDays / 365);
                return new TimeGap(years, TimeGapType.Year);
            }
            else if (timeDifference.TotalDays >= 30)
            {
                int months = (int)(timeDifference.TotalDays / 30);
                return new TimeGap(months, TimeGapType.Month);
            }
            else if (timeDifference.TotalDays >= 7)
            {
                int weeks = (int)(timeDifference.TotalDays / 7);
                return new TimeGap(weeks, TimeGapType.Week);
            }
            else if (timeDifference.TotalDays >= 1)
            {
                int days = (int)timeDifference.TotalDays;
                return new TimeGap(days, TimeGapType.Day);
            }
            else if (timeDifference.TotalHours >= 1)
            {
                int hours = (int)timeDifference.TotalHours;
                return new TimeGap(hours, TimeGapType.Hour);
            }
            else if (timeDifference.TotalMinutes >= 1)
            {
                int minutes = (int)timeDifference.TotalMinutes;
                return new TimeGap(minutes, TimeGapType.Minute);
            }
            else
            {
                int seconds = (int)timeDifference.TotalSeconds;
                return new TimeGap(seconds, TimeGapType.Second);
            }
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
