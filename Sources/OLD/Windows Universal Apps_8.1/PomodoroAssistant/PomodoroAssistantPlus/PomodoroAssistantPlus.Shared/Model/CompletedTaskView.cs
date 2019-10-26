using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Media;

namespace PomodoroAssistantPlus.Model
{
    public class CompletedTaskView
    {
        // Id
        public string Id { get; set; }
        // Nazwa zadania
        public string Name { get; set; }
        // Opis zadania
        public string Note { get; set; }
        // Kategoria
        public string CategoryColor { get; set; }
        // Data dodania
        public DateTime AddDate { get; set; }
        // Data usunięcia
        public DateTime DeleteDate { get; set; }
        // Data ostatniej edycji
        //public DateTime LastEditionDate { get; set; }
        // Całkowity czas poświęcony zadaniu
        public TimeSpan TotalTime { get; set; }
    }
}
