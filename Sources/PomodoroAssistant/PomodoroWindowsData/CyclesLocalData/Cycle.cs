using System;

namespace Atrx.Mobile.Windows.Pomodoro.Data.CyclesLocalData
{
    public class Cycle
    {
        public string Id { get; private  set; } // Identyfikator cyklu - GUID
        public string TaskId { get; private set; } // Identyfikarot zadania do którego przynależy cykl - GUID
        public DateTime StartDate { get; private set; } // Data rozpoczęcia cyklu
        public DateTime FinishDate { get; private set; } // Data zakończenia cyklu
        public bool IsFinished { get; private set; } // Określa czy zadanie jest zakończone
        public int TotalTimeInSecond { get { return GetTotalTimeInSecond(); } }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="id">Identyfikator cyklu - GUID</param>
        /// <param name="taskId">Identyfikarot zadania do którego przynależy cykl - GUID</param>
        public Cycle(string id, string taskId)
        {
            Id = id;
            TaskId = taskId;
            StartDate = DateTime.Now;
            FinishDate = DateTime.Now;
        }


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
        private int GetTotalTimeInSecond()
        {
            // Oblicz czas wykonywania zadania
            TimeSpan totalTime = FinishDate - StartDate;
            // Zwróć czas wykonywania zadania - int
            return (int)totalTime.TotalSeconds;
        }
    }
}
