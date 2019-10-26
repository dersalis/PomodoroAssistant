using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace PomodoroAssistant.Converters
{
    class CurrentPomodoroStateToColor : IValueConverter
    {
        private SolidColorBrush _greenColor = new SolidColorBrush(Color.FromArgb(255, 27, 147, 27)); // Kolor zielony
        private SolidColorBrush _redColor = new SolidColorBrush(Color.FromArgb(255, 147, 44, 27)); // Kolor czarwony

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            PomodoroStates.PomodoroState currentState = (PomodoroStates.PomodoroState)value;
            // Jeśli stan jest pomodoro to ustaw kolor czarwony
            if (currentState == PomodoroStates.PomodoroState.Pomodoro)
                return _redColor;
            // Jeśli stan jest inny niż pomodoro ustaw kolor zielony
            return _greenColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return PomodoroStates.PomodoroState.Pomodoro;
        }
    }
}
