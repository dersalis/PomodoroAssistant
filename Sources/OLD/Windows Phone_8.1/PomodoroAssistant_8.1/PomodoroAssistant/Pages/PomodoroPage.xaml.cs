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

using PomodoroAssistant.ViewModels;
using Atrx.Mobile.Windows.Pomodoro.PomodoroTimer;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PomodoroAssistant.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PomodoroPage : Page
    {
        private PomodoroTimerViewModel _pomodoroInstance = null;

        //
        // Konstruktor
        //
        public PomodoroPage()
        {
            this.InitializeComponent();

            // Ustaw DataContext
            if (_pomodoroInstance == null)
            {
                _pomodoroInstance = PomodoroTimerViewModel.Instance;
                this.DataContext = _pomodoroInstance;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Inicjuj ustawienia
            _pomodoroInstance.InitSettings();
        }


        private void btnStart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PomodoroTimerViewModel currDataContext = (this.DataContext as PomodoroTimerViewModel);
            currDataContext.TimerStart();
        }

        private void btnPause_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PomodoroTimerViewModel currDataContext = (this.DataContext as PomodoroTimerViewModel);
            currDataContext.TimerPause();
        }

        private void btnStop_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PomodoroTimerViewModel currDataContext = (this.DataContext as PomodoroTimerViewModel);
            currDataContext.TimerStop();
        }

        private void flyResetLBA_Click(object sender, RoutedEventArgs e)
        {
            if (TimerState.GetCurrentState() == TimerStates.Stopped)
            {
                PomodoroTimerViewModel currDataContext = this.DataContext as PomodoroTimerViewModel;
                currDataContext.ResetLongBreakAfter();
            }
            else
            {
                ShowSettingMessage();
            }
        }

        private void flyResetDT_Click(object sender, RoutedEventArgs e)
        {
            if (TimerState.GetCurrentState() == TimerStates.Stopped)
            {
                PomodoroTimerViewModel currDataContext = this.DataContext as PomodoroTimerViewModel;
                currDataContext.ResetDailyTarget();
            }
            else
            {
                ShowSettingMessage();
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
    }
}
