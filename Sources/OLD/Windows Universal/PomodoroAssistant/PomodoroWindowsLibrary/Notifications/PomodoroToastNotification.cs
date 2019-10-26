using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Atrx.Mobile.Windows.Pomodoro.Notifications
{
    /// <summary>
    /// Klasa abstrakcyjna implementująca metody dla kalas PomodoroStandardToastNotification i PomodoroScheduledNotification
    /// </summary>
    public abstract class PomodoroToastNotification
    {
        //
        // Zmienne lokalne
        //
        protected string _workToastMessage; // Treść wiadomości dla stanu pomodoro / pracy
        protected string _shortBreakToastMessage; // Treść wiadomości dla stanu krótkiej przerwy
        protected string _longBreakToastMessage; // Treść wiadomości dla stanu długiej przerwy


        /// <summary>
        /// Konstruktor klasy PomodoroToastNotification
        /// </summary>
        /// <param name="wMsg">Treść wiadomości dla stanu pomodoro / pracy</param>
        /// <param name="sBMsg">Treść wiadomości dla stanu krótkiej przerwy</param>
        /// <param name="lBText">Treść wiadomości dla stanu długiej przerwy</param>
        public PomodoroToastNotification(string wMsg, string sBMsg, string lBText)
        {
            // Deklaracja zmiennych lokalnych
            _workToastMessage = wMsg;
            _shortBreakToastMessage = sBMsg;
            _longBreakToastMessage = lBText;
        }


        /// <summary>
        /// Metoda abstrakcyjna wywołująca notyfikację
        /// </summary>
        /// <param name="currentState">Aktualny stan pomodoro</param>
        public abstract void ShowNotification(PomodoroStates currentState);


        /// <summary>
        /// Tworzy szablon notyfikacji
        /// </summary>
        /// <param name="toastMessage">Tekst wyświetlany w notyfikacji</param>
        /// <returns>Szablon notyfikacji</returns>
        private XmlDocument CreateToastXmlDocument(string toastMessage)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            var toastElement = ((XmlElement)toastXml.SelectSingleNode("/toast"));
            var toastTextElements = toastXml.GetElementsByTagName("text");
            toastElement.SetAttribute("launch", "regulararg");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Pomodoro Assistant"));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(toastMessage));
            // Zwróć szablon notyfidacji
            return toastXml;
        }


        /// <summary>
        /// Ustawia szablon notyfikacji w zależności od stanu pomodoro
        /// </summary>
        /// <param name="currentState">Aktualny stan pomodoro</param>
        /// <returns>Szablon notyfikacji</returns>
        protected XmlDocument ToastXmlDocumentSwitcher(PomodoroStates currentState)
        {
            // Szablon notyfikacji
            XmlDocument xmlDoc = null;
            // Sprawdz stan
            switch (currentState)
            {
                // Stan - Praca
                case PomodoroStates.WorkTime:
                    xmlDoc = CreateToastXmlDocument(_workToastMessage);
                    break;
                // Stan - krótka przerwa
                case PomodoroStates.ShortBreakTime:
                    xmlDoc = CreateToastXmlDocument(_shortBreakToastMessage);
                    break;
                // Stan - długa przerwa
                case PomodoroStates.LongBreakTime:
                    xmlDoc = CreateToastXmlDocument(_longBreakToastMessage);
                    break;
            }
            // Zwróć gotowy szablon
            return xmlDoc;
        }
    }
}
