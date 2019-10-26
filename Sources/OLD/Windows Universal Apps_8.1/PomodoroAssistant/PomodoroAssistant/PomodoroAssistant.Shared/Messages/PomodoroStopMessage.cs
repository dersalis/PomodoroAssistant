using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Popups;

namespace PomodoroAssistant.Messages
{
    public class PomodoroStopMessage
    {
        private string _content = string.Format("Wybierz 'Zatrzymaj' aby przerwać odliczanie.");
        private string _title = string.Format("Czy napewno zatrzymać czasomierz?");

        private string _cancelBtnName = "Anuluj";
        private string _pomodoroStopBtnName = "Zatrzymaj";

        private UICommandInvokedHandler _pomodoroStop;

        //
        // Konstruktor
        //
        public PomodoroStopMessage(UICommandInvokedHandler pomodoroStop)
        {
            _pomodoroStop = pomodoroStop;
        }


        //
        // Wyświetla komunikat
        //
        public async void Show()
        {
            // Okno dialogowe
            var message = new MessageDialog(_content, _title);
            // Przycisk Anuluj
            UICommand cancelBtn = new UICommand(_cancelBtnName);
            message.Commands.Add(cancelBtn);
            message.CancelCommandIndex = 0;
            message.DefaultCommandIndex = 0;
            // Przycisk Pomodoro
            UICommand pomodoroBtn = new UICommand(_pomodoroStopBtnName);
            pomodoroBtn.Invoked = _pomodoroStop;
            message.Commands.Add(pomodoroBtn);
            // Przycisk Cykl

            await message.ShowAsync();
        }
    }
}
