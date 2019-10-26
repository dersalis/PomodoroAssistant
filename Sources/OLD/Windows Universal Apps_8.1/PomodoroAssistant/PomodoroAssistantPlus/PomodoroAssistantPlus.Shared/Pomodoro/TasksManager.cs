using System;
using System.Collections.Generic;
using System.Text;

using PomodoroAssistantPlus.Model;
using System.Linq;

namespace PomodoroAssistantPlus.Pomodoro
{
    public static class TasksManager
    {
        //
        // Zwraca listę zadań aktywnych
        //
        public static List<ActiveTaskView> GetActiveTasksList(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, int viewIndex = 0)
        {
            /*
             * CEL:
             *  Zwraca listę posortowanych zadań aktywnych
             * PARAMETRY:
             *  List<Task> tasks - lista zadań pobranych z pliku
             *  List<Category> categories - lista kategorii pobranch z pliku
             *  List<PomodoroCycle> cycles - lista cykli pobrana z pliku
             *  int viewIndex - indeks sortowania:
             *      0 - alfabetycznie
             *      1 - data utworzenia
             *      2 - data edycji
             *      3 - czasu
             *      4 - kategorii
             *  WARTOŚĆ ZWRACANA:
             *   List<ActiveTaskView> - lista zadań aktywnych
             */

            // Lista zadań
            var tasksList = new List<ActiveTaskView>();
            // Zadania aktywne - true
            bool isActive = true;

            // Wybierz typ sortowania
            switch (viewIndex)
            { 
                case 0:
                    // nazwa alfabetycznie
                    tasksList = GetActiveTasksListSortByName(tasks, categories, cycles, isActive);
                    break;
                case 1:
                    // data rozpoczęcia
                    tasksList = GetActiveTasksListSortByAddDate(tasks, categories, cycles, isActive);
                    break;
                case 2:
                    // data edycji
                    tasksList = GetActiveTasksListSortByLastEditDate(tasks, categories, cycles, isActive);
                    break;
                case 3:
                    // czas
                    tasksList = GetActiveTasksListSortByTotalTime(tasks, categories, cycles, isActive);
                    break;
                case 4:
                    // kategorii
                    tasksList = GetActiveTasksListSortByCategory(tasks, categories, cycles, isActive);
                    break;
            }


            // Zwróć listę
            return tasksList;
        }


        //
        // Zwraca listę zadań zakończonych
        //
        public static List<CompletedTaskView> GetCompletedTasksList(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, int viewIndex = 0)
        {
            /*
             * CEL:
             *  Zwraca listę posortowanych zadań aktywnych
             * PARAMETRY:
             *  List<Task> tasks - lista zadań pobranych z pliku
             *  List<Category> categories - lista kategorii pobranch z pliku
             *  List<PomodoroCycle> cycles - lista cykli pobrana z pliku
             *  int viewIndex - indeks sortowania:
             *      0 - alfabetycznie
             *      1 - data rozpoczęcia
             *      2 - data zakończenia
             *      3 - czasu
             *      4 - kategorii
             *  WARTOŚĆ ZWRACANA:
             *   List<ActiveTaskView> - lista zadań aktywnych
             */

            // Lista zadań
            var tasksList = new List<CompletedTaskView>();
            // Zadania zakończone - false
            bool isActive = false;

            // Wybierz typ sortowania
            switch (viewIndex)
            {
                case 0:
                    // alfabetycznie
                    tasksList = GetCompletedTasksListSortByName(tasks, categories, cycles, isActive);
                    break;
                case 1:
                    // data rozpoczęcia
                    tasksList = GetCompletedTasksListSortByAddDate(tasks, categories, cycles, isActive);
                    break;
                case 2:
                    // data zakończenia
                    tasksList = GetCompletedTasksListSortByDeleteDate(tasks, categories, cycles, isActive);
                    break;
                case 3:
                    // czas
                    tasksList = GetCompletedTasksListSortByTime(tasks, categories, cycles, isActive);
                    break;
                case 4:
                    // kategorii
                    tasksList = GetCompletedTasksListSortByCategory(tasks, categories, cycles, isActive);
                    break;
            }


            // Zwróć listę
            return tasksList;
        }


        //
        // Zwraca listę zadań aktywnych
        //
        private static List<ActiveTaskView> SetActiveTasksList(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = (from task in tasks
                             where task.IsAcitve == isActive
                             select new ActiveTaskView()
                             {
                                 Id = task.Id,
                                 Name = task.Name,
                                 Note = task.Note,
                                 CategoryColor = (from category in categories where category.Id == task.CategoryId.ToString() select category.Color).FirstOrDefault(),
                                 AddDate = task.AddDate,
                                 LastEditionDate = task.LastEditionDate,
                                 TotalTime = TimeManager.CalculateTotalTasksTime(cycles, task.Id)
                             }
            ).ToList();
            // Zwróć
            return tasksList;
        }


        //
        // Zwraca listę zadań aktywnych posortowanych alfabetycznie
        //
        private static List<ActiveTaskView> GetActiveTasksListSortByName(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = SetActiveTasksList(tasks, categories, cycles, isActive);
            // Sortuj wg. nazwy
            tasksList.Sort((n1, n2) => n1.Name.CompareTo(n2.Name));
            // Zwróć
            return tasksList;
        }


