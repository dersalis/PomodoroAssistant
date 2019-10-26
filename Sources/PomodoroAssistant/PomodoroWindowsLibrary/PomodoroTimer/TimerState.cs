namespace Atrx.Mobile.Windows.Pomodoro.PomodoroTimer
{
    // Stany timera
    public enum TimerStates { Started, Paused, Stopped}

    public static class TimerState
    {
        private static TimerStates _currentState;

        //
        // Konstruktor
        //
        static TimerState()
        {
            // Ustaw
            _currentState = TimerStates.Stopped;
        }


        //
        // Zwróć aktualny stan
        //
        public static TimerStates GetCurrentState()
        {
            // Zwróć
            return _currentState;
        }


        //
        // Ustaw stan Started
        //
        public static void SetStarted()
        {
            _currentState = TimerStates.Started;
        }


        //
        // Ustaw stan Paused
        //
        public static void SetPaused()
        {
            _currentState = TimerStates.Paused;
        }

        //
        // Ustaw stan Stopped
        //
        public static void SetStopped()
        {
            _currentState = TimerStates.Stopped;
        }
    }
}
