using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;

namespace Atrx.Mobile.Windows.Pomodoro.Converters
{
    public class TimerStateToStopButtonEnabled : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isEnabled = false;
            switch ((TimerStates)value)
            {
                case TimerStates.Started:
                    isEnabled = true;
                    break;
                case TimerStates.Paused:
                    isEnabled = true;
                    break;
                case TimerStates.Stopped:
                    isEnabled = false;
                    break;
            }

            return isEnabled;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return PomodoroStates.WorkTime;
        }
    }
}
