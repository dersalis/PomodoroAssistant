namespace Atrx.Mobile.Windows.Pomodoro.Repository.Models
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
        public Settings() { }
    }
}
