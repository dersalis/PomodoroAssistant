using PomodoroAssistant.ViewModels;
using PomodoroAssistant.ViewsModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PomodoroAssistant.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private PageSection _pageSection = new PageSection(); 

        /// <summary>
        /// KONSTRUKTOR
        /// </summary>
        public SettingsPage()
        {
            this.InitializeComponent();
            this.DataContext = _pageSection;
        }


        /// <summary>
        /// Odpowiada na zmianę rozmiaru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageSettings_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int currentPageWidth = (int)this.ActualWidth;
            _pageSection.SetPageWidth(currentPageWidth);
        }


        /// <summary>
        /// Reaguje na opuszczenie komponentu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliWorkDuration_LostFocus(object sender, RoutedEventArgs e)
        {
            // Odszukaj DataContext
            var currentDataContext = ((sender as Slider).DataContext as SettingsViewModel);
            // Zapisz ustawienia
            currentDataContext.SaveSettings();
            // Uaktualnia ustawienia na stronie Timer
            //TimerViewModel.Instance.InitSettings();
        }
    }
}
