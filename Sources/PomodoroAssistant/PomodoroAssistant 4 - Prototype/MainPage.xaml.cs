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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PomodoroAssistant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //Jeśli windows 10
            HideTitleBar();
            // Ukryj status bar
            HideStatusBar();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TasksFrame.Navigate(typeof(Views.TasksPage));
            TimerFrame.Navigate(typeof(Views.TimerPage));
            ReportsFrame.Navigate(typeof(Views.ReportsPage));
            SettingsFrame.Navigate(typeof(Views.SettingsPage));
        }

        //
        // Ukrywa pasek tytułowy - Windows 10
        //
        private void HideTitleBar()
        {
            var applicationView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            var titleBar = applicationView.TitleBar;
            Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonForegroundColor = Windows.UI.Colors.LightGray;
        }

        // 
        // Ukrywa status bar
        //
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
