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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PomodoroAssistantPlus.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        // Ustawienia
        SettingsViewModel _settings = SettingsViewModel.Instance;

        // Status bar
        Windows.UI.ViewManagement.StatusBar _statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();

        public SettingsPage()
        {
            this.InitializeComponent();

            // Naciśnięcie przycisku Back
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            // Ustaw status bar
            SetStatusBar();

            // Ustaw DataContext
            DataContext = SettingsViewModel.Instance;
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
        // Występuje podczas uruchomienia strony
        //
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }


        //
        // Występuje podczas zamykania strony
        //
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Zapisz ustawienia
            _settings.SaveSettings();
        }
    }
}
