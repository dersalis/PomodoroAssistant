using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.ApplicationModel.Store;
using PomodoroAssistantPlus.Model;
using PomodoroAssistantPlus.ViewModel;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PomodoroAssistantPlus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Pomodoro 
        TasksViewModel _pomodoro = TasksViewModel.Instance;
        // Sprawdza czy po raz pierwszy uruchomiono stronę
        bool _isFirstStart;
        // Status bar
        Windows.UI.ViewManagement.StatusBar _statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            // Ustaw DataContext
            this.DataContext = _pomodoro;

            // Ustaw pierwszy start
            _isFirstStart = true;

            // Ustaw status bar
            SetStatusBar();
        }

        
        //
        // Metody wczytywane przy starcie strony
        //
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Sprawdz czy to pierwszy start
            if (_isFirstStart)
            {
                // Jeśli pierwszy start to wczytaj dane i ustaw
                // Ustaw dane
                _pomodoro.LoadAndSetData();
                // Już nie będzie pierszego startu
                _isFirstStart = false;
            }
            else
            {
                // Odśwież dane
                _pomodoro.SetAllData();
            }
        }


        #region Pasek aktywnych zadań
        //
        // Tworzy pasek Aktywnych zadań
        //
        private CommandBar CreateActiveTaskCommandBar()
        {
            // Nowy pasek
            CommandBar bar = new Windows.UI.Xaml.Controls.CommandBar();
            // Tło
            //bar.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            // Sposób wyświetlania
            bar.ClosedDisplayMode = Windows.UI.Xaml.Controls.AppBarClosedDisplayMode.Minimal;

            // Przycisk dodaj
            bar.PrimaryCommands.Add(CreateAddBarButton());
            // Przycisk sortuj
            bar.PrimaryCommands.Add(CreateSortActiveTasksAppBarButton());

            // Przycisk ustawienia
            bar.SecondaryCommands.Add(CreateSettingsAppBarButton());
            // Przycisk o programie
            bar.SecondaryCommands.Add(CreateAboutAppBarButton());
            // Przycisk oceń
            bar.SecondaryCommands.Add(CreateReviewAppBarButton());
            // Przycisk inne programy
            bar.SecondaryCommands.Add(CreateOtherAppBarButton());
            
            return bar;
        }
        #endregion

        #region Pasek zakończonych zadań
        //
        // Tworzy pasek Zakończonych zadań
        //
        private CommandBar CreateCompletedTaskCommandBar()
        {
            // Nowy pasek
            CommandBar bar = new Windows.UI.Xaml.Controls.CommandBar();
            // Tło
            //bar.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            // Sposób wyświetlania
            bar.ClosedDisplayMode = Windows.UI.Xaml.Controls.AppBarClosedDisplayMode.Minimal;

            // Przycisk dodaj
            bar.PrimaryCommands.Add(CreateAddBarButton());
            // Przycisk sortuj
            bar.PrimaryCommands.Add(CreateSortCompletedTasksAppBarButton());
            // Przycisk usuń
            bar.PrimaryCommands.Add(CreateDeleteAllCompletedTaskBarButton());

            // Przycisk ustawienia
            bar.SecondaryCommands.Add(CreateSettingsAppBarButton());
            // Przycisk o programie
            bar.SecondaryCommands.Add(CreateAboutAppBarButton());
            // Przycisk oceń
            bar.SecondaryCommands.Add(CreateReviewAppBarButton());
            // Przycisk inne programy
            bar.SecondaryCommands.Add(CreateOtherAppBarButton());

            return bar;
        }
        #endregion

        #region Pasek kategorii
        //
        // Tworzy pasek Kategorii
        //
        private CommandBar CreateCategoryCommandBar()
        {
            // Nowy pasek
            CommandBar bar = new Windows.UI.Xaml.Controls.CommandBar();
            // Tło
            //bar.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            // Sposób wyświetlania
            bar.ClosedDisplayMode = Windows.UI.Xaml.Controls.AppBarClosedDisplayMode.Minimal;

            // Przycisk dodaj
            bar.PrimaryCommands.Add(CreateAddBarButton());
            // Przycisk sortuj
            bar.PrimaryCommands.Add(CreateSortCategoryAppBarButton());

            // Przycisk ustawienia
            bar.SecondaryCommands.Add(CreateSettingsAppBarButton());
            // Przycisk o programie
            bar.SecondaryCommands.Add(CreateAboutAppBarButton());
            // Przycisk oceń
            bar.SecondaryCommands.Add(CreateReviewAppBarButton());
            // Przycisk inne programy
            bar.SecondaryCommands.Add(CreateOtherAppBarButton());

            return bar;
        }
        #endregion

        #region Przycisk Dodaj zadanie / kategorię
        //
        // Tworzy przycisk Dodaj zadanie / kategorię
        //
        private AppBarButton CreateAddBarButton()
        {
            AppBarButton addApparButton = new Windows.UI.Xaml.Controls.AppBarButton();
            MenuFlyout flyout = new Windows.UI.Xaml.Controls.MenuFlyout();

            MenuFlyoutItem addTask = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            addTask.Text = "zadanie";
            addTask.Click += addTask_Click;
            flyout.Items.Add(addTask);

            MenuFlyoutItem addCategory = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            addCategory.Text = "kategorie";
            addCategory.Click += addCategory_Click;
            flyout.Items.Add(addCategory);

            flyout.Items.Add(new MenuFlyoutItem());
            addApparButton.Flyout = flyout;

            addApparButton.Icon = new SymbolIcon(Symbol.Add);
            addApparButton.Label = "dodaj";

            return addApparButton;
        }


        //
        // Naciśnięcie przycisku dodaj zadanie
        //
        private void addTask_Click(object sender, RoutedEventArgs e)
        {
            // Przejdź na stronę dodaj zadanie
            Frame.Navigate(typeof(Pages.AddTaskPage));
        }


        //
        // Naciśnięcie przycisku dodaj kategorię
        //
        private void addCategory_Click(object sender, RoutedEventArgs e)
        {
            // Przejdź na stronę daodaj kategorię
            Frame.Navigate(typeof(Pages.AddCategoryPage));
        }
        #endregion

        #region Przycisk Sortuj aktywne zadania
        //
        // Tworzy przycisk Sotruj
        //
        private AppBarButton CreateSortActiveTasksAppBarButton()
        {
            AppBarButton sortAppBarButton = new Windows.UI.Xaml.Controls.AppBarButton();
            MenuFlyout flyout = new Windows.UI.Xaml.Controls.MenuFlyout();

            MenuFlyoutItem activeSortByName = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            activeSortByName.Text = "wg. nazwy";
            activeSortByName.Click += activeSortByName_Click;
            flyout.Items.Add(activeSortByName);

            MenuFlyoutItem sortByAddDate = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            sortByAddDate.Text = "wg. daty rozpoczęcia";
            sortByAddDate.Click += sortByAddDate_Click;
            flyout.Items.Add(sortByAddDate);

            MenuFlyoutItem sortByLastEditDate = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            sortByLastEditDate.Text = "wg. daty edycji";
            sortByLastEditDate.Click += sortByLastEditDate_Click;
            flyout.Items.Add(sortByLastEditDate);

            //MenuFlyoutItem sortByCycleCount = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            //sortByCycleCount.Text = "wg. liczby cykli";
            //sortByCycleCount.Click += sortByCycleCount_Click;
            //flyout.Items.Add(sortByCycleCount);

            MenuFlyoutItem sortByTotalTime = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            sortByTotalTime.Text = "wg. czasu";
            sortByTotalTime.Click += sortByTotalTime_Click;
            flyout.Items.Add(sortByTotalTime);

            MenuFlyoutItem sortByCategory = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            sortByCategory.Text = "wg. kategorii";
            sortByCategory.Click += sortByCategory_Click;
            flyout.Items.Add(sortByCategory);

            flyout.Items.Add(new MenuFlyoutItem());
            sortAppBarButton.Flyout = flyout;

            sortAppBarButton.Icon = new SymbolIcon(Symbol.Sort);
            sortAppBarButton.Label = "sortuj";

            return sortAppBarButton;
        }


        //
        // Naciśnięcie przycisku Sortuj wg. nazwy
        //
        private void activeSortByName_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. daty utworzenia
        //
        private void sortByAddDate_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //
        // Naciśnięcie przycisku Sortuj wg. daty edycji
        //
        private void sortByLastEditDate_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. liczby cykli
        //
        private void sortByCycleCount_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. czasu
        //
        private void sortByTotalTime_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. kategorii
        //
        private void sortByCategory_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
