using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Data;

namespace PomodoroAssistant.Converters
{
    // Określa widoczność przycisku Stop w zależności od TimerState
    // Started - true - widoczny
    // Paused - true - widoczny
    // Stopped - false - niewidoczny
    public class StopButtonTimerStateToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Pobrana wartość
            PomodoroTimer.TimerState currentState = (PomodoroTimer.TimerState)value;
            // Jeśli stan Stopped - zwróć false
            if (currentState == PomodoroTimer.TimerState.Stopped)
                return false;
            // Przeciwnym przypadku - zwróć true.
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return PomodoroTimer.TimerState.Stopped;
        }
    }
}
