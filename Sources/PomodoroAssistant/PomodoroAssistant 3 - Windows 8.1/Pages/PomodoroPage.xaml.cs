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
        //private PomodoroTimerViewModel _pomodoroInstance = null;

        //
        // Konstruktor
        //
        public PomodoroPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TimerViewModel currDataContext = this.DataContext as TimerViewModel;
            currDataContext.LoadCurrentState();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            TimerViewModel currDataContext = this.DataContext as TimerViewModel;
            currDataContext.SaveCurrentState();
        }
    }
}
