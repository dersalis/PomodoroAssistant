using System;

namespace Atrx.Mobile.Windows.Pomodoro.Data.TasksLocalData
{
    public class Task
    {
        public string Id { get; private set; } // Identyfikator zadanie - GUID
        public string Name { get; set; } // Nazwa zadania
        public string Note { get; set; } // Notatka opisująca zadanie
        public DateTime StartDate { get; private set; } = DateTime.Now; // Data rozpoczęcia zadania
        public DateTime FinishDate { get; private set; } = DateTime.Now; // Data zakończenia zadania
        public bool IsFinished { get; private set; } = false; // Określa czy zadanie jest już zakończone


        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        /// <param name="id">Identyfikator zadanie - GUID</param>
        /// <param name="name">Nazwa zadania</param>
        /// <param name="note">Notatka opisująca zadanie</param>
        public Task(string id, string name, string note)
        {
            Id = id;
            Name = name;
            Note = note;
        }


        /// <summary>
        /// Ustawia zadanie jako zakończone
        /// </summary>
        public void SetAsFinished()
        {
            // Ustaw jako zakończone
            IsFinished = true;
            // Ustaw date zakończenia
            FinishDate = DateTime.Now;
        }


        /// <summary>
        /// Ustawia zadanie jako nie zakończone
        /// </summary>
        public void SetAsUnfinished()
        {
            // Ustaw jako nie zakończone
            IsFinished = false;
            // Ustaw date zakończenia równą dacie rozpoczęcia
            FinishDate = StartDate;
        }
    }
}
