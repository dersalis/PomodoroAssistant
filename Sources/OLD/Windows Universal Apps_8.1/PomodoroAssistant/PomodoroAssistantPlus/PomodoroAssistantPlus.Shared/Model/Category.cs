using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Media;

namespace PomodoroAssistantPlus.Model
{
    public class Category
    {
        // Id kategorii
        public string Id { get; set; }
        //public Guid Id { get; set; }
        // Nazwa kategori
        public string Name { get; set; }
        // Kolor kategorii
        public string Color { get; set; }
        //public SolidColorBrush Color { get; set; }
        // Określa czy można usuąć kategorię
        public bool IsPermissionDelete { get; set; }
    }
}
