using Atrx.Mobile.Windows.Pomodoro.Settings;
using GalaSoft.MvvmLight;
using Atrx.Mobile.Windows.Pomodoro.Repository.SettingsLocalData;
using Atrx.Mobile.Windows.Pomodoro.Repository.Models;

namespace PomodoroAssistant.ViewsModels
{
    public class SettingsViewModel : ViewModelBase
    {
        // Baza ustawień
        private SettingLocalData _settingsLocalData;
        // Określa czy wprowadzono zmiany w ustawieniach
        private bool _isSettingChanged; 

        private int _wordDuration;
        public int WorkDuration
        {
            get { return _wordDuration; }
            set
            {
                Set<int>(() => WorkDuration, ref _wordDuration, value);
                _isSettingChanged = true;
            }
        }

        private int _shortBreakDuration;
        public int ShortBreakDuration
        {
            get { return _shortBreakDuration; }
            set
            {
                Set<int>(() => ShortBreakDuration, ref _shortBreakDuration, value);
                _isSettingChanged = true;
            }
        }

        private int _longBreakDuration;
        public int LongBreakDuration
        {
            get { return _longBreakDuration; }
            set
            {
                Set<int>(() => LongBreakDuration, ref _longBreakDuration, value);
                _isSettingChanged = true;
            }
        }

        private int _dailyTarget;
        public int DailyTarget
        {
            get { return _dailyTarget; }
            set
            {
                Set<int>(() => DailyTarget, ref _dailyTarget, value);
                _isSettingChanged = true;
            }
        }

        private int _pomodorosToLongBreak;
        public int PomodorosToLongBreak
        {
            get { return _pomodorosToLongBreak; }
            set
            {
                Set<int>(() => PomodorosToLongBreak, ref _pomodorosToLongBreak, value);
                _isSettingChanged = true;
            }
        }

        private bool _isMuteSound;
        public bool IsMuteSound
        {
            get { return _isMuteSound; }
            set
            {
                Set<bool>(() => IsMuteSound, ref _isMuteSound, value);
                _isSettingChanged = true;
            }
        }

        private bool _isAutoContinue;
        public bool IsAutoContinue
        {
            get { return _isAutoContinue; }
            set
            {
                Set<bool>(() => IsAutoContinue, ref _isAutoContinue, value);
                _isSettingChanged = true;
            }
        }


        //
        // Konstruktor
        //
        public SettingsViewModel()
        {
            // Inicjacja 
            _settingsLocalData = SettingLocalData.Instance;
            _isSettingChanged = false;
            // Ustaw ustawienia
            SetSettings();
        }


        /// <summary>
        /// Ustawia ustawienia
        /// </summary>
        private void SetSettings()
        {
            WorkDuration = _settingsLocalData.GetSettings().WorkDuration;
            ShortBreakDuration = _settingsLocalData.GetSettings().ShorBreakDuration;
            LongBreakDuration = _settingsLocalData.GetSettings().LongBreakDuration;
            DailyTarget = _settingsLocalData.GetSettings().DailyTarget;
            PomodorosToLongBreak = _settingsLocalData.GetSettings().PomodoroToLongBreak;
            IsMuteSound = _settingsLocalData.GetSettings().IsMuteSound;
            IsAutoContinue = _settingsLocalData.GetSettings().IsAutoContinue;
        }


        /// <summary>
        /// Zapisuje ustawienia
        /// </summary>
        public void SaveSettings()
        {
            // Sprawdz czy wprowadzono zmiany i zapisz ustawienia
            if (_isSettingChanged)
            {
                // Zapisz ustawienia
                Settings set = new Settings();
                set.WorkDuration = WorkDuration;
                set.ShorBreakDuration = ShortBreakDuration;
                set.LongBreakDuration = LongBreakDuration;
                set.DailyTarget = DailyTarget;
                set.PomodoroToLongBreak = PomodorosToLongBreak;
                set.IsMuteSound = IsMuteSound;
                set.IsAutoContinue = IsAutoContinue;
                // Zapisz ustawienia
                _settingsLocalData.SetSettings(set);
                // Zmień
                _isSettingChanged = false;
            }
        }
    }
}
