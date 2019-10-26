using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

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

            this.NavigationCacheMode = NavigationCacheMode.Required;

            // Ustaw Status Bar
            SetStatusBar();
        }


        //
        // Ustawia Status Bar
        //
        private void SetStatusBar()
        {
            // Status bar
            Windows.UI.ViewManagement.StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            statusBar.ForegroundColor = Windows.UI.Colors.Gray;
        }


        //
        // Wykonuje przy otwieraniu strony
        //
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
//#if PLUS_RELEASE
//            // Ukryj rekalamę
//            AdPanel.Visibility = Visibility.Collapsed;
//#endif
            ViewFrame.Navigate(typeof(Pages.PomodoroPage));

            // Reklama
            AdDuplex.Universal.Controls.WinPhone.XAML.Tracking.AdDuplexTrackingSDK.StartTracking("d2416005-72f0-47b7-8778-e646381dd973");
        }


        //
        // Przechodzi do strony About
        //
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            // Jeśli nie jesteś na stronie About to przejdź tam
            if (ViewFrame.CurrentSourcePageType != typeof(Pages.AboutPage))
            {
                //if (TimerState.GetCurrentState() == TimerStates.Stopped)
                //    ViewFrame.Navigate(typeof(Pages.AboutPage));
                //else
                //{
                //    ShowAboutMessage();
                //}

                ViewFrame.Navigate(typeof(Pages.AboutPage));
            }
        }


        //
        // Przechodzi do strony Usuwanie reklamy
        //
        private void btnRemoveAd_Click(object sender, RoutedEventArgs e)
        {

        }


        //
        // Przechodzi do strony Sklepu z aplikacjami
        //
        private async void btnMoreApps_Click(object sender, RoutedEventArgs e)
        {
            // Przenieś do sklepu
            string keyword = "Damian Ruta";
            var uri = new Uri(string.Format(@"ms-windows-store:search?keyword={0}", keyword));
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        //
        // Przechodzi do strony Settings
        //
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // Jeśli nie jesteś na stronie Settings to przejdź tam
            if (ViewFrame.CurrentSourcePageType != typeof(Pages.SettingsPage))
            {
                if (TimerState.GetCurrentState() == TimerStates.Stopped)
                    ViewFrame.Navigate(typeof(Pages.SettingsPage));
                else
                {
                    ShowSettingMessage();
                }
            }
        }


        private async void ShowSettingMessage()
        {
            var loader = new ResourceLoader();
            string title = loader.GetString("SettingMessageTitle");
            string text = loader.GetString("SettingMessageText");

            MessageDialog message = new MessageDialog(text, title);
            await message.ShowAsync();
        }


        private async void ShowAboutMessage()
        {
            var loader = new ResourceLoader();
            string title = loader.GetString("AboutMessageTitle");
            string text = loader.GetString("AboutMessageText");

            MessageDialog message = new MessageDialog(text, title);
            await message.ShowAsync();
        }
    }
}
