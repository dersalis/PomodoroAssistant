namespace PomodoroWindowsData.Models
{
    /// <summary>
    /// Opisuje ustawienia
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Czas trwania pracy
        /// </summary>
        public int WorkDuration { get; set; }
        /// <summary>
        /// Czas trwania krótkiej przerwy
        /// </summary>
        public int ShorBreakDuration { get; set; }
        /// <summary>
        /// Czas trwania długiej przerwy
        /// </summary>
        public int LongBreakDuration { get; set; }
        /// <summary>
        /// Dzienny cel
        /// </summary>
        public int DailyTarget { get; set; }
        /// <summary>
        /// Liczba pomodoro do długiej przewy
        /// </summary>
        public int PomodoroToLongBreak { get; set; }
        /// <summary>
        /// Tryb ciszy
        /// </summary>
        public bool IsMuteSound { get; set; }
        /// <summary>
        /// Tryb włączonego ekranu
        /// </summary>
        public bool IsSceenOn { get; set; }
        /// <summary>
        /// Auto kontynuowanie
        /// </summary>
        public bool IsAutoContinue { get; set; }


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="workDuration">Czas trwania pracy</param>
        /// <param name="shortBreakDuration">Czas trwania krótkiej przerwy</param>
        /// <param name="longBreakDuration">Czas trwania długiej przerwy</param>
        /// <param name="dailyTarget">Dzienny cel</param>
        /// <param name="pomodoroToLongBreak">Liczba pomodoro do długiej przewy</param>
        /// <param name="isMuteSound">Tryb ciszy</param>
        /// <param name="IsSceenOn">Tryb włączonego ekranu</param>
        /// <param name="isAutoContinue">Auto kontynuowanie </param>
        public Settings(int workDuration, int shortBreakDuration, int longBreakDuration, int dailyTarget, int pomodoroToLongBreak, bool isMuteSound, bool isSceenOn, bool isAutoContinue)
        {
            WorkDuration = workDuration;
            ShorBreakDuration = shortBreakDuration;
            LongBreakDuration = longBreakDuration;
            DailyTarget = dailyTarget;
            PomodoroToLongBreak = pomodoroToLongBreak;
            IsMuteSound = isMuteSound;
            IsSceenOn = isSceenOn;
            IsAutoContinue = isAutoContinue;
        }

        //public Settings() { }
    }
}
