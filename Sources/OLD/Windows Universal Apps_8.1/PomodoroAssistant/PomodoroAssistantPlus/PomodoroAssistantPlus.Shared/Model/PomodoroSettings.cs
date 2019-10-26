using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroAssistantPlus.Model
{
    public class PomodoroSettings
    {
        // Licznik uruchomień
        public int StartCount { get; set; }
        // Indeks widoku aktywnych zadań
        public int ActiveTaskViewIndex { get; set; }
        // Indeks widoku zakończonych zadań
        public int CompletedTaskViewIndex { get; set; }
        // Indeks widoku kategorii
        public int CategoryViewIndex { get; set; }
        // Czas pomodoro
        public int PomodoroDuration { get; set; }
        // Czas długiej przerwy
        public int LongBreakDutation { get; set; }
        // Czas krótkiej przerwy
        public int ShortBreakDuration { get; set; }
        // Liczba cykli pomodoro po jakich wystąpi długa przerwa
        public int LongBreakDelay { get; set; }
    }
}
