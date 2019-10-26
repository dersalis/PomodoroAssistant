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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PomodoroAssistant.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        // Rozmiar sekcji
        private PageSection _pageSection = new PageSection();


        /// <summary>
        /// KONSTRUKTOR
        /// </summary>
        public AboutPage()
        {
            this.InitializeComponent();
            // DataContext
            this.DataContext = _pageSection;
        }


        //
        // Odpowiada za zmianę rozmiaru
        //
        private void pageAbout_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int currentPageWidth = (int)this.ActualWidth;
            _pageSection.SetPageWidth(currentPageWidth);
        }

    }
}
