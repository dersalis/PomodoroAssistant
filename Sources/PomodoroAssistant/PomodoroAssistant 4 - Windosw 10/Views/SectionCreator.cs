using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroAssistant.Views
{
    public static class SectionCreator
    {
        /// <summary>
        /// Oblicza długość sekcji na podstawie długości strony
        /// </summary>
        /// <param name="pageWidth">Długość strony</param>
        /// <returns>Dłogość sekcji</returns>
        public static int CalculateSectionWidth(int pageWidth)
        {
            // Domyślna długość sekcji wynosi 450
            int sectionWidth = 450;
            // Jeśli długość strony jest mniejsza od 500 to oblicz długość sekcji
            if (pageWidth < 500)
            {
                sectionWidth = pageWidth - 48;
            }
            // Zwróć
            return sectionWidth;
        }


        public static int CalculateSectionHeight(int pageHeight)
        {
            return pageHeight - 22;
        }
    }
}
