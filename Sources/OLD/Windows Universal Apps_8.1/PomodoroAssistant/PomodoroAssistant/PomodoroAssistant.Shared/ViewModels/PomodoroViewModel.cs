using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace PomodoroAssistant.ViewModels
{
    public class PomodoroViewModel : INotifyPropertyChanged
    {
        //
        // KONSTRUKTOR
        //
        public PomodoroViewModel()
        {
            // Zainicjuj wartości
            SetInitialState();
        }


        #region Właściwości Pomodoro

        // Określa aktualny stan pomodoro: Pomodoro / ShortBreak / LongBreak
        private PomodoroStates.PomodoroState _currentPomodoroState;
        public PomodoroStates.PomodoroState CurrentPomodoroState
        {
            get { return _currentPomodoroState;}
            set
            {
                if (_currentPomodoroState != value)
                {
                    _currentPomodoroState = value;
                    NotifyPropertyChanged("CurrentPomodoroState");
                }
            }
        }

        // Komunikat o stanie Pomodoro - wyświetlany w programie: Pomodoro / Short break / Long break
        private string _pomodoroStateContent;
        public string PomodoroStateContent
        {
            get { return _pomodoroStateContent; }
            set
            {
                if (_pomodoroStateContent != value)
                {
                    _pomodoroStateContent = value;
                    NotifyPropertyChanged("PomodoroStateContent");
                }
            }
        }

        // Czas pomodoro
        private TimeSpan _pomodoroTime;

        // Czas krótkiej przerwy
        private TimeSpan _shortBreakTime;

        // Czas długiej przerwy
        private TimeSpan _longBreakTime;

        // Liczba pomodoro po jakiej nastąpi długa przewa
        private int _currentPomodorosToLongBreak;
        public int CurrentPomodorosToLongBreak
        {
            get { return _currentPomodorosToLongBreak; }
            set
            {
                if (_currentPomodorosToLongBreak != value)
                {
                    _currentPomodorosToLongBreak = value;
                    NotifyPropertyChanged("CurrentPomodorosToLongBreak");
                }
            }
        }

        // Dzienny cel pomodoro
        private int _currentPomodorosDailyTarget;
        public int CurrentPomodorosDailyTarget
        {
            get { return _currentPomodorosDailyTarget; }
            set
            {
                if (_currentPomodorosDailyTarget != value)
                {
                    _currentPomodorosDailyTarget = value;
                    NotifyPropertyChanged("CurrentPomodorosDailyTarget");
                }
            }
        }
 
        #endregion

        #region Ustawienia

        // Ustawienie czasu pomodoro
        private int _setPomodoroTime;
        public int SetPomodoroTime
        {
            get { return _setPomodoroTime; }
            set
            {
                if (_setPomodoroTime != value)
                { 
                    // Ustaw wartość
                    _setPomodoroTime = value;
                    // Ustaw czas
                    //TODO Zmienić ustawienia czasu POMODOROTIME
                    _pomodoroTime = new TimeSpan(0, 0, _setPomodoroTime);
                    // Odśwież timer
                    RefreshTimer();
                    //
                    PomodoroSettings.SavePomodoroTime(value);
                    NotifyPropertyChanged("SetPomodoroTime");
                }
            }
        }

        // Ustawienie czasu krótkier przerwy
        private int _setShortBreakTime;
        public int SetShortBreak
        {
            get { return _setShortBreakTime; }
            set
            {
                if (_setShortBreakTime != value)
                { 
                    // Ustaw wartość 
                    _setShortBreakTime = value;
                    // Ustaw czas
                    //TODO Zmienić ustawienia czasu SHORTBREAKTIME
                    _shortBreakTime = new TimeSpan(0, 0, _setShortBreakTime);
                    // Odświerz timer
                    RefreshTimer();
                    // 
                    PomodoroSettings.SaveShortBreakTime(value);
                    NotifyPropertyChanged("SetShortbreak");
                }
            }
        }

        // Ustawienie czasu długiej przerwy
        private int _setLongBreakTime;
        public int SetLongBreakTime
        {
            get { return _setLongBreakTime; }
            set
            {
                if (_setLongBreakTime != value)
                { 
                    // Ustaw wartość
                    _setLongBreakTime = value;
                    // Ustaw czas
                    //TODO Zmienić ustawienia czasu SETLONGBREAKTIME
                    _longBreakTime = new TimeSpan(0, 0, _setLongBreakTime);
                    // Odśwież timer
                    RefreshTimer();
                    //
                    PomodoroSettings.SaveLongBreakTime(value);
                    NotifyPropertyChanged("SetLongBreakTime");
                }
            }
        }

        // Liczba pomodoro po jakiej nastąpi długa przewa
        private int _setPomodorosToLongBreak;
        public int SetPomodorosToLongBreak
        {
            get { return _setPomodorosToLongBreak; }
            set
            {
                if (_setPomodorosToLongBreak != value)
                {
                    _setPomodorosToLongBreak = value;
                    PomodoroSettings.SavePomodorosToLongBreak(value);
                    NotifyPropertyChanged("SetPomodorosToLongBreak");
                }
            }
        }

        // Dzienny cel pomodoro
        private int _setPomodorosDailyTarge;
        public int SetPomodorosDailyTarget
        {
            get { return _setPomodorosDailyTarge; }
            set
            {
                if (_setPomodorosDailyTarge != value)
                {
                    // Jeśli wprowadzone ustawienie dziennego celu jest większe od aktualnego celu 
                    // to odblokuj wyświetlanie komunikatu
                    if (_setPomodorosDailyTarge < value)
                        _isDailyTargetAchived = false;
                    _setPomodorosDailyTarge = value;
                    PomodoroSettings.SaveDailyTarget(value);
                    NotifyPropertyChanged("SetPomodorosDailyTarget");
                }
            }
        }

        
        // Określa czy wyświetlono komunikat o zaliczeniu dziennego limitu
        private bool _isDailyTargetAchived = false;

        //
        // Odświeża wartość timera
        //
        private void RefreshTimer()
        { 
            // Sprawdz stan pomodoro
            // W zależności od stanu pomodoro ustaw aktualny czas
            switch (CurrentPomodoroState)
            { 
                case PomodoroStates.PomodoroState.Pomodoro:
                    CurrentTime = _pomodoroTime;
                    break;
                case PomodoroStates.PomodoroState.ShortBreak:
                    CurrentTime = _shortBreakTime;
                    break;
                case PomodoroStates.PomodoroState.LongBreak:
                    CurrentTime = _longBreakTime;
                    break;
                default:
                    CurrentTime = _pomodoroTime;
                    break;
            }
        }


        //
        // Odczytuje ustawienia z dysku
        //
        private void LoadSettings()
        {
            //TODO Tymczasowe rozwiązanie metody LoadSettings();
            SetPomodoroTime = PomodoroSettings.LoadPomodoroTime();
            SetShortBreak = PomodoroSettings.LoadShortBreakTime();
            SetLongBreakTime = PomodoroSettings.LoadLongBreakTime();
            SetPomodorosToLongBreak = PomodoroSettings.LoadPomodorosToLongBreak();
            SetPomodorosDailyTarget = PomodoroSettings.LoadDailyTarget();
        }

        #endregion

        #region Timer

        // Aktualny czas wskazywany przez timer
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


        // Aktualny stan timera - Started / Stopped / Paused
        private PomodoroTimer.TimerState _currentTimerState;
        public PomodoroTimer.TimerState CurrentTimerState
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

        // Timer pomodoro
        private PomodoroTimer _pomodoroTimer;
        
        // Tworzy timer
        private void CreateTimer()
        {
            // Utwórz timer
            _pomodoroTimer = new PomodoroTimer(PomodoroTimer_Tick);
        }


        //
        // Timer
        //
        private void PomodoroTimer_Tick(object sender, object e)
        {
            // Zmniejsz stan czasomierza o 1 sec.
            CurrentTime -= PomodoroTimer.ONE_SECOND;

            // Zmień wartość paska postępu
            TimerBar = SetTimerBar(CurrentTime, CurrentPomodoroState);

            // Jeśli czas dobiegł końca i jest równy 0 to
            if (CurrentTime < PomodoroTimer.ZERO_SECONDS)
            { 
                // Zmień stan pomodoro
                // Jeśli aktualny stan to Pomodoro
                if (CurrentPomodoroState == PomodoroStates.PomodoroState.Pomodoro)
                { 
                    // Zwiększ liczbę pomodoro do długiej przerwy
                    CurrentPomodorosToLongBreak++;

                    // Jeśli dzienny cel pomodoro nie został osiągnięty
                    if (_isDailyTargetAchived == false)
                    {
                        // Zwiększ aktualny dzienny cel pomodoro
                        CurrentPomodorosDailyTarget++;
                        // Sprawdź czy osiągnięto dzienny cel pomodoro
                        if (CurrentPomodorosDailyTarget == SetPomodorosDailyTarget)
                        {
                            // Wyświetl komunikat
                            Messages.DailyTargetMassage dailyTargetMessage = new Messages.DailyTargetMassage();
                            dailyTargetMessage.Show();
                            // Dzienny cel został osiągnięty
                            _isDailyTargetAchived = true;
                        }
                    }
                    // Sprawdź aktualną liczbę wykonanych pomodoro wymaganych do długiej przerwy
                    // Jeśli liczby te są sobie równe to zmień stan długą przerwę
                    if (CurrentPomodorosToLongBreak == SetPomodorosToLongBreak)
                    {
                        // Ustaw stan na longbreak
                        CurrentPomodorosToLongBreak = 0;
                        ChangeState(PomodoroStates.PomodoroState.LongBreak);
                    }
                    // W przeciwnym przypadku zmień stan na krótką przerwę
                    else
                    { 
                        // Ustaw stan na shortbreak
                        ChangeState(PomodoroStates.PomodoroState.ShortBreak);
                    }

                }
                // Jeśli aktyalny stan to ShortBreak lub LongBreak (przerwa) to zmień stan na pomodoro
                else
                {
                    // Ustaw stan na pomodoro
                    ChangeState(PomodoroStates.PomodoroState.Pomodoro);
                }

                // Zatrzymaj stoper i zmień stan
                CurrentTimerState = _pomodoroTimer.Stop();

                // Ustaw pasek postępu
                TimerBar = SetTimerBar(CurrentTime, CurrentPomodoroState);
            }
        }


        // 
        // Zmień stan 
        //
        private void ChangeState(PomodoroStates.PomodoroState newState)
        { 
            // Ustaw nowy stan
            CurrentPomodoroState = newState;
            // ustaw licznik czasomierza - zależy od stanu pomodoro
            RefreshTimer();
            // Wyswietl notyfikację
            PomodoroWindowsNotification.ShowNotification(CurrentPomodoroState);
            // Zmień komunikat
            ChangePomodoroStateContent(newState);
        }


        //
        // Zmienia komunikat
        //
        private void ChangePomodoroStateContent(PomodoroStates.PomodoroState state)
        {
            switch (state)
            { 
                case PomodoroStates.PomodoroState.Pomodoro:
                    PomodoroStateContent = "pomodoro";
                    break;
                case PomodoroStates.PomodoroState.ShortBreak:
                    PomodoroStateContent = "short break";
                    break;
                case PomodoroStates.PomodoroState.LongBreak:
                    PomodoroStateContent = "long break";
                    break;
                default :
                    break;
            }
        }


        // Pasek postępu Timera
        private int _timerBar = 0;
        public int TimerBar
        {
            get { return _timerBar; }
            set
            {
                if (_timerBar != value)
                {
                    _timerBar = value;
                    NotifyPropertyChanged("TimerBar");
                }
            }
        }


        //
        // Ustawia TimerBar
        //
        private int SetTimerBar(TimeSpan currentTime, PomodoroStates.PomodoroState currentState)
        {
            int totTime = 0; // Całkowity czas zależny do stanu
            int currTime = currentTime.Seconds; // Aturalny czas
            int totLenght = 370; // Całkowita długość paska
            int currLentht = 0; // Aktualna długość - zwracana

            // Ustaw totTime
            if (currentState == PomodoroStates.PomodoroState.Pomodoro) totTime = _pomodoroTime.Seconds;
            if (currentState == PomodoroStates.PomodoroState.LongBreak) totTime = _longBreakTime.Seconds;
            if (currentState == PomodoroStates.PomodoroState.ShortBreak) totTime = _shortBreakTime.Seconds;

            // Oblicz długość
            currLentht = totLenght * currTime / totTime;
            if (currLentht >= 0)
                return currLentht;
            return 0;
        }

        #endregion

        #region Obsługa przycisków

        //
        // Uruchom timer
        //
        private bool _timerStartCanExecute = true;
        private ICommand _timerStartCommand;
        public ICommand TimerStartCommand
        {
            get { return _timerStartCommand ?? (_timerStartCommand = new CommandHandler(() => TimerStart(), _timerStartCanExecute)); }
        }
        // Polecenia wykonywane po naciśnięciu przycisku
        private void TimerStart()
        { 
            // Uruchom i zmień stan timera
            CurrentTimerState = _pomodoroTimer.Start();
        }


        //
        // Wstrzymaj timer
        //
        private bool _timerPauseCanExecute = true;
        private ICommand _timerPauseCommand;
        public ICommand TimerPauseCommand
        {
            get { return _timerPauseCommand ?? (_timerPauseCommand = new CommandHandler(() => TimerPause(), _timerPauseCanExecute)); }
        }
        // Polecenie wykonywane po naciśnięciu przycisku
        private void TimerPause()
        {
            // Wstrzymaj i zmień stan timera
            CurrentTimerState = _pomodoroTimer.Pause();
        }


        //
        // Zatrzymaj timer
        //
        private bool _timerStopCanExecute = true;
        private ICommand _timerStopCommand;
        public ICommand TimerStopCommand
        {
            get { return _timerStopCommand ?? (_timerStopCommand = new CommandHandler(() => TimerStop(), _timerStopCanExecute)); }
        }
        private void TimerStop()
        {
            // Wyświetl komunikat
            Messages.PomodoroStopMessage message = new Messages.PomodoroStopMessage(StopMessagePomodoroButton);
            message.Show();
        }


        // Akcja przycisku Pomodoro - zatrzymuje aktualne pomodoro
        private void StopMessagePomodoroButton(IUICommand command)
        {
            // Zatrzymaj timer
            CurrentTimerState = _pomodoroTimer.Stop();
            // Wyzeruj licznik
            RefreshTimer();
        }

        #endregion

        #region Inicjacja właściwości

        //
        // Ustawia stan początkowy pomodoro
        //
        private void SetInitialState()
        {
            // Odczytaj ustawienia 
            LoadSettings();

            // Stany początkowe
            // Początkowy czas timera - Czas pomodoro
            CurrentTime = _pomodoroTime;
            // Początkowy stan timera - Stop
            CurrentTimerState = PomodoroTimer.TimerState.Stopped;
            // Początkowy stan pomodoro - Pomodoro
            CurrentPomodoroState = PomodoroStates.PomodoroState.Pomodoro;
            // Wyzeruj aktualną liczbę pomodoro po której nastąpi długa przerwa
            CurrentPomodorosToLongBreak = 0;
            // Wyzeruj aktualny dzienny cel pomodoro
            CurrentPomodorosDailyTarget = 0;
            // Ustaw komunikat
            PomodoroStateContent = "pomodoro";

            // Przygotuj timer
            CreateTimer();

            // Ustaw pasek postępu
            TimerBar = SetTimerBar(CurrentTime, CurrentPomodoroState);
        }

        #endregion


        #region Singleton

        //private static PomodoroViewModel _instance = null;
        //public static PomodoroViewModel Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new PomodoroViewModel();
        //        return _instance;
        //    }
        //}

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
