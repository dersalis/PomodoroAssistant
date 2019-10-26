using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

using NotificationsExtensions.ToastContent;

namespace PomodoroAssistant
{
    public static class PomodoroWindowsNotification
    {
        const string NOTIFI_SHORTBREAK = "Images/notifi_shortBreak.png";
        const string NOTIFI_LONGBREAK = "Images/notifi_longBreak.png";
        const string NOTIFI_WORK = "Images/notifi_work.png";
        const string ICON = "Images/icon_30.png";
        const String ALT_TEXT = "Placeholder image";

        private static IToastNotificationContent toastContent = null;


        public static void ShowPomodoroNotification()
        {
            string title = "Pomodoro";
            string content = "Zabierz się do pracy";
            CreateNotificatation(title, content, NOTIFI_WORK);
        }


        public static void ShowShortBreakNotification()
        {
            string title = "Krótka przerwa";
            string content = "Czas trochę odpocząć";
            CreateNotificatation(title, content, NOTIFI_SHORTBREAK);
        }


        public static void ShowLongBreakNotification()
        {
            string title = "Długa przerwa";
            string content = "Czas na dłuższy odpoczynek";
            CreateNotificatation(title, content, NOTIFI_LONGBREAK);
        }


        public static void ShowNotification(PomodoroStates.PomodoroState state)
        { 
            // Wyświetl notyfikację w zależności od stanu
            switch (state)
            { 
                case PomodoroStates.PomodoroState.Pomodoro:
                    ShowPomodoroNotification();
                    break;
                case PomodoroStates.PomodoroState.ShortBreak:
                    ShowShortBreakNotification();
                    break;
                case PomodoroStates.PomodoroState.LongBreak:
                    ShowLongBreakNotification();
                    break;
                default:
                    break;
            }
        }


        private static void CreateNotificatation(string title, string content, string image)
        {
            IToastImageAndText02 templateContent = ToastContentFactory.CreateToastImageAndText02();
            templateContent.TextHeading.Text = title;
            templateContent.TextBodyWrap.Text = content;
            templateContent.Image.Src = image;
            templateContent.Image.Alt = ALT_TEXT;
            toastContent = templateContent;

            ToastNotification toast = toastContent.CreateNotification();
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }


    }
}
