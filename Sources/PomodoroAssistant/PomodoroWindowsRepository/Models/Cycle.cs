using System;

namespace Atrx.Mobile.Windows.Pomodoro.Repository.Models
{
    public class Cycle
    {
        public string Id { get; set; } // Identyfikator cyklu - GUID
        public string TaskId { get; set; } // Identyfikarot zadania do którego przynależy cykl - GUID
        public DateTime StartDate { get; set; } // Data rozpoczęcia cyklu
        public DateTime FinishDate { get; set; } // Data zakończenia cyklu
        public bool IsFinished { get; set; } // Określa czy zadanie jest zakończone
        //public int TotalTimeInSecond { get { return GetTotalTimeInSecond(); } }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Cycle() { }


        /// <summary>
        /// Ustawia zadanie jako zakończone
        /// </summary>
        public void SetAsFinished()
        {
            FinishDate = DateTime.Now;
            IsFinished = true;
        }


        /// <summary>
        /// Oblicza czas wykonywania cyklu
        /// </summary>
        /// <returns>Czas wykonywania cyklu w sekundach</returns>
        public int GetTotalTimeInSecond()
        {
            // Oblicz czas wykonywania zadania
            TimeSpan totalTime = FinishDate - StartDate;
            // Zwróć czas wykonywania zadania - int
            return (int)totalTime.TotalSeconds;
        }


        /// <summary>
        /// Oblicza czas wykonywania cyklu
        /// </summary>
        /// <returns>Czas wykonywania cyklu w sekundach</returns>
        public int GetTotalTimeInMinutes()
        {
            // Oblicz czas wykonywania zadania
            TimeSpan totalTime = FinishDate - StartDate;
            // Zwróć czas wykonywania zadania - int
            return (int)totalTime.TotalMinutes;
        }
    }
}
