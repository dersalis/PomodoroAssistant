using System;
using System.Collections.Generic;
using System.Text;

using PomodoroAssistantPlus.ViewModel;
using PomodoroAssistantPlus.Model;
using PomodoroAssistantPlus.Pomodoro;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml.Media;
using Windows.UI.Popups;
using Windows.ApplicationModel.Resources;

namespace PomodoroAssistantPlus.ViewModel
{
    public class TasksViewModel : INotifyPropertyChanged
    {

        // Lista zadań aktywnych
        public List<ActiveTaskView> ActiveTaskList { get; private set; }
        // Lista zadań zakończonych
        public List<CompletedTaskView> CompletedTaskList { get; private set; }
        // Lista kategorii
        public List<CategoryView> CategoryList { get; private set; }
        // Indeks widoku aktywnych zadań
        public string ActiveTaskViewName { get; set; }
        // Indeks widoku zakończonych zadań
        public string CompletedTaskViewName { get; set; }
        // Indeks widoku kategorii
        public string CategoryViewName { get; set; }

        //
        // Konstruktor
        //
        public TasksViewModel()
        {

        }


        //
        // Odczytuje dane z plików
        //
        public async void LoadAndSetData()
        {
            // Wczytaj pliki
            // Plik ustawień
            await LocalStorage.SettingsStorage.LoadData<PomodoroSettings>();
            // Plik kategorii
            await LocalStorage.CategoryStorage.LoadData<Category>();
            // Plik zadania
            await LocalStorage.TaskStorage.LoadData<Task>();
            // Pliki cykli
            await LocalStorage.CycleStorage.LoadData<PomodoroCycle>();
            // Ustaw dane
            SetAllData();
        }


        //
        // Ustaw wszystkie dane
        //
        public void SetAllData()
        {
            // Odczytaj ustawienia widoku
            int activeTaskViewIndex = LocalStorage.SettingsStorage.GetData().ActiveTaskViewIndex;
            int completedTaskViewIndex = LocalStorage.SettingsStorage.GetData().CompletedTaskViewIndex;
            int categoryViewIndex = LocalStorage.SettingsStorage.GetData().CategoryViewIndex;
            // Lista kategorii
            //List<Category> categoriesList = TestData.TasksTestData.GetCategoriesFromTestFile();
            List<Category> categoriesList = LocalStorage.CategoryStorage.GetData();
            // Lista zadań
            //List<Task> tasksList = TestData.TasksTestData.GetTasksFromTestFile(categoriesList);
            List<Task> tasksList = LocalStorage.TaskStorage.GetData();
            // Lista cykli
            //List<PomodoroCycle> cyclesList = TestData.TasksTestData.GetPomodoroCyclesFromTestFile(tasksList);
            List<PomodoroCycle> cyclesList = LocalStorage.CycleStorage.GetData();

            // Ustaw listy
            // Ustaw listę zadań aktywnych
            ActiveTaskList = TasksManager.GetActiveTasksList(tasksList, categoriesList, cyclesList, activeTaskViewIndex);
            // Ustaw listę zadań zakończonych
            CompletedTaskList = TasksManager.GetCompletedTasksList(tasksList, categoriesList, cyclesList, completedTaskViewIndex);
            // Ustaw listę kategorii
            CategoryList = CategoriesManager.GetCategoriesList(categoriesList, tasksList, cyclesList, categoryViewIndex);
            // Odśwież
            RaisePropertyChanged("ActiveTaskList");
            RaisePropertyChanged("CompletedTaskList");
            RaisePropertyChanged("CategoryList");

            // Ustaw podpisy sortowania
            // Ustaw nazwę listy zadań aktywnych
            ActiveTaskViewName = GetActiveTaskViewName()[activeTaskViewIndex];
            // Ustaw nazwę listy zadań zakończonych
            CompletedTaskViewName = GetCompletedTaskViewName()[completedTaskViewIndex];
            // Ustaw nazwę listy kategorii
            CategoryViewName = GetCategoryViewName()[categoryViewIndex];
            // Odśwież
            RaisePropertyChanged("ActiveTaskViewName");
            RaisePropertyChanged("CompletedTaskViewName");
            RaisePropertyChanged("CategoryViewName");
        }


        //
        // Ustaw dane zadań aktywnych
        //
        public void SetActiveTasks(int viewIndex)
        {
            // Lista kategorii
            List<Category> categoriesList = LocalStorage.CategoryStorage.GetData();
            // Lista zadań
            List<Task> tasksList = LocalStorage.TaskStorage.GetData();
            // Lista cykli
            List<PomodoroCycle> cyclesList = LocalStorage.CycleStorage.GetData();

            // Ustaw listę zadań aktywnych
            ActiveTaskList = TasksManager.GetActiveTasksList(tasksList, categoriesList, cyclesList, viewIndex);
            RaisePropertyChanged("ActiveTaskList");
            // Ustaw nazwę listy zadań aktywnych
            ActiveTaskViewName = GetActiveTaskViewName()[viewIndex];
            RaisePropertyChanged("ActiveTaskViewName");

            // Zapisz zmiany
            LocalStorage.SettingsStorage.SetActiveTasksIndex(viewIndex);
        }


