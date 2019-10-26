using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Data;

namespace PomodoroAssistant.Converters
{
    // Ustala stan przycisku Pauza
    // Started - true - widoczny
    // Paused  - false - niewidoczny
    // Stopped  - false - niewidoczny
    public class PauseButtonTimerStateToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Przekazana wartość
            PomodoroTimer.TimerState currentValue = (PomodoroTimer.TimerState)value;
            // Jeśli stan jest Started - widoczny - true
            if (currentValue == PomodoroTimer.TimerState.Started)
                return true;
            // W przeciwnym wypadku - niewidoczny
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return PomodoroTimer.TimerState.Stopped;
        }
    }
}
