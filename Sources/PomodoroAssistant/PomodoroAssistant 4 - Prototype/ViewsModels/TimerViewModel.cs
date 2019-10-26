using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using Atrx.Mobile.Windows.Pomodoro.Settings;
using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;
using Windows.UI.Xaml;
using PomodoroAssistant.Pomodoro;
using Windows.UI.Popups;
using Atrx.Mobile.Windows.Pomodoro.Pomodoro;
using Windows.ApplicationModel.Resources;
using Atrx.Mobile.Windows.Pomodoro.Notifications;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace PomodoroAssistant.ViewModels
{
    public class TimerViewModel : ViewModelBase
    {
        private TimeSpan TIME_ONE_SECOND = new TimeSpan(0, 0, 1); // Jedna sekunda
        private TimeSpan TIME_END = new TimeSpan(0, 0, 0); // Koniec czasu

        // Timer
        private DispatcherTimer _timer = null;
        // Czas uruchomienia
        private DateTime _startTime;
        // Określa czy osiągnięto dzienny cel pomodoro
        private bool _isDailyTargetAchieved;
        // Notyfikacja
        private PomodoroToastNotification _toastNotification = null;

        // Ustawienia
        private PomodoroSettings _currentSettings = null;
        public PomodoroSettings CurrentSettings
        {
            get { return _currentSettings; }
            private set { Set<PomodoroSettings>(() => CurrentSettings, ref _currentSettings, value); }
        }


        // Aktulany czas po przeliczeniu
        private TimeSpan _currentTime;
        public TimeSpan CurrentTime
        {
            get { return _currentTime; }
            set
            {
                Set<TimeSpan>(() => CurrentTime, ref _currentTime, value);
                CurrentMinutes = string.Format("{0:00}", _currentTime.Minutes);
                CurrentSecond = string.Format("{0:00}", _currentTime.Seconds);
            }
        }


        private string _currentSecond;
        public string CurrentSecond
        {
            get { return _currentSecond; }
            set { Set<string>(() => CurrentSecond, ref _currentSecond, value); }
        }


        private string _currentMinutes;
        public string CurrentMinutes
        {
            get { return _currentMinutes; }
            set { Set<string>(() => CurrentMinutes, ref _currentMinutes, value); }
        }


        // Całkowity czas który należy przeliczyć
        private TimeSpan _totalTime;
        public TimeSpan TotalTime
        {
            get { return _totalTime; }
            set { Set<TimeSpan>(() => TotalTime, ref _totalTime, value); }
        }


        // Liczba pomodoro po jakiej nastąpi długa przerwa
        private int _longBreakAfter;
        public int LongBreakAfter
        {
            get { return _longBreakAfter; }
            set { Set<int>(() => LongBreakAfter, ref _longBreakAfter, value); }
        }


        // Dzienny cel
        private int _dailyTarget;
        public int DailyTarget
        {
            get { return _dailyTarget; }
            set { Set<int>(() => DailyTarget, ref _dailyTarget, value); }
        }


        // Stan pomodoro - wyświetlany w interfejsie
        private string _pomodoroStateText;
        public string PomodoroStateText
        {
            get { return _pomodoroStateText; }
            set { Set<string>(() => PomodoroStateText, ref _pomodoroStateText, value); }
        }


        // Stan timera
        private TimerStates _currentTimerState;
        public TimerStates CurrentTimerState
        {
            get { return _currentTimerState; }
            set { Set<TimerStates>(() => CurrentTimerState, ref _currentTimerState, value); }
        }


        //
        // Konstruktor
        //
        public TimerViewModel()
        {
            // Inicjuje ustawienia
            //InitSettings();

            //// Odczytaj ustawienia
            //CurrentSettings = SettingsManager.GetSettings();
            //// Ustaw czas
            //SetTime(PomodoroState.GetCurrentState());

            // Ustaw notyfikację tekstową
            PomodoroStateText = NotificationManager.ShowTextNotification(PomodoroState.GetCurrentState());
            // Ustaw notyfikację
            _toastNotification = InitStandartToastNotification();
            // Wyzeruj
            LongBreakAfter = 0;
            // Jeszcze nie osiągnięto celu
            _isDailyTargetAchieved = false;
            //
            CurrentTimerState = TimerStates.Stopped;
            // Przygotuj timer
            if (_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(1);
                _timer.Tick += Timer_Tick;
            }

            // Commands
            TimerStartCommand = new RelayCommand(TimerStart);
            TimerPauseCommand = new RelayCommand(TimerPause);
            TimerStopCommand = new RelayCommand(TimerStop);
            ResetDailyTargetCommand = new RelayCommand(ResetDailyTarget);
            ResetLongBreakAfterCommand = new RelayCommand(ResetLongBreakAfter);

            // TODO: Poprawić
            InitSettings();
        }


        //
        // Inicjuje ustawienia - ustawić przy starcie strony
        //
        public void InitSettings()
        {
            // Odczytaj ustawienia
            CurrentSettings = SettingsManager.GetSettings();
            // Ustaw czas
            if(TimerState.GetCurrentState() == TimerStates.Stopped)
                SetTime(PomodoroState.GetCurrentState());
        }



        public ICommand TimerStartCommand { get; private set; }
        //
        // Timer Start
        //
        private void TimerStart()
        {
            // Uruchom timer
            if (TimerState.GetCurrentState() != TimerStates.Started)
            {
                _timer.Start();
                // Zmień status
                TimerState.SetStarted();
                CurrentTimerState = TimerState.GetCurrentState();
                // Ustaw czas rozpoczęcia
                _startTime = DateTime.Now;
            }
        }


        public ICommand TimerPauseCommand { get; private set; }
        //
        // Timer Pause
        //
        private void TimerPause()
        {
            // Wstrzymaj timer
            if (TimerState.GetCurrentState() != TimerStates.Paused)
            {
                _timer.Stop();
                // Zmień stan
                TimerState.SetPaused();
                CurrentTimerState = TimerState.GetCurrentState();
                // Ustaw czas 
                TotalTime = CurrentTime;
            }
        }


        public ICommand TimerStopCommand { get; private set; }
        //
        // Timer Stop
        //
        private void TimerStop()
        {
            // Wstrzymaj timer
            if (TimerState.GetCurrentState() != TimerStates.Stopped)
            {
                _timer.Stop();
                // Zmień stan
                TimerState.SetStopped();
                CurrentTimerState = TimerState.GetCurrentState();
                // Zmień czas 
                SetTime(PomodoroState.GetCurrentState());
            }
        }


        //
        // Jednostka timera 
        //
        private void Timer_Tick(object sender, object e)
        {
            // Oblicz obecny czas
            CurrentTime = TotalTime - (DateTime.Now - _startTime);
            // Ustawienia przy usypianiu
            SuspendingManager.SetSuspendingValues((int)CurrentTime.TotalSeconds, LongBreakAfter, _currentSettings.PomodoroToLongBreak);

            // Sprawdz aktualny czas
            if (CurrentTime <= TIME_END)
            {
                // Zmień stan pomodoro
                if (PomodoroState.GetCurrentState() == PomodoroStates.WorkTime)
                {
                    // Zwieksz liczbę pomodoro do długiej przerwy
                    LongBreakAfter++;
                    // Zwiększ liczbę celi pomodoro 
                    if (_isDailyTargetAchieved == false) DailyTarget++;
                    // Zmień na przerwę
                    if (CurrentSettings.PomodoroToLongBreak == LongBreakAfter)
                    {
                        // Ustaw długą przerwę
                        PomodoroState.SetLongBreakTime();
                        // Wyzeruj
                        LongBreakAfter = 0;
                    }
                    else
                    {
                        // Ustaw krótką przerwę
                        PomodoroState.SetShortBreakTime();
                    }

                    // Sprawdz czy osiągnięto dzienny cel
                    if (_isDailyTargetAchieved == false && CurrentSettings.DailyTarget == DailyTarget)
                    {
                        _isDailyTargetAchieved = true;
                        // Wyświetl komunikat
                        ShowDailyTargetMessage();
                    }
                }
                else
                {
                    // Ustaw czas pracy
                    PomodoroState.SetWorkTime();
                }

                // Wyświetl notyfikacje tekstowę
                PomodoroStateText = NotificationManager.ShowTextNotification(PomodoroState.GetCurrentState());

                // Wyświetl notyfikację tostową jeśli nie był w stanie Suspended
                if (SuspendingManager.WasSuspending == false)
                {
                    //ToastManager.ShowToastNotification(PomodoroState.GetCurrentState());
                    _toastNotification.ShowNotification(PomodoroState.GetCurrentState());
                }
                else
                    SuspendingManager.WasSuspending = false;

                // Ustaw czasy
                SetTime(PomodoroState.GetCurrentState());
                // Zatrzymaj timer
                //TODO: Zmienić - uzależnić od ustawień
                TimerStop();
            }
            else
            {
                //if (SuspendingManager.WasSuspending == true)
                //{
                //    SuspendingManager.WasSuspending = false;
                //}
            }
        }

        private async void ShowDailyTargetMessage()
        {
            var loader = new ResourceLoader();
            string title = loader.GetString("DailyTargetMessageTitle");
            string text = loader.GetString("DailyTargetMessageText");

            MessageDialog message = new MessageDialog(text, title);
            await message.ShowAsync();
        }


        //
        // Ustawia czasy w zaleznosci od stanu pomodoro
        //
        private void SetTime(PomodoroStates currentState)
        {
            //TODO: Zmienić czasy - tylko do testów
            if (currentState == PomodoroStates.WorkTime)
                TotalTime = new TimeSpan(0, CurrentSettings.WorkDuration, 0);
            if (currentState == PomodoroStates.ShortBreakTime)
                TotalTime = new TimeSpan(0, CurrentSettings.ShorBreakDuration, 0);
            if (currentState == PomodoroStates.LongBreakTime)
                TotalTime = new TimeSpan(0, CurrentSettings.LongBreakDuration, 0);
#if DEBUG
            if (currentState == PomodoroStates.WorkTime)
                TotalTime = new TimeSpan(0, 0, CurrentSettings.WorkDuration);
            if (currentState == PomodoroStates.ShortBreakTime)
                TotalTime = new TimeSpan(0, 0, CurrentSettings.ShorBreakDuration);
            if (currentState == PomodoroStates.LongBreakTime)
                TotalTime = new TimeSpan(0, 0, CurrentSettings.LongBreakDuration);
#endif

            CurrentTime = TotalTime;
        }


        public ICommand ResetLongBreakAfterCommand { get; private set; }
        /// <summary>
        /// Zeruje Liczbę pomodoro do długiej przerwy
        /// </summary>
        private void ResetLongBreakAfter()
        {
            LongBreakAfter = 0;
        }


        public ICommand ResetDailyTargetCommand { get; private set; }
        /// <summary>
        /// Zeruje Dzienny cel
        /// </summary>
        private void ResetDailyTarget()
        {
            DailyTarget = 0;
            _isDailyTargetAchieved = false;
        }

        /// <summary>
        /// Inicjuje standartową notyfikacje
        /// </summary>
        /// <returns>Zwraca zainicjowaną standardową notyfikację</returns>
        private PomodoroStandardToastNotification InitStandartToastNotification()
        {
            var loader = new ResourceLoader();
            string workToastMsg = loader.GetString("ToastNotyficationWork");
            string shortBreakToastMsg = loader.GetString("ToastNotyficationShortBreak");
            string longBreakToastMsg = loader.GetString("ToastNotyficationLongBreak");

            return new PomodoroStandardToastNotification(workToastMsg, shortBreakToastMsg, longBreakToastMsg);
        }


        #region Singleton

        private static TimerViewModel _instance = null;
        public static TimerViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TimerViewModel();
                }

                // Inicjuj ustawienia przed przekazaniem
                //InitSettings();

                return _instance;
            }
        }

        #endregion

    }
}
