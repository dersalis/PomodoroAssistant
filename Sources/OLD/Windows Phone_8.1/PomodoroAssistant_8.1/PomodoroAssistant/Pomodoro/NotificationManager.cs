using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;

namespace PomodoroAssistant.Pomodoro
{
    public static class NotificationManager
    {
        // Komunikaty wypisywane 
        private static string _workText = string.Empty;
        private static string _shortBreakText = string.Empty;
        private static string _longBreakText = string.Empty;

        // Komunikaty wiadomości
        private static string _dailyTargetMessageTitle = string.Empty;
        private static string _dailyTargetMessageContent = string.Empty;

        //
        // Konstruktor
        //
        static NotificationManager()
        {
            var loader = new ResourceLoader();
            _workText = loader.GetString("NotyficationWorkText");
            _shortBreakText = loader.GetString("NotyficationShortBreakText");
            _longBreakText = loader.GetString("NotyficationLongBreakText");
        }


        //
        // Wyświetla notyfikacje
        //
        public static string ShowTextNotification(PomodoroStates currentState)
        {
            //TODO: Dodać Tosty
            string message = string.Empty;
            switch (currentState)
            {
                case PomodoroStates.WorkTime:
                    message = ShowWorkNotification();
                    break;
                case PomodoroStates.ShortBreakTime:
                    message = ShowShortBreakNotification();
                    break;
                case PomodoroStates.LongBreakTime:
                    message = ShowLongBreakNotification();
                    break;
            }

            return message;
        }

        //
        //
        //
        private static string ShowWorkNotification()
        {
            return _workText;
        }


        //
        // 
        //
        private static string ShowShortBreakNotification()
        {
            return _shortBreakText;
        }


        //
        // 
        //
        private static string ShowLongBreakNotification()
        {
            return _longBreakText;
        }

    }
}
