using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using Atrx.Mobile.Windows.Pomodoro.Settings;

namespace PomodoroAssistant.ViewModels
{
    public class PomodorSettingsViewModel : INotifyPropertyChanged
    {
        private bool _isSettingChanged; // Określa czy wprowadzono zmiany w ustawieniach

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
            WorkDuration = SettingsManager.GetSettings().WorkDuration;
            ShortBreakDuration = SettingsManager.GetSettings().ShorBreakDuration;
            LongBreakDuration = SettingsManager.GetSettings().LongBreakDuration;
            DailyTarget = SettingsManager.GetSettings().DailyTarget;
            PomodorosToLongBreak = SettingsManager.GetSettings().PomodoroToLongBreak;
            IsMuteSound = SettingsManager.GetSettings().IsMuteSound;
            IsAutoContinue = SettingsManager.GetSettings().IsAutoContinue;
        }


        //
        // Zapisuje ustawienia
        //
        public void SaveSettings()
        {
            // Sprawdz czy wprowadzono zmiany i zapisz ustawienia
            if (_isSettingChanged)
            {
                // Zapisz ustawienia
                PomodoroSettings set = new PomodoroSettings();
                set.WorkDuration = WorkDuration;
                set.ShorBreakDuration = ShortBreakDuration;
                set.LongBreakDuration = LongBreakDuration;
                set.DailyTarget = DailyTarget;
                set.PomodoroToLongBreak = PomodorosToLongBreak;
                set.IsMuteSound = IsMuteSound;
                set.IsAutoContinue = IsAutoContinue;

                SettingsManager.SetSettings(set);
                // Zmień
                _isSettingChanged = false;
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
