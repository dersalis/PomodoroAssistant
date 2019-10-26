using System;
using Windows.UI.Xaml.Data;

namespace Atrx.Mobile.Windows.Pomodoro.Converters
{
    public class TimeSpanToSecondStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return string.Format("{0:00}", ((TimeSpan)value).Seconds);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return new TimeSpan(0, 0, 0);
        }
    }
}
