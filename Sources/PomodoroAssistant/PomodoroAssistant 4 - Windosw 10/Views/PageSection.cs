using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using GalaSoft.MvvmLight;


namespace PomodoroAssistant.Views
{
    public class PageSection : ViewModelBase
    {
        // Domyślna długość sekcji
        private int _defaultSectionWidth = 450;

        // Długość sedcji
        private int _sectionWidth = 400;
        public int SectionWidth
        {
            get { return _sectionWidth; }
            private set
            {
                Set<int>(() => SectionWidth, ref _sectionWidth, value);
            }
        }


        //
        // Konstruktor
        //
        public PageSection(int defaultSectionWidth = 450)
        {
            _defaultSectionWidth = defaultSectionWidth;
        }


        /// <summary>
        /// Ustawia długość strony
        /// </summary>
        /// <param name="currentPageWidth">Długość strony</param>
        public void SetPageWidth(int currentPageWidth)
        {
            SectionWidth = CalculateSectionWidth(currentPageWidth);
        }


        /// <summary>
        /// Oblicza długość sekcji na podstawie długości strony
        /// </summary>
        /// <param name="pageWidth">Długość strony</param>
        /// <returns>Dłogość sekcji</returns>
        private int CalculateSectionWidth(int pageWidth)
        {
            // Domyślna długość sekcji wynosi 450
            int sectionWidth = _defaultSectionWidth;
            // Jeśli długość strony jest mniejsza od 500 to oblicz długość sekcji
            if (pageWidth < 500)
            {
                sectionWidth = pageWidth - 48;
            }
            // Zwróć
            return sectionWidth;
        }
    }
}
