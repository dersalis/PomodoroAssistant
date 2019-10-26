﻿using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Data;

namespace PomodoroAssistant.Converters
{
    public class CurrentTimeToMinutesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Pobrany czas
            TimeSpan currentTime = (TimeSpan)value;
            string returnTime = string.Format("{0:00}", currentTime.Minutes);
            return returnTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
