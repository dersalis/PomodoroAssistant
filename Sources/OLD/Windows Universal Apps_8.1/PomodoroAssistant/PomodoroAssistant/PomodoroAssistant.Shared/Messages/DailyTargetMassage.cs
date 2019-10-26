using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Popups;

namespace PomodoroAssistant.Messages
{
    public class DailyTargetMassage
    {
        private string _title = "Gratulacje"; // Tytuł wiadomości
        private string _content = "Twój dzienny cel pomodoro został osiągnięty."; // Treść wiadomości

        private string _cancelBtnName = "Anuluj";

        public async void Show()
        {
            // Okno dialogowe
            var message = new MessageDialog(_content, _title);
            // Przycisk Anuluj
            UICommand cancelBtn = new UICommand(_cancelBtnName);
            message.CancelCommandIndex = 0;
            message.DefaultCommandIndex = 0;

            await message.ShowAsync();
        }
    }
}
