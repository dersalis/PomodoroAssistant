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
using Windows.ApplicationModel;
using Windows.ApplicationModel.Email;
using Windows.ApplicationModel.Store;
using Windows.Networking.Connectivity;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PomodoroAssistant.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            this.InitializeComponent();

            // Naciśnięcie przycisku Back
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
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
            txtAppVersion.Text = GetAppVersion();
        }


        //
        // Zwraca wersję aplikacji
        //
        private string GetAppVersion()
        {
            string appVersion = string.Format("{0}.{1}.{2}.{3}",
                    Package.Current.Id.Version.Major,
                    Package.Current.Id.Version.Minor,
                    Package.Current.Id.Version.Build,
                    Package.Current.Id.Version.Revision);

            return appVersion;
        }


        //
        // Przejdź do mojego Twitter'a
        //
        private async void btnMyTwitter_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Sprawdzanie połącznia  
            string uriToLaunch = @"https://twitter.com/damianruta";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }


        //
        // Przejdź do Twittera Pomodoro
        //
        private async void btnPomodoroTwitter_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Sprawdzanie połącznia  
            string uriToLaunch = @"https://twitter.com/usepomodoro";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }


        //
        // Wyślij email
        //
        private async void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            var email = new Windows.ApplicationModel.Email.EmailMessage();
            email.To.Add(new EmailRecipient("pomodoroassistant@aturex.pl"));
            email.Subject = "PomodoroAssistant User";
            await EmailManager.ShowComposeNewEmailAsync(email);
        }


        //
        // Przekierowanie do strony oceniania
        //
        private async void btnRateApp_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Sprawdzanie połącznia  
            //CheckNetwork();
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + CurrentApp.AppId));
        }


        //
        // Sprawdza połączenie z siecią
        //
        private bool CheckNetwork()
        {
            // Brak połączenia z siecią. Zmień ustawienia lub sprubój później.
            bool isNetwork = false;

            ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();

            if (profile != null && profile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
            {
                System.Diagnostics.Debug.WriteLine("*** Połączono ***");
            }
            else
            {
                
            }

            var networkInformation = NetworkInformation.GetConnectionProfiles();
            if (networkInformation.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("*** Nie połączono ***");
            }

            return isNetwork;
        }
    }
}
