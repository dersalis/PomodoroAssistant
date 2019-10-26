using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.ApplicationModel.Resources;
using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;

namespace PomodoroAssistant.Pomodoro
{
    /*
    ******* KLASA DO USUNIĘCIA *************
    */
    //TODO: Klasa do usunięcia
    public class ToastManager
    {
        // Komunikaty notyfikacji
        private static string _workToastText = string.Empty;
        private static string _shortBreakToastText = string.Empty;
        private static string _longBreakToastText = string.Empty;


        //
        // Konstruktor
        //
        static ToastManager()
        {
            var loader = new ResourceLoader();
            _workToastText = loader.GetString("ToastNotyficationWork");
            _shortBreakToastText = loader.GetString("ToastNotyficationShortBreak");
            _longBreakToastText = loader.GetString("ToastNotyficationLongBreak");
        }


        //
        //
        //
        public static void ShowToastNotification(PomodoroStates currentState)
        {
            switch (currentState)
            {
                case PomodoroStates.WorkTime:
                    CreateToastNotification(_workToastText);
                    break;
                case PomodoroStates.ShortBreakTime:
                    CreateToastNotification(_shortBreakToastText);
                    break;
                case PomodoroStates.LongBreakTime:
                    CreateToastNotification(_longBreakToastText);
                    break;
            }
        }


        //
        //
        //
        public static void ShowScheduledToastNotification(PomodoroStates currentState, int timeInSecond)
        {
            switch (currentState)
            {
                case PomodoroStates.WorkTime:
                    CreateScheduledToastNotification(_workToastText, timeInSecond);
                    break;
                case PomodoroStates.ShortBreakTime:
                    CreateScheduledToastNotification(_shortBreakToastText, timeInSecond);
                    break;
                case PomodoroStates.LongBreakTime:
                    CreateScheduledToastNotification(_longBreakToastText, timeInSecond);
                    break;
            }
        }

        // 
        // Tworzenie notyfikacji standartowej
        //
        private static void CreateToastNotification(string toastMessage)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            var toastElement = ((XmlElement)toastXml.SelectSingleNode("/toast"));
            var toastTextElements = toastXml.GetElementsByTagName("text");
            toastElement.SetAttribute("launch", "regulararg");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(toastMessage));
      
            ToastNotification toast = new ToastNotification(toastXml);
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            toastNotifier.Show(toast);
        }
        

        //
        // Tworzenie notyfikacji zaplanowanej
        //
        private static void CreateScheduledToastNotification(string toastMessage, int timeInSecond)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            var toastElement = ((XmlElement)toastXml.SelectSingleNode("/toast"));
            var toastTextElements = toastXml.GetElementsByTagName("text");
            toastElement.SetAttribute("launch", "scheduledarg");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(toastMessage));

            ScheduledToastNotification scheduledToast = new ScheduledToastNotification(toastXml, DateTimeOffset.Now.AddSeconds(timeInSecond));
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            toastNotifier.AddToSchedule(scheduledToast);
        }
    }
}
