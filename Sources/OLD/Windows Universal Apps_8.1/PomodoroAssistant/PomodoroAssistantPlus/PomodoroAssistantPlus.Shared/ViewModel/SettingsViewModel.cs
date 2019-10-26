using System;
using System.Collections.Generic;
using System.Text;

using PomodoroAssistantPlus.ViewModel;
using PomodoroAssistantPlus.Model;
using PomodoroAssistantPlus.Pomodoro;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml.Media;
using Windows.UI.Popups;
using Windows.ApplicationModel.Resources;

namespace PomodoroAssistantPlus.ViewModel
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        // Ustawienia
        PomodoroSettings _settings;
        // Czas pomodoro
        public int PomodoroDuration { get; set; }
        // Czas krótkiej przerwy
        public int ShortBreakDuration { get; set; }
        // Czas długiej przerwy
        public int LongBreakDuration { get; set; }
        // Długa przerwa po
        public int LongBreadDelay { get; set; }


        //
        // Konstruktor
        //
        public SettingsViewModel()
        { 
            // Odczytaj ustawienia
            _settings = LocalStorage.SettingsStorage.GetData();
            PomodoroDuration = _settings.PomodoroDuration;
            ShortBreakDuration = _settings.ShortBreakDuration;
            LongBreakDuration = _settings.LongBreakDutation;
            LongBreadDelay = _settings.LongBreakDelay;
        }


        public void SaveSettings()
        { 
            // Przygotuj ustawienia
            _settings.PomodoroDuration = PomodoroDuration;
            _settings.ShortBreakDuration = ShortBreakDuration;
            _settings.LongBreakDutation = LongBreakDuration;
            _settings.LongBreakDelay = LongBreadDelay;

            // Dodaj i zapisz ustawienia
            LocalStorage.SettingsStorage.AddItem(_settings);
        }


        #region INotifyPropertyChanged
        // Deklaracja ReisePropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion

        #region Singleton
        //
        // Singleton
        //
        private static SettingsViewModel _instance;
        public static SettingsViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SettingsViewModel();
                return _instance;
            }
        }
        #endregion
    }
}
