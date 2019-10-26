using Atrx.Mobile.Windows.Pomodoro.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrx.Mobile.Windows.Pomodoro.Repository.CurrentStateLocalData
{
    /// <summary>
    /// Odpowiada za zapisywanie i odczytywanie Stanu programu
    /// </summary>
    public class CurrentStateLocalData
    {
        /// <summary>
        /// Stan
        /// </summary>
        private CurrentState _currentState = null;
        /// <summary>
        /// Nazwa pliku ustawień
        /// </summary>
        private const string FILE_NAME = "PomodoroAssistantCurrentState.dat";


        /// <summary>
        /// Konstruktor
        /// </summary>
        public CurrentStateLocalData()
        {
            // Odczytaj ustawienia
            //LoadData(FILE_NAME);
            // Ustaw domyślne
            _currentState = GetDefaultState();
        }


        /// <summary>
        /// Ustawia stan
        /// </summary>
        /// <param name="newState">Nowy stan</param>
        public void SetState(CurrentState newState)
        {
            // Sprawdź ustawienia
            if (_currentState != newState)
            {
                // Ustaw
                _currentState = newState;
                // Zapisz ustawienia
                SaveData(FILE_NAME);
            }
        }


        /// <summary>
        /// Zwraca stan
        /// </summary>
        /// <returns>Zwracane ustawienia</returns>
        public CurrentState GetState()
        {
            // Zwróć stan
            return _currentState;
        }


        /// <summary>
        /// Odczytuje stan z pliku
        /// </summary>
        /// <returns>Odczytane ustawienia</returns>
        private async void LoadData(string fileName)
        {
            // Odczytaj
            XmlReader xmlReader = new XmlReader(fileName);
            _currentState = await xmlReader.ReadAsync<CurrentState>();
            // Jesli ustawienia puste
            if (_currentState == null)
            {
                _currentState = GetDefaultState();
            }
        }


        /// <summary>
        /// Zapisuje stan do pliku
        /// </summary>
        private async void SaveData(string fileName)
        {
            // Zapisz dane
            XmlSaver xmlSaver = new XmlSaver(fileName);
            await xmlSaver.SaveAsync<CurrentState>(_currentState);
        }


        /// <summary>
        /// Zwraca domyślny statn
        /// </summary>
        /// <returns>Stan</returns>
        private CurrentState GetDefaultState()
        {
            // Domyślne ustawienia
            CurrentState currentState = new CurrentState()
            {
                DailyTarget = 0,
                LongBreakAfter = 0,
                IsDailyTargetAchived = false
            };
            // Zwróć ustawienia
            return currentState;
        }


        #region Instance

        /// <summary>
        /// Singelton
        /// </summary>
        private static CurrentStateLocalData _instance = null;
        public static CurrentStateLocalData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CurrentStateLocalData();
                return _instance;
            }
        }

        #endregion
    }
}
