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
using Windows.ApplicationModel.Email;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PomodoroAssistantPlus.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        // Status bar
        Windows.UI.ViewManagement.StatusBar _statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();

        public AboutPage()
        {
            this.InitializeComponent();

            // Naciśnięcie przycisku Back
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            // Ustaw status bar
            SetStatusBar();
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

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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


        private async void btnMeTwietter_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"https://twitter.com/damianruta");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void btnPomodoroWebPage_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"https://www.pomodoroassistant.com");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void btnPomodoroTwitter_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"https://twitter.com/pomodoroapps");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void btnPomodoroFacebook_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"https://www.facebook.com/pomodoroassistant");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void btnReviewMe_Click(object sender, RoutedEventArgs e)
        {
            string appid = "a75bfe72-f5a0-4d49-8c14-fdfbc97d2169";
            var uri = new Uri(string.Format("ms-windows-store:reviewapp?appid={0}", appid));
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void btnContact_Click(object sender, RoutedEventArgs e)
        {
            //await Windows.System.Launcher.LaunchUriAsync(new Uri("mailto:hello@pomodoroassistant.com?subject=SomeSubject&body=mail content"));
            
            EmailMessage email = new EmailMessage();
            email.To.Add(new EmailRecipient("hello@pomodoroassistant.com"));
            email.Subject = "Pomdoro Assistant+ user";
            await EmailManager.ShowComposeNewEmailAsync(email); 

        }

        private async void btnStore_Click(object sender, RoutedEventArgs e)
        {
            // Przenieś do sklepu
            string keyword = "Damian Ruta";
            var uri = new Uri(string.Format(@"ms-windows-store:search?keyword={0}", keyword));
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
