using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Display;

namespace Atrx.Mobile.Windows.Pomodoro.Settings
{
    public class DisplayManager
    {
        private static DisplayRequest _display = null;

        //
        // Pozostawia ekran włączony
        //
        public static void KeepDisplayOn()
        {
            if (_display == null)
            {
                _display = new DisplayRequest();
                _display.RequestActive();
            }
        }


        //
        // Pozwól aby ekran się wyłączał automatycznie
        //
        public static void KeepDisplayOff()
        {
            if (_display != null)
            {
                _display.RequestRelease();
                _display = null;
            }
        }
    }
}
