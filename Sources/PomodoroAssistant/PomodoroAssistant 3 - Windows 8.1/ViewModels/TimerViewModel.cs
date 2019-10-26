using Atrx.Mobile.Windows.Pomodoro.Notifications;
using Atrx.Mobile.Windows.Pomodoro.Pomodoro;
using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;
using Atrx.Mobile.Windows.Pomodoro.Repository.Models;
using Atrx.Mobile.Windows.Pomodoro.Repository.SettingsLocalData;
using Atrx.Mobile.Windows.Pomodoro.Repository.CurrentStateLocalData;
using Atrx.Mobile.Windows.Pomodoro.Repository.CyclesLocalData;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PomodoroAssistant.Pomodoro;
using System;
using System.Windows.Input;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace PomodoroAssistant.ViewModels
{
    public class TimerViewModel : ViewModelBase
    {
        // Stałe
        private TimeSpan TIME_ONE_SECOND = new TimeSpan(0, 0, 1); // Jednostka jednej sekundy
        private TimeSpan TIME_END = new TimeSpan(0, 0, 0); // Koniec czasu - zero sekund

        // Timer
        private DispatcherTimer _timer = null;
        // Czas uruchomienia
        private DateTime _startTime;
        // Określa czy osiągnięto dzienny cel pomodoro
        private bool _isDailyTargetAchieved;
        // Notyfikacja
        private PomodoroToastNotification _toastNotification = null;
        // Repozytorium ustawień
        private SettingLocalData _settingsInstance = null;
        // Zapisany stan programu
        private CurrentStateLocalData _currentStateInstace = null;
        // Repozytorium cykli
        private CyclesLocalData _cyclesLocalData = null;

        // Aktualny cykl
        private Cycle _currentCycle = null;

        
        // Ustawienia
        private Settings _currentSettings;
        public Settings CurrentSettings
        {
            get { return _currentSettings; }
            set { Set<Settings>(() => CurrentSettings, ref _currentSettings, value); }
        }

        // Aktulany czas po przeliczeniu
        private TimeSpan _currentTime;
        public TimeSpan CurrentTime
        {
            get { return _currentTime; }
            set { Set<TimeSpan>(() => CurrentTime, ref _currentTime, value); }
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


        /// <summary>
        /// KONSTRUKTOR
        /// </summary>
        public TimerViewModel()
        {
            // Ustaw ustawienia
            _settingsInstance = SettingLocalData.Instance;
            // Ustaw zapisany stan programu
            _currentStateInstace = CurrentStateLocalData.Instance;
            // Ustaw zapisane cykle
            _cyclesLocalData = CyclesLocalData.Instance;

            // Inicjuje ustawienia
            InitSettings();
            
            // Ustaw notyfikację tekstową
            PomodoroStateText = NotificationManager.ShowTextNotification(PomodoroState.GetCurrentState());
            // Ustaw notyfikację
            _toastNotification = InitStandartToastNotification();
            // Wyzeruj
            //LongBreakAfter = 0;
            //
            CurrentTimerState = TimerStates.Stopped;
            // Przygotuj timer
            if (_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(1);
                _timer.Tick += Timer_Tick;
            }

            // Jeszcze nie osiągnięto celu
            if (CurrentSettings.DailyTarget > DailyTarget)
                _isDailyTargetAchieved = false;

            // Ustaw Commands
            StartTimerCommand = new RelayCommand(TimerStart);
            PauseTimerCommand = new RelayCommand(TimerPause);
            StopTimerCommand = new RelayCommand(TimerStop);
            ResetDailyTargetCommand = new RelayCommand(ResetDailyTarget);
            ResetLongBreakAfterCommand = new RelayCommand(ResetLongBreakAfter);
        }


        /// <summary>
        /// Inicjuje ustawienia - ustawić przy starcie strony
        /// </summary>
        public void InitSettings()
        {
            // Odczytaj ustawienia
            CurrentSettings = _settingsInstance.GetSettings();
            // Ustaw czas
            if(TimerState.GetCurrentState() == TimerStates.Stopped)
                SetTime(PomodoroState.GetCurrentState());
        }


        public void LoadCurrentState()
        {
            _isDailyTargetAchieved = _currentStateInstace.GetState().IsDailyTargetAchived;
            DailyTarget = _currentStateInstace.GetState().DailyTarget;
            LongBreakAfter = _currentStateInstace.GetState().LongBreakAfter;
        }


        public void SaveCurrentState()
        {
            CurrentState currentState = new CurrentState()
            {
                DailyTarget = this.DailyTarget,
                LongBreakAfter = this.LongBreakAfter,
                IsDailyTargetAchived = this._isDailyTargetAchieved
            };
            _currentStateInstace.SetState(currentState);
        }


        #region Commands

        // Commands
        public ICommand StartTimerCommand { get; private set; }
        public ICommand PauseTimerCommand { get; private set; }
        public ICommand StopTimerCommand { get; private set; }
        public ICommand ResetLongBreakAfterCommand { get; private set; }
        public ICommand ResetDailyTargetCommand { get; private set; }

        
        /// <summary>
        /// Uruchamia timer
        /// </summary>
        private void TimerStart()
        {
            // Uruchom timer jeśli nie jest uruchomiony
            if (TimerState.GetCurrentState() != TimerStates.Started)
            {
                // Uruchom
                _timer.Start();
                // Zmień status
                TimerState.SetStarted();
                CurrentTimerState = TimerState.GetCurrentState();
                // Ustaw czas rozpoczęcia na obecny
                _startTime = DateTime.Now;

                // Dodaj nowy cykl
                if (PomodoroState.GetCurrentState() == PomodoroStates.WorkTime)
                {
                    _currentCycle = StartNewCycle("0");
                }
            }
        }


        /// <summary>
        /// Wstrzymaj timer
        /// </summary>
        private void TimerPause()
        {
            // Wstrzymaj timer jeśli nie jest wstrzymany
            if (TimerState.GetCurrentState() != TimerStates.Paused)
            {
                // Zatrzymaj
                _timer.Stop();
                // Zmień stan
                TimerState.SetPaused();
                CurrentTimerState = TimerState.GetCurrentState();
                // Ustaw czas 
                TotalTime = CurrentTime;
            }
        }


        /// <summary>
        /// Zatrzymaj timer
        /// </summary>
        private void TimerStop()
        {
            // Wstrzymaj timer jeśli nie jest zatrzymany
            if (TimerState.GetCurrentState() != TimerStates.Stopped)
            {
                // Zatrzymaj
                _timer.Stop();
                // Zmień stan
                TimerState.SetStopped();
                CurrentTimerState = TimerState.GetCurrentState();
                // Zmień czas 
                SetTime(PomodoroState.GetCurrentState());

                // Zakończ aktualny cykl
                if (_currentCycle != null)
                {
                    _currentCycle = null;
                }
            }
        }


        /// <summary>
        /// Zeruje Liczbę pomodoro do długiej przerwy
        /// </summary>
        private void ResetLongBreakAfter()
        {
            if (TimerState.GetCurrentState() == TimerStates.Stopped)
            {
                // Ustaw zero
                LongBreakAfter = 0;
            }
            else
                TimerMessages.ShowSettingsMessage();
        }


        /// <summary>
        /// Zeruje Dzienny cel
        /// </summary>
        private void ResetDailyTarget()
        {
            if (TimerState.GetCurrentState() == TimerStates.Stopped)
            {
                // Ustaw zero
                DailyTarget = 0;
                _isDailyTargetAchieved = false;
            }
            else
                TimerMessages.ShowSettingsMessage();
        }

        #endregion


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
                    // Zakończ aktualny cykl
                    if (_currentCycle != null)
                    {
                        FinihCycle(_currentCycle);
                        _currentCycle = null;
                    }

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
                        //ShowDailyTargetMessage();
                        TimerMessages.ShowDailyTargetMessage();
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


        /// <summary>
        /// Ustawia czas w zaleznosci od stanu pomodoro
        /// </summary>
        /// <param name="currentState"></param>
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


        /// <summary>
        /// Tworzy nowy cykl
        /// </summary>
        /// <param name="tasktId">Id zadania powiązanego z cyklem</param>
        /// <returns></returns>
        private Cycle StartNewCycle(string tasktId)
        {
            // Utwórz nowe zadanie
            Cycle cycle = new Cycle() { Id = "0", TaskId = tasktId, StartDate = DateTime.Now };
            // Zwróć zadanie
            return cycle;
        }


        /// <summary>
        /// Kończy oraz dodaje cykl do bazy
        /// </summary>
        /// <param name="currentCycle">Aktualny cykl</param>
        private void FinihCycle(Cycle currentCycle)
        {
            // Zakończ zadanie
            currentCycle.SetAsFinished();
            // Dodaj cykl
            _cyclesLocalData.AddCycle(currentCycle);
        }

    }



    /// <summary>
    /// Opisuje wiadomości
    /// </summary>
    class TimerMessages
    {
        private static ResourceLoader loader = new ResourceLoader();

        private const string DAILY_TARGET_TITLE = "DailyTargetMessageTitle";
        private const string DAILY_TARGET_TEXT = "DailyTargetMessageText";

        private const string SETTINGS_TITLE = "SettingMessageTitle";
        private const string SETTINGS_TEXT = "SettingMessageText";


        /// <summary>
        /// Wyświetl wiadomość o dziennym celu
        /// </summary>
        public static void ShowDailyTargetMessage()
        {
            // Utwórz i wyświetl wiadomość
            ShowMessage(DAILY_TARGET_TITLE, DAILY_TARGET_TEXT);
        }


        /// <summary>
        /// Wyświetl wiadomość o ustawieniach
        /// </summary>
        public static void ShowSettingsMessage()
        {
            // Utwórz i wyświetl wiadomość
            ShowMessage(SETTINGS_TITLE, SETTINGS_TEXT);
        }


        /// <summary>
        /// Tworzy i wyświetla wiadomość
        /// </summary>
        /// <param name="title">Tytuł wiadomości</param>
        /// <param name="text">Treść wiadomości</param>
        private static async void ShowMessage(string title, string text)
        {
            string msgTitle = loader.GetString(title);
            string msgText = loader.GetString(text);
            // Przygotuj wiadomość
            MessageDialog message = new MessageDialog(msgText, msgTitle);
            // Wyświetl wiadomość
            await message.ShowAsync();
        }
    }
}
