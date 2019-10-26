using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroAssistantPlus.Model
{
    public class PomodoroCycle
    {
        // Id cyklu
        public string Id { get; set; }
        // Id zadania
        public string TaskId { get; set; }
        // Id kategorii
        public string CategoryId { get; set; }
        // Data rozpoczęcia zadania
        public DateTime StartDate { get; set; }
        // Czas twania cyklu
        public TimeSpan Duration { get; set; }
    }
}
