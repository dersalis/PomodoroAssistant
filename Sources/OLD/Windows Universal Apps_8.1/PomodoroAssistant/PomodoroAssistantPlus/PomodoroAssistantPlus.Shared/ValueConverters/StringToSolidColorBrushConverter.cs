using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using PomodoroAssistantPlus.Pomodoro;

namespace PomodoroAssistantPlus.ValueConverters
{
    public class StringToSolidColorBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush strToScb = new SolidColorBrush(((string)value).ToColor());
            return strToScb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string scbToStr = ((SolidColorBrush)value).Color.ToString();
            return scbToStr;
        }
    }
}
