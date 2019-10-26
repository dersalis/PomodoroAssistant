using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Data;
using System.Threading;

namespace PomodoroAssistantPlus.ValueConverters
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return string.Format("{0:00}:{1:00}", ((TimeSpan)value).Hours, ((TimeSpan)value).Minutes);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
