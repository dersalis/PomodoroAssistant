using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Media;

namespace PomodoroAssistantPlus.Model
{
    public class CategoryView
    {
        // Id kategorii
        public string Id { get; set; }
        // Nazwa kategori
        public string Name { get; set; }
        // Kolor kategorii
        public string Color { get; set; }
        // Określa czy można usuąć kategorię
        public bool IsPermissionDelete { get; set; }
        // Całkowity czas zadań w kategorii
        public TimeSpan TotalTime { get; set; }
        // Liczba zadań
        public int TaskCount { get; set; }
        // Liczba cykli
        public int CycleCount { get; set; }
    }
}
