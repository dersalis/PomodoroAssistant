using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrx.Mobile.Windows.Pomodoro.Data.TasksLocalData
{
    /// <summary>
    /// Baza zadań
    /// </summary>
    public class TasksLocalData
    {
        // Lista zadań
        private static List<Task> _dataBase = null;


        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        static TasksLocalData()
        {
            // Zainicjuj bazę
            _dataBase = new List<Task>();
            // Odczytaj dane
        }


        /// <summary>
        /// Zwraca wszystkie zadania
        /// </summary>
        /// <returns>Lista zadań</returns>
        public static List<Task> GetAllTasks()
        {
            // Zwróć zadania
            return _dataBase;
        }


        /// <summary>
        /// Zwraca zadanie o podanym Id
        /// </summary>
        /// <param name="taskId">Id wyszukiwanego zadania</param>
        /// <returns>Wyszukane zadanie lub null gdy brak</returns>
        public static Task GetTaskOfId(string taskId)
        {
            // Znajdź zadanie
            Task foundTask = FindTaskOfId(taskId);
            // Zwróć zadanie
            return foundTask;
        }


        /// <summary>
        /// Dodaje nowe zadanie
        /// </summary>
        /// <param name="newTask">Nowe zadanie</param>
        public static void AddTask(Task newTask)
        {
            _dataBase.Add(newTask);
        }



        public static void InserTaskOfId(string taskId, Task newTask)
        {
            // Wyszukaj zadtępowane zadanie
            Task foundTask = FindTaskOfId(taskId);
            _dataBase.Remove(foundTask);
            _dataBase.Add(newTask);
        }


        /// <summary>
        /// Usuwa zadanie o podanym id
        /// </summary>
        /// <param name="taskId">Id usuwanego zadania</param>
        public static void RemoveTaskOfId(string taskId)
        {
            // Znajdź usuwane zadanie
            Task removedTask = FindTaskOfId(taskId);
            // Usuń zadanie
            _dataBase.Remove(removedTask);
        }


        /// <summary>
        /// Wyszukuje zadanie o podanym id
        /// </summary>
        /// <param name="taskId">Id szukanego zadania</param>
        /// <returns>Wyszukane zadanie lub null - gdy brak zadania</returns>
        private static Task FindTaskOfId(string taskId)
        {
            Task foundTask = null; // Znalezione zadanie
            // Przeszukaj bazę
            foreach(var task in _dataBase)
            {
                // Sprawdz czy id aktualnego zadaniea jest równe podanemu id
                if (task.Id == taskId)
                {
                    // Jesli są równe to zapamiętaj zadanie i przerwij przeszukiwanie
                    foundTask = task;
                    break;
                }
            }
            return foundTask;
        }


    }
}
