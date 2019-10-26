/**
* Utworzyć pierwszą instancję w pliku App.xaml
**/
using Atrx.Mobile.Windows.Pomodoro.Repository.Models;
using System.Collections.Generic;


namespace Atrx.Mobile.Windows.Pomodoro.Repository.CyclesLocalData
{
    /// <summary>
    /// Odpowiada za zapisywanie i odczytywanie cykli
    /// </summary>
    public class CyclesLocalData
    {
        /// <summary>
        /// Lista cykli
        /// </summary>
        private List<Cycle> _cycles = null;
        /// <summary>
        /// Nazwa pliku
        /// </summary>
        private const string FILE_NAME = "PomodoroAssistantCycles.dat";


        /// <summary>
        /// Konstruktor
        /// </summary>
        public CyclesLocalData()
        {
            // Odczytaj ustawienia
            LoadData(FILE_NAME);
        }


        /// <summary>
        /// Dodaje nowy cykl
        /// </summary>
        /// <param name="newCyle">Nowy cykl</param>
        public void AddCycle(Cycle newCyle)
        {
            // Sprawdź czy nie jest pusty
            if (newCyle != null)
            {
                // Dodaj
                _cycles.Add(newCyle);
                // Zapisz
                SaveData(FILE_NAME, _cycles);
            }
        }


        /// <summary>
        /// Zwraca cykle
        /// </summary>
        /// <returns></returns>
        public List<Cycle> GetCycles()
        {
            // Zwróć
            return _cycles;
        }


        /// <summary>
        /// Odczytuje dane
        /// </summary>
        /// <param name="fileName">Nazwa pliku</param>
        private async void LoadData(string fileName)
        {
            // Odczytaj
            XmlReader xmlReader = new XmlReader(fileName);
            _cycles = await xmlReader.ReadAsync<List<Cycle>>();
            if (_cycles == null)
                _cycles = new List<Cycle>();
        }


        /// <summary>
        /// Zapisuje cykle do pliku
        /// </summary>
        /// <param name="fileName">Nazwa pliku</param>
        /// <param name="cyclesList">Lista cykli</param>
        private async void SaveData(string fileName, List<Cycle> cyclesList)
        {
            // Zapisz dane
            XmlSaver xmlSaver = new XmlSaver(fileName);
            await xmlSaver.SaveAsync<List<Cycle>>(cyclesList);
        }

        #region Instance

        /// <summary>
        /// Singleton
        /// </summary>
        private static CyclesLocalData _instance = null;
        public static CyclesLocalData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CyclesLocalData();
                return _instance;
            }
        }

        #endregion
    }
}
