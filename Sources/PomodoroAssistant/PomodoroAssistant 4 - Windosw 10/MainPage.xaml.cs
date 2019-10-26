using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PomodoroAssistant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Commands
        public ICommand TasksMenuCommand { get; set; }
        public ICommand TimerMenuCommand { get; set; }
        public ICommand StatisticsMenuCommand { get; set; }
        public ICommand SettingsMenuCommand { get; set; }
        public ICommand AboutMenuCommand { get; set; }
        public ICommand BuyMenuCommand { get; set; }


        /// <summary>
        /// KONSTRUKTOR
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            // Ustaw DataContext
            this.DataContext = this;

            // Ustaw Commands
            SetCommands();

            // Wybierz pozycję menu Zadania
            btnTasks.IsChecked = true;
            TasksMenu();

            //Jeśli windows 10
            HideTitleBar();
            // Ukryj status bar
            HideStatusBar();
        }


        private void TasksMenu()
        {
            // Przejdz do strony
            GeneralFrame.Navigate(typeof(Views.TasksPage));
        }


        private void TimerMenu()
        {
            // Przejdz do strony
            GeneralFrame.Navigate(typeof(Views.TimerPage));
        }


        private void StatisticsMenu()
        {
            // Przejdz do strony
            GeneralFrame.Navigate(typeof(Views.ReportsPage));
        }


        private void SettingsMenu()
        {
            // Przejdz do strony
            GeneralFrame.Navigate(typeof(Views.SettingsPage));
        }


        private void AboutMenu()
        {
            // Przejdz do strony
            GeneralFrame.Navigate(typeof(Views.AboutPage));
        }


        private void BuyMenu()
        {
            // Przejdz do strony
            GeneralFrame.Navigate(typeof(Views.BuyPage));
        }


        /// <summary>
        /// Ustawia Commands
        /// </summary>
        private void SetCommands()
        {
            TasksMenuCommand = new RelayCommand(TasksMenu);
            TimerMenuCommand = new RelayCommand(TimerMenu);
            StatisticsMenuCommand = new RelayCommand(StatisticsMenu);
            SettingsMenuCommand = new RelayCommand(SettingsMenu);
            AboutMenuCommand = new RelayCommand(AboutMenu);
            BuyMenuCommand = new RelayCommand(BuyMenu);
        }

        /// <summary>
        /// Ukrywa pasek tytułowy - Windows 10
        /// </summary>
        private void HideTitleBar()
        {
            var applicationView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            var titleBar = applicationView.TitleBar;
            Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonForegroundColor = Windows.UI.Colors.LightGray;
        }


        /// <summary>
        /// Ukrywa status bar
        /// </summary>
        private void HideStatusBar()
        {
            //var statusBar = StatusBar.GetForCurrentView();
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                var i = Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
            }
        }
    }
}
