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

using Windows.UI.ApplicationSettings;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PomodoroAssistant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //
        // KONSTRUKTOR
        //
        public MainPage()
        {
            this.InitializeComponent();
        }


        // 
        // Polecenia uruchamiane przy starcie strony
        //
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Dodaje polecenia do panela bocznego
            SettingsPane.GetForCurrentView().CommandsRequested += MainPage_CommandsRequested;
        }


        //
        // Dodaje polecenia do panela bocznego
        //
        private void MainPage_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            // Dodaj panel O programie
            SettingsCommand aboutCommand = new SettingsCommand("o programie", "O programie",
                (handler) =>
                {
                    AboutFlyout sf = new AboutFlyout();
                    sf.Show();
                });
            args.Request.ApplicationCommands.Add(aboutCommand);
        }


        //
        // Naciśnięcie atrapy AppBar
        //
        private void spAppBar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            abarPomodoro.IsOpen = true;
        }


        //
        // Naciśnięcie o programie
        //
        private void btnAbout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AboutFlyout about = new AboutFlyout();
            about.ShowIndependent();
        }
    }
}
