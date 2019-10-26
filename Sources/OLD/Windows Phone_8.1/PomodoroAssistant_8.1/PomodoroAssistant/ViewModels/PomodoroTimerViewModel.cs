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

namespace PomodoroAssistant.ViewModels
{
    public class PomodoroTimerViewModel :INotifyPropertyChanged
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
            private set
            {
                if (_currentSettings != value)
                {
                    _currentSettings = value;
                    NotifyPropertyChanged("CurrentSettings");
                }
            }
        }


        // Aktulany czas po przeliczeniu
        private TimeSpan _currentTime;
        public TimeSpan CurrentTime
        {
            get { return _currentTime; }
            set
            {
                if (_currentTime != value)
                {
                    _currentTime = value;
                    NotifyPropertyChanged("CurrentTime");
                }
            }
        }


        // Całkowity czas który należy przeliczyć
        private TimeSpan _totalTime;
        public TimeSpan TotalTime
        {
            get { return _totalTime; }
            set
            {
                if (_totalTime != value)
                {
                    _totalTime = value;
                    NotifyPropertyChanged("TotalTime");
                }
            }
        }


        // Liczba pomodoro po jakiej nastąpi długa przerwa
        private int _longBreakAfter;
        public int LongBreakAfter
        {
            get { return _longBreakAfter; }
            set
            {
                if (_longBreakAfter != value)
                {
                    _longBreakAfter = value;
                    NotifyPropertyChanged("LongBreakAfter");
                }
            }
        }


        // Dzienny cel
        private int _dailyTarget;
        public int DailyTarget
        {
            get { return _dailyTarget; }
            set
            {
                if (_dailyTarget != value)
                {
                    _dailyTarget = value;
                    NotifyPropertyChanged("DailyTarget");
                }
            }
        }


        // Stan pomodoro - wyświetlany w interfejsie
        private string _pomodoroStateText;
        public string PomodoroStateText
        {
            get { return _pomodoroStateText; }
            set
            {
                if (_pomodoroStateText != value)
                {
                    _pomodoroStateText = value;
                    NotifyPropertyChanged("PomodoroStateText");
                }
            }
        }


        // Stan timera
        private TimerStates _currentTimerState;
        public TimerStates CurrentTimerState
        {
            get { return _currentTimerState; }
            set
            {
                if (_currentTimerState != value)
                {
                    _currentTimerState = value;
                    NotifyPropertyChanged("CurrentTimerState");
                }
            }
        }


        //
        // Konstruktor
        //
        public PomodoroTimerViewModel()
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




        //
        // Timer Start
        //
        public void TimerStart()
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


        //
        // Timer Pause
        //
        public void TimerPause()
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


        //
        // Timer Stop
        //
        public void TimerStop()
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


        /// <summary>
        /// Zeruje Liczbę pomodoro do długiej przerwy
        /// </summary>
        public void ResetLongBreakAfter()
        {
            LongBreakAfter = 0;
        }


        /// <summary>
        /// Zeruje Dzienny cel
        /// </summary>
        public void ResetDailyTarget()
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

        private static PomodoroTimerViewModel _instance = null;
        public static PomodoroTimerViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PomodoroTimerViewModel();
                }

                // Inicjuj ustawienia przed przekazaniem
                //InitSettings();

                return _instance;
            }
        }

        #endregion

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