        //
        // Zwraca listę zadań aktywnych posortowanych data utworzenia
        //
        private static List<ActiveTaskView> GetActiveTasksListSortByAddDate(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = SetActiveTasksList(tasks, categories, cycles, isActive);
            // Sortuj wg. daty utworzenia
            tasksList.Sort((d1, d2) => d1.AddDate.CompareTo(d2.AddDate));
            // Odwróć tablicę
            tasksList.Reverse();
            // Zwróć
            return tasksList;
        }


        //
        // Zwraca listę zadań aktywnych posortowanych data ostatniej edycji
        //
        private static List<ActiveTaskView> GetActiveTasksListSortByLastEditDate(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = SetActiveTasksList(tasks, categories, cycles, isActive);
            // Sortuj wg. daty edycji
            tasksList.Sort((d1, d2) => d1.LastEditionDate.CompareTo(d2.LastEditionDate));
            // Odwróć tablicę
            tasksList.Reverse();
            // Zwróć
            return tasksList;
        }


        //
        // Zwraca listę zadań aktywnych posortowanych liczby cykli
        //
        private static List<ActiveTaskView> GetActiveTasksListSortByTotalTime(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = SetActiveTasksList(tasks, categories, cycles, isActive);
            // Sortuj wg. czasu
            tasksList.Sort((t1, t2) => t1.TotalTime.CompareTo(t2.TotalTime));
            // Odwróć tablicę
            tasksList.Reverse();
            // Zwróć
            return tasksList;
        }


        //
        // Zwraca listę zadań aktywnych posortowanych wg kategorii
        //
        private static List<ActiveTaskView> GetActiveTasksListSortByCategory(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = SetActiveTasksList(tasks, categories, cycles, isActive);
            // Sotruj wg. kategorii
            tasksList.Sort((k1, k2) => k1.CategoryColor.ToString().CompareTo(k2.CategoryColor.ToString()));
            return tasksList;
        }


        //
        // Zwraca listę zadań zakończonych
        //
        private static List<CompletedTaskView> SetCompletedTasksList(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = (from task in tasks
                             where task.IsAcitve == isActive
                             select new CompletedTaskView()
                             {
                                 Id = task.Id,
                                 Name = task.Name,
                                 Note = task.Note,
                                 CategoryColor = (from category in categories where category.Id == task.CategoryId.ToString() select category.Color).FirstOrDefault(),
                                 DeleteDate = task.DeleteDate,
                                 AddDate = task.AddDate,
                                 TotalTime = TimeManager.CalculateTotalTasksTime(cycles, task.Id)
                             }
            ).ToList();
            // Zwróć listę
            return tasksList;
        }


        //
        // Zwraca listę zadań zakończonych posortowanych alfabetycznie
        //
        private static List<CompletedTaskView> GetCompletedTasksListSortByName(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = SetCompletedTasksList(tasks, categories, cycles, isActive);
            // Sortuj wg. nazwy
            tasksList.Sort((n1, n2) => n1.Name.CompareTo(n2.Name));
            // Zwróć
            return tasksList;
        }


        //
        // Zwraca listę zadań zakończonych posortowanych data utworzenia
        //
        private static List<CompletedTaskView> GetCompletedTasksListSortByAddDate(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = SetCompletedTasksList(tasks, categories, cycles, isActive);
            // Sortuj wg. daty utworzenia
            tasksList.Sort((d1, d2) => d1.AddDate.CompareTo(d2.AddDate));
            // Odwróć tablicę
            tasksList.Reverse();
            // Zwróć
            return tasksList;
        }


        //
        // Zwraca listę zadań zakończonych posortowanych data usunięcia
        //
        private static List<CompletedTaskView> GetCompletedTasksListSortByDeleteDate(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = SetCompletedTasksList(tasks, categories, cycles, isActive);
            // Sotruj wg. daty zakończenia
            tasksList.Sort((d1, d2) => d1.DeleteDate.CompareTo(d2.DeleteDate));
            // Odwróć
            tasksList.Reverse();
            // Zwróć
            return tasksList;
        }


        //
        // Zwraca listę zadań zakończonych posortowanych wg kategorii
        //
        private static List<CompletedTaskView> GetCompletedTasksListSortByCategory(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = SetCompletedTasksList(tasks, categories, cycles, isActive);
            // Sortuj wg. kategorii
            tasksList.Sort((k1, k2) => k1.CategoryColor.ToString().CompareTo(k2.CategoryColor.ToString()));
            // Zwróć
            return tasksList;
        }


        //
        // Zwraca listę zadań zakończonych posortowanych wg czasu
        //
        private static List<CompletedTaskView> GetCompletedTasksListSortByTime(List<Task> tasks, List<Category> categories, List<PomodoroCycle> cycles, bool isActive)
        {
            // Tymczasowa lista zadań - zwracana
            var tasksList = SetCompletedTasksList(tasks, categories, cycles, isActive);
            // Sortuj wg. czasu
            tasksList.Sort((t1, t2) => t1.TotalTime.CompareTo(t2.TotalTime));
            // Odwraca 
            tasksList.Reverse();
            // Zwróć
            return tasksList;
        }


        //// 
        //// Oblicza całkowity czas
        ////
        //private static TimeSpan CalculateTotalTasksTime(List<PomodoroCycle> cycles, Guid taskId)
        //{
        //    TimeSpan totalTime = new TimeSpan(0, 0, 0);
        //    foreach (var cycle in cycles)
        //    {
        //        if (cycle.TaskId == taskId)
        //            totalTime += cycle.Duration;
        //    }
        //    return totalTime;
        //}
    }
}
