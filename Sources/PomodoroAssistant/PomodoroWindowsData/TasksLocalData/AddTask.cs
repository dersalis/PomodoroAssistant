using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrx.Mobile.Windows.Pomodoro.Data.TasksLocalData
{
    public class AddTask : ITransaction
    {
        private string _id; // Id zadania
        private string _name; // Nazwa zadania
        private string _note; // Notatka zadania
        

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="id">Id zadania</param>
        /// <param name="name">Nazwa zadania</param>
        /// <param name="note">Notatka zadania</param>
        public AddTask(string id, string name, string note)
        {
            _id = id;
            _name = name;
            _note = note;
        }


        /// <summary>
        /// Dodaje zadanie
        /// </summary>
        public void Execute()
        {
            // Utwórz nowe zadanie
            Task newTask = new Task(_id, _name, _note);
            // Dodaj zadanie
            TasksLocalData.AddTask(newTask);
        }
    }
}
