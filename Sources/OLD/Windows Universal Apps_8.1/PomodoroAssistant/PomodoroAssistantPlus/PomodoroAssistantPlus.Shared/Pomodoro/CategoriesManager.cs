using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using PomodoroAssistantPlus.Model;
using Windows.UI.Xaml.Media;

namespace PomodoroAssistantPlus.Pomodoro
{
    public static class CategoriesManager
    {
        //
        // Ustawia listę kategorii
        //
        public static List<CategoryView> GetCategoriesList(List<Category> categories, List<Task> tasks, List<PomodoroCycle> cycles, int viewIndex = 0)
        {
            /*
             * CEL:
             *  Zwraca listę posortowanych kateorii
             * PARAMETRY:
             *  List<Category> categories - lista kategorii pobranch z pliku
             *  List<Task> tasks - lista zadań pobranych z pliku
             *  List<PomodoroCycle> cycles - lista cykli pobrana z pliku
             *  int viewIndex - indeks sortowania:
             *      0 - alfabetycznie
             *      1 - liczby zadań
             *      2 - liczby cykli
             *      3 - czasu
             *  WARTOŚĆ ZWRACANA:
             *   List<CategoryView> - lista kategorii
             */

            // Tymczasowa lista categori - zwracana
            List<CategoryView> categoryList = new List<CategoryView>();

            // Wybierz typ sortowania
            switch (viewIndex)
            { 
                case 0:
                    // nazwa alfabetycznie
                    categoryList = GetCategoriesListSortByName(categories, tasks, cycles);
                    break;
                case 1:
                    // liczba zadań
                    categoryList = GetCategoriesListSortByTasksCount(categories, tasks, cycles);
                    break;
                case 2:
                    // liczba cykli
                    categoryList = GetCategoriesListSortByCyclesCount(categories, tasks, cycles);
                    break;
                case 3:
                    // czas
                    categoryList = GetCategoriesListSortByTotalTime(categories, tasks, cycles);
                    break;
            }

            return categoryList;
        }


        private static List<CategoryView> SetCategoriesList(List<Category> categories, List<Task> tasks, List<PomodoroCycle> cycles)
        {
            // Lista kategorii
            var categoryList = (from cat in categories
                                select new CategoryView() 
                                {
                                    Id = cat.Id,
                                    Name = cat.Name,
                                    Color = cat.Color,
                                    IsPermissionDelete = cat.IsPermissionDelete,
                                    TaskCount = (from task in tasks where task.CategoryId == cat.Id select task).Count(),
                                    CycleCount = (from cycle in cycles where cycle.CategoryId == cat.Id select cycle).Count(),
                                    TotalTime = TimeManager.CalculateTotalCategoryTime(cycles, cat.Id)
                                }).ToList();
            // Zwróć listę
            return categoryList;
        }


        //
        // Zwraca listę kategorii posortowanych alfabetycznie
        //
        private static List<CategoryView> GetCategoriesListSortByName(List<Category> categories, List<Task> tasks, List<PomodoroCycle> cycles)
        {
            // Lista kategorii
            var categoryList = SetCategoriesList(categories, tasks, cycles);
            // Sort wg. nazwy alfabetycznie
            categoryList.Sort((n1, n2) => n1.Name.CompareTo(n2.Name));
            // Zwróć 
            return categoryList;
        }


        //
        // Zwraca listę kategorii posortowanych wg. liczby zadań
        //
        private static List<CategoryView> GetCategoriesListSortByTasksCount(List<Category> categories, List<Task> tasks, List<PomodoroCycle> cycles)
        {
            // Lista kategorii
            var categoryList = SetCategoriesList(categories, tasks, cycles);
            // Sortuj wg. liczby zadań
            categoryList.Sort((t1, t2) => t1.TaskCount.CompareTo(t2.TaskCount));
            // Odwróć
            categoryList.Reverse();
            // Zwróć 
            return categoryList;
        }


        //
        // Zwraca listę kategorii posortowanych wg. liczby cykli
        //
        private static List<CategoryView> GetCategoriesListSortByCyclesCount(List<Category> categories, List<Task> tasks, List<PomodoroCycle> cycles)
        {
            // Lista kategorii
            var categoryList = SetCategoriesList(categories, tasks, cycles);
            // Sortuj wg. liczy cykli
            categoryList.Sort((c1, c2) => c1.CycleCount.CompareTo(c2.CycleCount));
            // Odwróć
            categoryList.Reverse();
            // Zwróć 
            return categoryList;
        }


        //
        // Zwraca listę kategorii posortowanych wg. czasu
        //
        private static List<CategoryView> GetCategoriesListSortByTotalTime(List<Category> categories, List<Task> tasks, List<PomodoroCycle> cycles)
        {
            // Lista kategorii
            var categoryList = SetCategoriesList(categories, tasks, cycles);
            // Sortuj wg. czasu
            categoryList.Sort((t1, t2) => t1.TotalTime.CompareTo(t2.TotalTime));
            // Odwróć
            categoryList.Reverse();
            // Zwróć 
            return categoryList;
        }
    }
}
