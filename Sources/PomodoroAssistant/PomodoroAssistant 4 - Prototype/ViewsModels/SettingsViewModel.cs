using Atrx.Mobile.Windows.Pomodoro.Settings;
using GalaSoft.MvvmLight;

namespace PomodoroAssistant.ViewsModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private bool _isSettingChanged; // Określa czy wprowadzono zmiany w ustawieniach

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
            _isSettingChanged = false;
            // Ustaw ustawienia
            SetSettings();
        }


        /// <summary>
        /// Ustawia ustawienia
        /// </summary>
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


        /// <summary>
        /// Zapisuje ustawienia
        /// </summary>
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
    }
}