#endregion

        #region Przycisk Sortuj zakończone zadania
        //
        // Tworzy przycisk Sotruj
        //
        private AppBarButton CreateSortCompletedTasksAppBarButton()
        {
            AppBarButton sortAppBarButton = new Windows.UI.Xaml.Controls.AppBarButton();
            MenuFlyout flyout = new Windows.UI.Xaml.Controls.MenuFlyout();

            MenuFlyoutItem completedSortByName = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            completedSortByName.Text = "wg. nazwy";
            completedSortByName.Click += completedSortByName_Click;
            flyout.Items.Add(completedSortByName);

            MenuFlyoutItem completedSortByAddDate = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            completedSortByAddDate.Text = "wg. daty rozpoczęcia";
            completedSortByAddDate.Click += completedSortByAddDate_Click;
            flyout.Items.Add(completedSortByAddDate);

            MenuFlyoutItem completedSortByLastEditDate = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            completedSortByLastEditDate.Text = "wg. daty zakończenia";
            completedSortByLastEditDate.Click += completedSortByLastEditDate_Click;
            flyout.Items.Add(completedSortByLastEditDate);

            //MenuFlyoutItem completedSortByCycleCount = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            //completedSortByCycleCount.Text = "wg. liczby cykli";
            //completedSortByCycleCount.Click += completedSortByCycleCount_Click;
            //flyout.Items.Add(completedSortByCycleCount);

            MenuFlyoutItem completedSortByTotalTime = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            completedSortByTotalTime.Text = "wg. czasu";
            completedSortByTotalTime.Click += completedSortByTotalTime_Click;
            flyout.Items.Add(completedSortByTotalTime);

            MenuFlyoutItem completedSortByCategory = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            completedSortByCategory.Text = "wg. kategorii";
            completedSortByCategory.Click += completedSortByCategory_Click;
            flyout.Items.Add(completedSortByCategory);

            flyout.Items.Add(new MenuFlyoutItem());
            sortAppBarButton.Flyout = flyout;

            sortAppBarButton.Icon = new SymbolIcon(Symbol.Sort);
            sortAppBarButton.Label = "sortuj";

            return sortAppBarButton;
        }


        //
        // Naciśnięcie przycisku Sortuj wg. nazwy
        //
        private void completedSortByName_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. daty utworzenia
        //
        private void completedSortByAddDate_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. daty zakończenia
        //
        private void completedSortByLastEditDate_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. liczby cykli
        //
        private void completedSortByCycleCount_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. czasu
        //
        private void completedSortByTotalTime_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. kategorii
        //
        private void completedSortByCategory_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Przycisk Sortuj kategorie
        //
        // Tworzy przycisk Sotruj kategorie
        //
        private AppBarButton CreateSortCategoryAppBarButton()
        {
            AppBarButton sortAppBarButton = new Windows.UI.Xaml.Controls.AppBarButton();
            MenuFlyout flyout = new Windows.UI.Xaml.Controls.MenuFlyout();

            MenuFlyoutItem categorySortByName = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            categorySortByName.Text = "wg. nazwy";
            categorySortByName.Click += categorySortByName_Click;
            flyout.Items.Add(categorySortByName);

            MenuFlyoutItem categorySortByTaskCount = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            categorySortByTaskCount.Text = "wg. liczby zadań";
            categorySortByTaskCount.Click += categorySortByTaskCount_Click;
            flyout.Items.Add(categorySortByTaskCount);

            MenuFlyoutItem categorySortByCycleCount = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            categorySortByCycleCount.Text = "wg. liczby cykli";
            categorySortByCycleCount.Click += categorySortByCycleCount_Click;
            flyout.Items.Add(categorySortByCycleCount);

            MenuFlyoutItem categorySortByTotalTime = new Windows.UI.Xaml.Controls.MenuFlyoutItem();
            categorySortByTotalTime.Text = "wg. czasu";
            categorySortByTotalTime.Click += categorySortByTotalTime_Click;
            flyout.Items.Add(categorySortByTotalTime);

            flyout.Items.Add(new MenuFlyoutItem());
            sortAppBarButton.Flyout = flyout;

            sortAppBarButton.Icon = new SymbolIcon(Symbol.Sort);
            sortAppBarButton.Label = "sortuj";

            return sortAppBarButton;
        }


        //
        // Naciśnięcie przycisku Sortuj wg. nazwy
        //
        private void categorySortByName_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //
        // Naciśnięcie przycisku Sortuj wg. liczby zadań
        //
        private void categorySortByTaskCount_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. liczby cykli
        //
        private void categorySortByCycleCount_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
        // Naciśnięcie przycisku Sortuj wg. czasu
        //
        private void categorySortByTotalTime_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Przycisk Ustawienia
        //
        // Tworzy przycisk Ustawienia
        //
        private AppBarButton CreateSettingsAppBarButton()
        {
            AppBarButton settingsAppBarButton = new Windows.UI.Xaml.Controls.AppBarButton();
            settingsAppBarButton.Label = "ustawienia";
            settingsAppBarButton.Click += settingsAppBarButton_Click;

            return settingsAppBarButton;
        }


        //
        // Zdarzenie przycisku Ustawienia
        //
        private void settingsAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            // Przechodzi na stronę
            this.Frame.Navigate(typeof(Pages.SettingsPage));
        }
        #endregion

        #region Przycisk O programie
        //
        // Tworzy przycisk O programie
        //
        private AppBarButton CreateAboutAppBarButton()
        {
            AppBarButton aboutAppBarButton = new Windows.UI.Xaml.Controls.AppBarButton();
            aboutAppBarButton.Label = "o programie";
            aboutAppBarButton.Click += aboutButton_Click;

            return aboutAppBarButton;
        }


        //
        // Zdarzenie przycisku O programie
        //
        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            // Przechodzi na stronę
            this.Frame.Navigate(typeof(Pages.AboutPage));
        }
        #endregion

        #region Przycisk Oceń aplikacje
        //
        // Tworzy przycisk Oceń aplikacje
        //
        private AppBarButton CreateReviewAppBarButton()
        {
            AppBarButton reviewAppBarButton = new Windows.UI.Xaml.Controls.AppBarButton();
            reviewAppBarButton.Label = "oceń aplikacje";
            reviewAppBarButton.Click += reviewAppBarButton_Click;

            return reviewAppBarButton;
        }

        //
        // Zdarzenie przycisku Oceń aplikacje
        //
        private async void reviewAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            string appid = "a75bfe72-f5a0-4d49-8c14-fdfbc97d2169";
            var uri = new Uri(string.Format("ms-windows-store:reviewapp?appid={0}", appid));
            await Windows.System.Launcher.LaunchUriAsync(uri);

            // Szczegóły aplikacji
            //var uri2 = new Uri(string.Format("ms-windows-store:navigate?appid={0}", appid));
            //await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        #endregion

        #region Przycisk Inne aplikacje
        //
        // Tworzy przycisk Inne aplikacje
        //
        private AppBarButton CreateOtherAppBarButton()
        {
            // Przejdź do sklepu
            AppBarButton otherAppBarButton = new Windows.UI.Xaml.Controls.AppBarButton();
            otherAppBarButton.Label = "inne aplikacje";
            otherAppBarButton.Click += otherAppsButton_Click;

            return otherAppBarButton;
        }


        //
        // Zdarzenie przycisku Inne aplikacje
        //
        private async void otherAppsButton_Click(object sender, RoutedEventArgs e)
        {
            // Przenieś do sklepu
            string keyword = "Damian Ruta";
            var uri = new Uri(string.Format(@"ms-windows-store:search?keyword={0}", keyword));
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        #endregion

        #region Przycisk Usuń zakończone zadania
        //
        // Tworzy przycisk Usuń ukończone kategorie
        //
        private AppBarButton CreateDeleteAllCompletedTaskBarButton()
        {
            AppBarButton deleteAllCompletedTaskApparButton = new Windows.UI.Xaml.Controls.AppBarButton();
            deleteAllCompletedTaskApparButton.Icon = new SymbolIcon(Symbol.Delete);
            deleteAllCompletedTaskApparButton.Label = "usuń";
            deleteAllCompletedTaskApparButton.Click += deleteApparButton_Click;

            return deleteAllCompletedTaskApparButton;
        }


        //
        // Zdarzenie przycisku Usuń
        //
        private void deleteApparButton_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }
        #endregion


        //
        // Ustaawia status bar
        //
        private void SetStatusBar()
        {
            // Status bar
            Windows.UI.ViewManagement.StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            statusBar.ForegroundColor = Windows.UI.Colors.Gray;
        }


        //
        // Zdarzenie zachodzące podczas zmiany (przesuwania) Hub'a
        //
        private void hubPomodoro_SectionsInViewChanged(object sender, Windows.UI.Xaml.Controls.SectionsInViewChangedEventArgs e)
        {
            //if(hubPomodoro.SectionsInView[0] == hubActiveTasks)
            //    this.BottomAppBar = CreateActiveTaskCommandBar();
            //if (hubPomodoro.SectionsInView[0] == hubCompletedTasks)
            //    this.BottomAppBar = CreateCompletedTaskCommandBar();
            //if (hubPomodoro.SectionsInView[0] == hubCategories)
            //    this.BottomAppBar = CreateCategoryCommandBar();
            
        }

        
        //
        // Zdarzenie zachodzące podczas wybierania zadania z listy
        //
        private void lstActiveTasks_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            // Jeśli nic nie wybrano to zakończ
            if (!e.AddedItems.Any())
            {
                return;
            }
            // Pobierz wybrany element
            var selectedItem = e.AddedItems.First() as ActiveTaskView;
            string taskId = selectedItem.Id.ToString();

            // Przejdź na stronę i przekaż parametr
            this.Frame.Navigate(typeof(Pages.PomodoroPage), taskId);
        }


        //
        // Zdarzenie zachodzące podczas przytrzymania zadania na liście
        //
        private void lstActiveTasks_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            
            flyoutBase.ShowAt(senderElement);
        }


        //
        //
        //
        private void lstCompletedTasks_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);

            flyoutBase.ShowAt(senderElement);
        }


        //
        // Zdarzenie zachodźące podczas wybierania nagłówka Hub'a
        //
        private void hubPomodoro_SectionHeaderClick(object sender, Windows.UI.Xaml.Controls.HubSectionHeaderClickEventArgs e)
        {
            //switch (e.Section.Tag.ToString())
            //{
            //    case "0":
            //        break;
            //    case "1":
            //        break;
            //    case "2":
            //        break;
            //}
        }

        private void mfiActiveTasksByName_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 0;
            _pomodoro.SetActiveTasks(viewIndex);
        }

        private void mfiActiveTasksByAddDate_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 1;
            _pomodoro.SetActiveTasks(viewIndex);
        }

        private void mfiActiveTasksByEditDate_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 2;
            _pomodoro.SetActiveTasks(viewIndex);
        }

        private void mfiActiveTasksByTime_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 3;
            _pomodoro.SetActiveTasks(viewIndex);
        }

        private void mfiActiveTasksByCategory_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 4;
            _pomodoro.SetActiveTasks(viewIndex);
        }

        private void mfiCompletedTasksByName_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 0;
            _pomodoro.SetCompletedTasks(viewIndex);
        }

        private void mfiCompletedTasksByAddDate_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 1;
            _pomodoro.SetCompletedTasks(viewIndex);
        }

        private void mfiCompletedTasksByEditDate_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 2;
            _pomodoro.SetCompletedTasks(viewIndex);
        }

        private void mfiCompletedTasksByTime_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 3;
            _pomodoro.SetCompletedTasks(viewIndex);
        }

        private void mfiCompletedTasksByCategory_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 4;
            _pomodoro.SetCompletedTasks(viewIndex);
        }

        private void mfiCategoriesByName_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 0;
            _pomodoro.SetCategories(viewIndex);
        }

        private void mfiCategoriesByTasksCount_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 1;
            _pomodoro.SetCategories(viewIndex);
        }

        private void mfiCategoriesByCyclesCount_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 2;
            _pomodoro.SetCategories(viewIndex);
        }

        private void mfiCategoriesByTime_Click(object sender, RoutedEventArgs e)
        {
            int viewIndex = 3;
            _pomodoro.SetCategories(viewIndex);
        }


        //
        // Naciśnięcie Zadania aktywne / Edytuj
        //
        private void mfiActiveTaskEdit_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                var selectedItem = item.DataContext as ActiveTaskView;
                if (selectedItem != null)
                {
                    string taskId = selectedItem.Id;
                    // Przejdź na stronę i przekaż parametr
                    this.Frame.Navigate(typeof(Pages.EditTaskPage), taskId);
                }
            }
        }


        //
        // Naciśnięcie Zadania aktywne / Usuń
        //
        private void mfiActiveTaskDelete_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                var selectedItem = item.DataContext as ActiveTaskView;
                if (selectedItem != null)
                {
                    string taskId = selectedItem.Id;
                    _pomodoro.DeleteTask(taskId);
                }
            }
        }


        //
        // Naciśnięcie Zadania zakończone / Usuń
        //
        private void mfiCompletedTaskDelete_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                var selectedItem = item.DataContext as CompletedTaskView;
                if (selectedItem != null)
                {
                    string taskId = selectedItem.Id;
                    _pomodoro.DeleteTask(taskId);
                }
            }
        }


        //
        // Naciśnięcie Zadania aktywne / Zakończ
        //
        private void mfiActiveTaskFinish_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                var selectedItem = item.DataContext as ActiveTaskView;
                if (selectedItem != null)
                {
                    string taskId = selectedItem.Id;
                    _pomodoro.ChangeTasktType(taskId);
                }
            }
        }


        //
        // Naciśnięcie Zadania zakończone / Przywróć
        //
        private void mfiCompletedTaskStart_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                var selectedItem = item.DataContext as CompletedTaskView;
                if (selectedItem != null)
                {
                    string taskId = selectedItem.Id;
                    _pomodoro.ChangeTasktType(taskId);
                }
            }
        }


        //
        // Naciśnięcie Kategorie / Edytuj
        //
        private void mfiCategoryEdit_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                var selectedItem = item.DataContext as CategoryView;
                if (selectedItem != null)
                {
                    string taskId = selectedItem.Id;
                    // Przejdź na stronę i przekaż parametr
                    this.Frame.Navigate(typeof(Pages.EditCategoryPage), taskId);
                }
            }
        }


        //
        // Naciśnięcie Kategorie / Usuń
        //
        private void mfiCategoryDelete_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                var selectedItem = item.DataContext as CategoryView;
                if (selectedItem != null)
                {
                    string categoryId = selectedItem.Id;
                    // Usuń
                    _pomodoro.DeleteCategory(categoryId);
                }
            }
        }


        

    }
}
