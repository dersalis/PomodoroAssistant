using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using Atrx.Mobile.Windows.Pomodoro.Settings;
using Atrx.Mobile.Windows.Pomodoro.Repository.SettingsLocalData;
using Atrx.Mobile.Windows.Pomodoro.Repository.Models;

namespace PomodoroAssistant.ViewModels
{
    public class PomodorSettingsViewModel : INotifyPropertyChanged
    {
        private bool _isSettingChanged; // Określa czy wprowadzono zmiany w ustawieniach
        private SettingLocalData _settingsInstance = null; // Ustawienia z zapisem do pliku

        private int _wordDuration;
        public int WorkDuration
        {
            get { return _wordDuration; }
            set
            {
                if (_wordDuration != value)
                {
                    _wordDuration = value;
                    _isSettingChanged = true;
                    NotifyPropertyChanged("WorkDuration");
                }
            }
        }

        private int _shortBreakDuration;
        public int ShortBreakDuration
        {
            get { return _shortBreakDuration; }
            set
            {
                if (_shortBreakDuration != value)
                {
                    _shortBreakDuration = value;
                    _isSettingChanged = true;
                    NotifyPropertyChanged("ShortBreakDuration");
                }
            }
        }

        private int _longBreakDuration;
        public int LongBreakDuration
        {
            get { return _longBreakDuration; }
            set
            {
                if (_longBreakDuration != value)
                {
                    _longBreakDuration = value;
                    _isSettingChanged = true;
                    NotifyPropertyChanged("LongBreakDuration");
                }
            }
        }

        private int _dailyTarget;
        public int DailyTarget
        {
            get { return _dailyTarget; }
            set
            {
                if (_dailyTarget != value)
                {
                    _dailyTarget = value;
                    _isSettingChanged = true;
                    NotifyPropertyChanged("DailyTarget");
                }
            }
        }

        private int _pomodorosToLongBreak;
        public int PomodorosToLongBreak
        {
            get { return _pomodorosToLongBreak; }
            set
            {
                if (_pomodorosToLongBreak != value)
                {
                    _pomodorosToLongBreak = value;
                    _isSettingChanged = true;
                    NotifyPropertyChanged("PomodorosToLongBreak");
                }
            }
        }

        private bool _isMuteSound;
        public bool IsMuteSound
        {
            get { return _isMuteSound; }
            set
            {
                if (_isMuteSound != value)
                {
                    _isMuteSound = value;
                    _isSettingChanged = true;
                    NotifyPropertyChanged("IsMuteSound");
                }
            }
        }

        private bool _isAutoContinue;
        public bool IsAutoContinue
        {
            get { return _isAutoContinue; }
            set
            {
                if (_isAutoContinue != value)
                {
                    _isAutoContinue = value;
                    _isSettingChanged = true;
                    NotifyPropertyChanged("IsAutoContinue");
                }
            }
        }

        //
        // Konstruktor
        //
        public PomodorSettingsViewModel()
        {
            // Ustawienia
            _settingsInstance = SettingLocalData.Instance;
            // Inicjacja 
            _isSettingChanged = false;
            // Ustaw ustawienia
            SetSettings();
        }


        //
        // Ustawia ustawienia
        //
        private void SetSettings()
        {
            // Odczyt z ustawień
            //WorkDuration = SettingsManager.GetSettings().WorkDuration;
            //ShortBreakDuration = SettingsManager.GetSettings().ShorBreakDuration;
            //LongBreakDuration = SettingsManager.GetSettings().LongBreakDuration;
            //DailyTarget = SettingsManager.GetSettings().DailyTarget;
            //PomodorosToLongBreak = SettingsManager.GetSettings().PomodoroToLongBreak;
            //IsMuteSound = SettingsManager.GetSettings().IsMuteSound;
            //IsAutoContinue = SettingsManager.GetSettings().IsAutoContinue;

            // Odczyt z pliku
            WorkDuration = _settingsInstance.GetSettings().WorkDuration;
            ShortBreakDuration = _settingsInstance.GetSettings().ShorBreakDuration;
            LongBreakDuration = _settingsInstance.GetSettings().LongBreakDuration;
            DailyTarget = _settingsInstance.GetSettings().DailyTarget;
            PomodorosToLongBreak = _settingsInstance.GetSettings().PomodoroToLongBreak;
            IsMuteSound = _settingsInstance.GetSettings().IsMuteSound;
            IsAutoContinue = _settingsInstance.GetSettings().IsAutoContinue;
        }


        //
        // Zapisuje ustawienia
        //
        public void SaveSettings()
        {
            // Sprawdz czy wprowadzono zmiany i zapisz ustawienia
            if (_isSettingChanged)
            {
                // Zmień
                _isSettingChanged = false;
                // Zapisz ustawienia
                //PomodoroSettings set = new PomodoroSettings();
                Settings set = new Settings();
                set.WorkDuration = WorkDuration;
                set.ShorBreakDuration = ShortBreakDuration;
                set.LongBreakDuration = LongBreakDuration;
                set.DailyTarget = DailyTarget;
                set.PomodoroToLongBreak = PomodorosToLongBreak;
                set.IsMuteSound = IsMuteSound;
                set.IsAutoContinue = IsAutoContinue;

                //SettingsManager.SetSettings(set);
                _settingsInstance.SetSettings(set);
            }
        }

        #region NotityPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
