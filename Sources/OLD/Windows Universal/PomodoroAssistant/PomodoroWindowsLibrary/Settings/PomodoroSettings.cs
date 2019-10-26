using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrx.Mobile.Windows.Pomodoro.Settings
{
    public class PomodoroSettings
    {
        // Czas trwania pracy
        public int WorkDuration { get ; set; }
        // Czas trwania krótkiej przerwy
        public int ShorBreakDuration { get; set; }
        // Czas trwania długiej przerwy
        public int LongBreakDuration { get; set; }
        // Dzienny cel
        public int DailyTarget { get; set; }
        // Liczba pomodoro do długiej przewy
        public int PomodoroToLongBreak { get; set; }
        // Tryb ciszy
        public bool IsMuteSound { get; set; }
        // Auto kontynuowanie 
        public bool IsAutoContinue { get; set; }


        //
        // Konstruktor
        //
        public PomodoroSettings(int workDuration, int shortBreakDuration, int longBreakDuration, int dailyTarget, int pomodoroToLongBreak, bool isMuteSound, bool isAutoContinue)
        {
            WorkDuration = workDuration;
            ShorBreakDuration = shortBreakDuration;
            LongBreakDuration = longBreakDuration;
            DailyTarget = dailyTarget;
            PomodoroToLongBreak = pomodoroToLongBreak;
            IsMuteSound = isMuteSound;
            IsAutoContinue = isAutoContinue;
        }

        public PomodoroSettings() { }
    }
}
