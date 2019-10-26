using System;
using Windows.UI.Xaml.Data;

namespace Atrx.Mobile.Windows.Pomodoro.Converters
{
    public class TimeSpanToMinutesStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //return ((TimeSpan)value).Minutes;
            return string.Format("{0:00}", ((TimeSpan)value).Minutes);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return new TimeSpan(0, 0, 0);
        }
    }
}
