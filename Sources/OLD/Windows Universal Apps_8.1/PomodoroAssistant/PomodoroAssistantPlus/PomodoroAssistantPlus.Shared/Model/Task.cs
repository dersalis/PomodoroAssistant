using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroAssistantPlus.Model
{
    public class Task
    {
        // Id
        public string Id { get; set; }
        // Nazwa zadania
        public string Name { get; set; }
        // Opis zadania
        public string Note { get; set; }
        // Kategoria
        public string CategoryId { get; set; }
        // Data dodania
        public DateTime AddDate { get; set;}
        // Data ostatniej edycji
        public DateTime LastEditionDate { get; set; }
        // Data usunięcia
        public DateTime DeleteDate { get; set; }
        // Określa czy zadanie jest aktywne
        public bool IsAcitve { get; set; }
    }
}
