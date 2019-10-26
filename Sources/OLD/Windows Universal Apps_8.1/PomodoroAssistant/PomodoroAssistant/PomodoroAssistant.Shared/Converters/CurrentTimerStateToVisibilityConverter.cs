using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace PomodoroAssistant.Converters
{
    public class CurrentTimerStateToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            PomodoroTimer.TimerState currentState = (PomodoroTimer.TimerState)value;
            if (currentState == PomodoroTimer.TimerState.Stopped)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return PomodoroTimer.TimerState.Stopped;
        }
    }
}
