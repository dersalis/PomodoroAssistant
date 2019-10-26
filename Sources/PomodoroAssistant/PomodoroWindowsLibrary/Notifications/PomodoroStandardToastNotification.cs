using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Atrx.Mobile.Windows.Pomodoro.Notifications
{
    /// <summary>
    /// Opisuje standartową notyfikacje
    /// </summary>
    public sealed class PomodoroStandardToastNotification : PomodoroToastNotification
    {

        /// <summary>
        /// Konstruktor klasy PomodoroStandardToastNotification
        /// </summary>
        /// <param name="workMsg">Treść wiadomości dla stanu pomodoro / pracy</param>
        /// <param name="shortBreakMsg">Treść wiadomości dla stanu krótkiej przerwy</param>
        /// <param name="longBreakMsg">Treść wiadomości dla stanu długiej przerwy</param>
        public PomodoroStandardToastNotification(string workMsg, string shortBreakMsg, string longBreakMsg) : base(workMsg, shortBreakMsg, longBreakMsg){ }


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
                ShowStandardToastNotificatoin(xmlDoc);
            }
        }


        /// <summary>
        /// Wyświetla notyfikacje standartową
        /// </summary>
        /// <param name="toastXml">Szablon notyfikacji</param>
        private void ShowStandardToastNotificatoin(XmlDocument toastXml)
        {
            // Utwórz notyfikacje
            ToastNotification toast = new ToastNotification(toastXml);
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            // Wyświetl notyfikacje
            toastNotifier.Show(toast);
        }
    }
}