        //
        // Ustaw dane zadań zakończonych
        //
        public void SetCompletedTasks(int viewIndex)
        {
            // Lista kategorii
            List<Category> categoriesList = LocalStorage.CategoryStorage.GetData();
            // Lista zadań
            List<Task> tasksList = LocalStorage.TaskStorage.GetData();
            // Lista cykli
            List<PomodoroCycle> cyclesList = LocalStorage.CycleStorage.GetData();

            // Ustaw listę zadań zakończonych
            CompletedTaskList = TasksManager.GetCompletedTasksList(tasksList, categoriesList, cyclesList, viewIndex);
            // Odśwież
            RaisePropertyChanged("CompletedTaskList");

            // Ustaw nazwę listy zadań zakończonych
            CompletedTaskViewName = GetCompletedTaskViewName()[viewIndex];
            // Odśwież
            RaisePropertyChanged("CompletedTaskViewName");

            // Zapisz zmiany
            LocalStorage.SettingsStorage.SetCompletedTasksIndex(viewIndex);
        }


        //
        // Ustaw dane kategori
        //
        public void SetCategories(int viewIndex)
        {
            // Lista kategorii
            List<Category> categoriesList = LocalStorage.CategoryStorage.GetData();
            // Lista zadań
            List<Task> tasksList = LocalStorage.TaskStorage.GetData();
            // Lista cykli
            List<PomodoroCycle> cyclesList = LocalStorage.CycleStorage.GetData();

            // Ustaw listę kategorii
            CategoryList = CategoriesManager.GetCategoriesList(categoriesList, tasksList, cyclesList, viewIndex);
            // Odśwież
            RaisePropertyChanged("CategoryList");

            // Ustaw nazwę listy kategorii
            CategoryViewName = GetCategoryViewName()[viewIndex];
            // Odśwież
            RaisePropertyChanged("CategoryViewName");

            // Zapisz zmiany
            LocalStorage.SettingsStorage.SetCategoryIndex(viewIndex);
        }


        //
        // Ustaw nazwę sorotwanie ActiveTaskViewName
        //
        private string[] GetActiveTaskViewName()
        {
            var loader = new ResourceLoader();
            string[] names = { 
                                loader.GetString("ActiveTasksByName"),
                                loader.GetString("ActiveTasksByAddDate"),
                                loader.GetString("ActiveTasksByEditDate"),
                                loader.GetString("ActiveTasksByTime"),
                                loader.GetString("ActiveTasksByCategory")
                             };
            return names;
        }


        //
        // Ustaw nazwę sorotwania CompletedTaskViewName
        //
        private string[] GetCompletedTaskViewName()
        {
            var loader = new ResourceLoader();
            string[] names = { 
                                loader.GetString("CompletedTasksByName"),
                                loader.GetString("CompletedTasksByAddDate"),
                                loader.GetString("CompletedTasksByEditDate"),
                                loader.GetString("CompletedTasksByTime"),
                                loader.GetString("CompletedTasksByCategory")
                             };
            return names;
        }


        //
        // Ustaw nazwę sortowania CategoryViewName
        //
        private string[] GetCategoryViewName()
        {
            var loader = new ResourceLoader();
            string[] names = { 
                                loader.GetString("CategoriesByName"),
                                loader.GetString("CategoriesByTasksCount"),
                                loader.GetString("CategoriesByCyclesCount"),
                                loader.GetString("CategoriesByTime")
                             };
            return names;
        }


        // 
        // Usuń zadanie
        //
        public async void DeleteTask(string taskId)
        {
            // Pytanie
            var loader = new ResourceLoader();
            //var dialog = new MessageDialog("Usuniętego zadania nie można przywrócić", "Czy napewno chcesz usunąć zadanie?");
            var dialog = new MessageDialog(loader.GetString("DeleteTaskDialogContent"), loader.GetString("DeleteTaskDialogTitle"));
            dialog.Commands.Add(new UICommand(loader.GetString("DeleteButton"), command => { }, 0));
            dialog.Commands.Add(new UICommand(loader.GetString("CancelButton"), command => { }, 1));
            var result = await dialog.ShowAsync();
            // Jeśli wybrano usuń
            if ((int)result.Id == 0)
            {
                // usuń zadanie
                LocalStorage.TaskStorage.RemoveItem(taskId);
                LocalStorage.CycleStorage.RemoveCycleOfTaskIndex(taskId);
                // Odśwież listę
                SetAllData();
            }
        }


        //
        // Zmień typ zadania
        //
        public void ChangeTasktType(string taskId)
        { 
            // Zmień zadanie
            LocalStorage.TaskStorage.ChangeTaskType(taskId);
            // Odśwież listę
            SetAllData();
        }


        //
        // Usuwa kategorie
        //
        public async void DeleteCategory(string categoryId)
        {
            // Pytanie
            var loader = new ResourceLoader();
            //var dialog = new MessageDialog("Usuniętej kategorii nie można przywrócić", "Czy napewno chcesz usunąć kategorię?");
            var dialog = new MessageDialog(loader.GetString("DeleteCategoryDialogContent"), loader.GetString("DeleteCategoryDialogTitle"));
            dialog.Commands.Add(new UICommand(loader.GetString("DeleteButton"), command => { }, 0));
            dialog.Commands.Add(new UICommand(loader.GetString("CancelButton"), command => { }, 1));
            var result = await dialog.ShowAsync();
            // Jeśli wybrano usuń
            if ((int)result.Id == 0)
            {
                // Usuń kategorię
                LocalStorage.CategoryStorage.RemoveItem(categoryId);
                //TODO: Przenieś zadania z usuwanej kateogorii do domyślnej

                // Odśwież listę
                SetAllData();
            }
        }

        #region INotifyPropertyChanged
        // Deklaracja ReisePropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion

        #region Singleton
        //
        // Singleton
        //
        private static TasksViewModel _instance;
        public static TasksViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TasksViewModel();
                return _instance;
            }
        }
#endregion

    }
}
