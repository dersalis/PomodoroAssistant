using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Windows.ApplicationModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Windows.ApplicationModel.Email;
using Windows.ApplicationModel.Store;

namespace PomodoroAssistant.ViewsModels
{
    public class AboutViewModel : ViewModelBase
    {
        // Wersja
        private string _version;
        public string Version
        {
            get { return _version; }
            private set { Set<string>(() => Version, ref _version, value); }
        }


        // Commands
        public ICommand DamianTwieterCommand { get; private set; }
        public ICommand PomodoroTwitterCommand { get; private set; }
        public ICommand SendEmailCommand { get; private set; }
        public ICommand RateAppCommand { get; private set; }


        //
        // Konstruktor
        //
        public AboutViewModel()
        {
            // Wersja aplikacji
            Version = GetAppVersion();
            // Commands
            DamianTwieterCommand = new RelayCommand(DamianTwitter);
            PomodoroTwitterCommand = new RelayCommand(PomodoroTwitter);
            SendEmailCommand = new RelayCommand(SendEmail);
            RateAppCommand = new RelayCommand(RateApp);
        }


        /// <summary>
        /// Zwraca wersję aplikacji
        /// </summary>
        /// <returns>Wersja aplikacji</returns>
        private string GetAppVersion()
        {
            string appVersion = string.Format("{0}.{1}.{2}.{3}",
                    Package.Current.Id.Version.Major,
                    Package.Current.Id.Version.Minor,
                    Package.Current.Id.Version.Build,
                    Package.Current.Id.Version.Revision);

            return appVersion;
        }


        /// <summary>
        /// Przekierowuje na stronę twittera
        /// </summary>
        private async void DamianTwitter()
        {
            //TODO: Sprawdzanie połącznia  
            string uriToLaunch = @"https://twitter.com/damianruta";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }


        /// <summary>
        /// Przekierowuje na stronę Twittera
        /// </summary>
        private async void PomodoroTwitter()
        {
            //TODO: Sprawdzanie połącznia  
            string uriToLaunch = @"https://twitter.com/usepomodoro";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }


        /// <summary>
        /// Wysyła emaila
        /// </summary>
        private async void SendEmail()
        {
            var email = new Windows.ApplicationModel.Email.EmailMessage();
            email.To.Add(new EmailRecipient("pomodoroassistant@aturex.pl"));
            email.Subject = "PomodoroAssistant User";
            await EmailManager.ShowComposeNewEmailAsync(email);
        }


        /// <summary>
        /// Przekierowuje do strony oceniania aplikacji
        /// </summary>
        private async void RateApp()
        {
            //TODO: Sprawdzanie połącznia  
            //CheckNetwork();
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + CurrentApp.AppId));
        }
    }
}
