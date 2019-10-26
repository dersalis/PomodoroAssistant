using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;
using System;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Store;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace PomodoroAssistant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Nazwa licencji
        private const string LICENSE_NAME = "FullVersion";

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

            CheckLicense();
        }


        //
        // Przechodzi do strony About
        //
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            // Jeśli nie jesteś na stronie About to przejdź tam
            if (ViewFrame.CurrentSourcePageType != typeof(Pages.AboutPage))
            {
                // Jeśli nie jesteś na stronie About to przejdz tam
                if (ViewFrame.CurrentSourcePageType != typeof(Pages.AboutPage))
                {
                    if (TimerState.GetCurrentState() == TimerStates.Stopped)
                        ViewFrame.Navigate(typeof(Pages.AboutPage));
                    else
                        ShowAboutMessage();
                }
                
            }
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


        private async void btnTwitter_Click(object sender, RoutedEventArgs e)
        {
            string uriToLaunch = @"https://twitter.com/usepomodoro";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }


        private async void btnFacebook_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Sprawdzanie połącznia  
            string uriToLaunch = @"https://www.facebook.com/pomodoroassistant";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void btnRemoveAd_Click(object sender, RoutedEventArgs e)
        {
            if (!Windows.ApplicationModel.Store.CurrentApp.LicenseInformation.ProductLicenses[LICENSE_NAME].IsActive)
            {
                ListingInformation li = await Windows.ApplicationModel.Store.CurrentApp.LoadListingInformationAsync();
                string pID = li.ProductListings[LICENSE_NAME].ProductId;

                //string receipt = await Windows.ApplicationModel.Store.CurrentApp.RequestProductPurchaseAsync(pID, false);

                CheckLicense();
            }
        }


        private async void CheckLicense()
        {
            try
            {
                //StoreManager mySM = new StoreManager();
                ListingInformation li = await Windows.ApplicationModel.Store.CurrentApp.LoadListingInformationAsync();

                foreach (string key in li.ProductListings.Keys)
                {
                    ProductListing pListing = li.ProductListings[key];
                    System.Diagnostics.Debug.WriteLine(key);

                    if (key == LICENSE_NAME)
                    {
                        btnRemoveAd.Visibility = Visibility.Collapsed;
                        AdPanel.Visibility = Visibility.Collapsed;
                    }
                    
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }
    }
}
