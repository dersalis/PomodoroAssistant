using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;

namespace Atrx.Mobile.Windows.Pomodoro.Pomodoro
{
    /// <summary>
    /// Opisuje zmiany zachoszące podczas wstrzymania aplikacji
    /// </summary>
    public class SuspendingManager
    {
        // Określa pozostały czas do końca aktualnego stanu pomodoro
        public static int TimeRemmaining { get; private set; } = 0;

        // Określa czy aplikacja znajdowała się w stanie uśpienia
        public static bool WasSuspending { get; set; } = false;

        // Aktualna liczba pomodoro do długiej przerwy
        private static int _currentPomodoroToLongBrak = 0;

        // Ustawiona liczba pomodoro do długiej przerwy
        private static int _settingPomodoroToLongBrak = 0;


        /// <summary>
        /// Ustawia aktualne wartości odczytane z programu
        /// </summary>
        /// <param name="timeRemmaining">Pozostały czas aktualnego stanu pomodoro</param>
        /// <param name="currPomodoroToLongBreak">Aktualna liczba pomodoro do długiej przerwy</param>
        /// <param name="setPomodoroToLongBrak">Ustawiona liczba pomodoro do długiej przerwy</param>
        public static void SetSuspendingValues(int timeRemmaining, int currPomodoroToLongBreak, int setPomodoroToLongBrak)
        {
            // Ustaw wartości
            TimeRemmaining = timeRemmaining;
            _currentPomodoroToLongBrak = currPomodoroToLongBreak;
            _settingPomodoroToLongBrak = setPomodoroToLongBrak;
        }


        /// <summary>
        /// Ustawia i zwraca stan pomodoro na podstawie aktualnych wartości z programu
        /// </summary>
        /// <returns>Stan pomodoro</returns>
        public static PomodoroStates OnSuspend()
        {
            // Aktualny stan pomodoro
            PomodoroStates localPomodoroState = PomodoroState.GetCurrentState();
            // Przesuń liczbę pomodoro do długiej przerwy o 1
            // Ponieważ ma wyświetlać nie obecny stan ale przyszły / kolejny
            _currentPomodoroToLongBrak++;
            // Sprawdz czy timer jest uruchomiony
            if (TimerState.GetCurrentState() == TimerStates.Started)
            {
                // Ustaw - przejście do stanu wstrzymania
                WasSuspending = true;
                // Ustaw nowy stan pomodoro
                if (localPomodoroState == PomodoroStates.WorkTime)
                {
                    if (_currentPomodoroToLongBrak == _settingPomodoroToLongBrak)
                    {
                        localPomodoroState = PomodoroStates.LongBreakTime;
                    }
                    else
                        localPomodoroState = PomodoroStates.ShortBreakTime;
                }
                else
                    localPomodoroState = PomodoroStates.WorkTime;
            }
            // Zwróć stan
            return localPomodoroState;
        }
    }
}
