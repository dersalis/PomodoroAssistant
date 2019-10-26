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

using Windows.Phone.UI.Input;
using PomodoroAssistantPlus.Model;
using PomodoroAssistantPlus.ViewModel;
using PomodoroAssistantPlus.LocalStorage;
using PomodoroAssistantPlus.Pomodoro;
using Windows.ApplicationModel.Resources;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PomodoroAssistantPlus.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditCategoryPage : Page
    {
        //
        AddCategoryViewModel _category = AddCategoryViewModel.Instance;
        // Przycisk app bar
        CommandBar commandBar;
        AppBarButton appBarButton;

        // Wybrana kategoria
        Category _selectedCategory;
        string _saveCategoryName;
        string _saveCategoryColor;


        public EditCategoryPage()
        {
            this.InitializeComponent();

            // Data context
            DataContext = _category;

            // Naciśnięcie przycisku Back
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            // Ustaw AppBar
            this.BottomAppBar = CreateAddCategoryCommandBar();
            // Ukryj przycisk
            commandBar = BottomAppBar as CommandBar;
            appBarButton = commandBar.PrimaryCommands[0] as AppBarButton;
            appBarButton.IsEnabled = false;
            // Ustaw status bar
            SetStatusBar();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Pobierz parametr przekazany z poprzedniej strony - id zadania
            var parameter = e.Parameter as string;
            // Utwórz id zadania
            Guid categoryId = new Guid(parameter);
            // Zwróć zadania o podanym id
            _selectedCategory = LocalStorage.CategoryStorage.GetCategoryOfId(categoryId.ToString());
            _saveCategoryName = _selectedCategory.Name;
            _saveCategoryColor = _selectedCategory.Color;
            _category.CategoryName = _selectedCategory.Name;
            _category.CategoryColor = new SolidColorBrush(ColorRevert.ToColor(_selectedCategory.Color));
        }

        //
        // Zdarzenie naciśnięcia przycisku Back
        //
        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }


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
        // Tworzy pasek Aktywnych zadań
        //
        private CommandBar CreateAddCategoryCommandBar()
        {
            // Nowy pasek
            CommandBar bar = new Windows.UI.Xaml.Controls.CommandBar();
            // Tło
            bar.Background = new SolidColorBrush(ColorRevert.ToColor("#FF932C1B"));
            // Sposób wyświetlania
            //bar.ClosedDisplayMode = Windows.UI.Xaml.Controls.AppBarClosedDisplayMode.Minimal;

            AppBarButton addBarButton = new Windows.UI.Xaml.Controls.AppBarButton();
            addBarButton.Icon = new SymbolIcon(Symbol.Accept);

            var loader = new ResourceLoader();
            addBarButton.Label = loader.GetString("abbAddCategory");
            addBarButton.Click += new RoutedEventHandler(addBarButton_Click);

            // Przycisk dodaj
            bar.PrimaryCommands.Add(addBarButton);

            return bar;
        }


        private void addBarButton_Click(object sender, RoutedEventArgs e)
        {
            // Edytuj kategorię
            _category.EditCategory(_selectedCategory);
            // Opuść stronę
            if (this.Frame.CanGoBack) this.Frame.GoBack();
        }

        private void txtCategoryName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Sprawdz czy wprowadzono tekst
            if ((sender as TextBox).Text == _saveCategoryName)
                appBarButton.IsEnabled = false;
            else
                appBarButton.IsEnabled = true;
        }

        private void lstColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Jeśli nic nie wybrano to zakończ
            if (!e.AddedItems.Any())
            {
                return;
            }
            // Pobierz wybrany element
            var selectedItem = e.AddedItems.First() as CategoryColor;
            SolidColorBrush color = selectedItem.Color;
            _category.CategoryColor = color;
            // Jeśli kolor zmieniono i są różne to pokaż przycisk
            if (_saveCategoryColor == color.ToString())
                appBarButton.IsEnabled = false;
            else
                appBarButton.IsEnabled = true;
        }
    }
}
