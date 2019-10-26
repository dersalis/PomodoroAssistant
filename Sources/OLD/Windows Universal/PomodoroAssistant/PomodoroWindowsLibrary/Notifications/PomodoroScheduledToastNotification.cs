using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;
using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Atrx.Mobile.Windows.Pomodoro.Notifications
{
    /// <summary>
    /// Opisuje notyfikacje uruchamianą po czasie
    /// </summary>
    public sealed class PomodoroScheduledToastNotification : PomodoroToastNotification
    {
        //
        // Zmienne lokalne
        //
        private int _time; // Czas po jakim ma zostać wywołana notyfikacja


        /// <summary>
        /// Konstruktor klasy PomodoroScheduledToastNotification
        /// </summary>
        /// <param name="workMsg">Treść wiadomości dla stanu pomodoro / pracy</param>
        /// <param name="shortBreakMsg">Treść wiadomości dla stanu krótkiej przerwy</param>
        /// <param name="longBreakMsg">Treść wiadomości dla stanu długiej przerwy</param>
        /// <param name="time">Czas po jakim ma być wywołana notyfikacja</param>
        public PomodoroScheduledToastNotification(string workMsg, string shortBreakMsg, string longBreakMsg, int time) : base(workMsg, shortBreakMsg, longBreakMsg)
        {
            // Ustaw czas
            _time = time;
        }


        /// <summary>
        /// Wyświetla notyfikacje w zależności od stanu pomodoro
        /// </summary>
        /// <param name="currentState">Aktualny stan pomodoro</param>
        public override void ShowNotification(PomodoroStates currentState)
        {
            // Ustaw szablon
            XmlDocument xmlDoc = ToastXmlDocumentSwitcher(currentState);
            // Wyświetl notyfikacje
            if (xmlDoc != null)
            {
                ShowScheduledToastNotificatoin(xmlDoc, _time);
            }
        }


        /// <summary>
        /// Wyświetla notyfikację po określonym czasie
        /// </summary>
        /// <param name="toastXml">Szablon notyfikacji</param>
        /// <param name="time">Czas po jakim wyświetlić notyfikacje</param>
        private void ShowScheduledToastNotificatoin(XmlDocument toastXml, int time)
        {
            // Utwórz notyfikacje
            ScheduledToastNotification scheduledToast = new ScheduledToastNotification(toastXml, DateTimeOffset.Now.AddSeconds(time));
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            // Wyświetl notyfikacje
            toastNotifier.AddToSchedule(scheduledToast);
        }
    }
}
