using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroAssistant
{
    public static class PomodoroStates
    {
        // Stan timera
        //public enum TimerState { Started, Paused, Stopped };
        // Stan pomodoro
        public enum PomodoroState { Pomodoro, ShortBreak, LongBreak };
    }
}
