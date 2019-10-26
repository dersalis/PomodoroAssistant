namespace Atrx.Mobile.Windows.Pomodoro.PomodoroTimer
{
    // Stany pomodoro
    public enum PomodoroStates { WorkTime, ShortBreakTime, LongBreakTime}

    public static class PomodoroState
    {
        // Aktualny stan
        private static PomodoroStates _currentState;


        //
        // Konstruktor
        //
        static PomodoroState()
        {
            // Ustaw na czas pracy
            _currentState = PomodoroStates.WorkTime;
        }


        //
        // Zwraca aktualny stan
        //
        public static PomodoroStates GetCurrentState()
        {
            // Zwróć aktualny stan
            return _currentState;
        }


        //
        // Ustaw aktualny stan na WorkTime
        //
        public static void SetWorkTime()
        {
            // Ustaw
            _currentState = PomodoroStates.WorkTime;
        }


        //
        // Ustaw aktualny stan na ShortBreakTime
        //
        public static void SetShortBreakTime()
        {
            // Ustaw
            _currentState = PomodoroStates.ShortBreakTime;
        }


        //
        // Ustaw aktualny stan na LongBreakTime
        //
        public static void SetLongBreakTime()
        {
            // Ustaw
            _currentState = PomodoroStates.LongBreakTime;
        }
    }
}
