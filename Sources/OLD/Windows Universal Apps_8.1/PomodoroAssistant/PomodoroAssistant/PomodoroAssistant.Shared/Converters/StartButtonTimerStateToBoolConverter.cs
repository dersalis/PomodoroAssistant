using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Data;

namespace PomodoroAssistant.Converters
{
    // Konwertuje stan przycisku Start w zależności od TimerState
    //  Started - false - niewidoczny
    //  Paused - true - widoczny
    //  Stopped - true - widoczny
    public class StartButtonTimerStateToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Przekazana wartość
            PomodoroTimer.TimerState currentValue = (PomodoroTimer.TimerState)value;
            // Jeśli ma stan Started - niewidoczne - false
            if (currentValue == PomodoroTimer.TimerState.Started)
                return false;
            // W przeciwnym razie widoczny - false
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return PomodoroTimer.TimerState.Stopped;
        }
    }
}
