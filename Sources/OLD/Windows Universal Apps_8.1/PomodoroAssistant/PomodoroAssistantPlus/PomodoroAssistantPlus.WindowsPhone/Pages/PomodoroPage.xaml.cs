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
using Windows.UI.Popups;
//using System.Windows;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PomodoroAssistantPlus.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PomodoroPage : Page
    {
        public PomodoroPage()
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
            // Sprawdź czy pomodoro jest uruchomiony
            if (true)
            {
                // Opuść stronę
                if (Frame.CanGoBack)
                {
                    e.Handled = true;
                    Frame.GoBack();
                }
            }
            else
            {  
                // Wiadomość

                MessageDialog dialog = new MessageDialog("Spowoduje to zakończenie aktualnego zadania i opuszczenie strony.", "Czy chcesz zakończyć zadanie?");
                dialog.Commands.Add(new UICommand { Label = "No", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "Yes", Id = 1 });
                var res = dialog.ShowAsync();

                if ((int)res.Id == 0)
                {
                    // Nie opuszczaj strony
                    e.Handled = false;
                }
                else
                {
                    // Zatrzymaj zadanie 

                    // Opuść stronę
                    if (Frame.CanGoBack)
                    {
                        e.Handled = true;

                        Frame.GoBack();
                    }
                }
            }


           
        }


       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Pobierz parametr przekazany z poprzedniej strony - id zadania
            var parameter = e.Parameter as string;
            // Utwórz id zadania
            Guid taskId = new Guid(parameter);
        }
    }
}
