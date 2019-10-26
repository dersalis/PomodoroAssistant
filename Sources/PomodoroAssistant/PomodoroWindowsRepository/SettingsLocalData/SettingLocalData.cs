/**
* Utworzyć pierwszą instancję w pliku App.xaml
**/
using Atrx.Mobile.Windows.Pomodoro.Repository.Models;

namespace Atrx.Mobile.Windows.Pomodoro.Repository.SettingsLocalData
{
    /// <summary>
    /// Odpowiada za zapisywanie i odczytywanie ustawień
    /// </summary>
    public class SettingLocalData
    {
        /// <summary>
        /// Ustawienia
        /// </summary>
        private Settings _settrings = null;
        /// <summary>
        /// Nazwa pliku ustawień
        /// </summary>
        private const string FILE_NAME = "PomodoroAssistantSettings.dat";

        /// <summary>
        /// Konstruktor
        /// </summary>
        public SettingLocalData()
        {
            // Odczytaj ustawienia
            LoadData(FILE_NAME);
        }


        /// <summary>
        /// Ustawia ustawienia
        /// </summary>
        /// <param name="newSettings"></param>
        public void SetSettings(Settings newSettings)
        {
            // Sprawdź ustawienia
            if (_settrings != newSettings)
            {
                // Ustaw
                _settrings = newSettings;
                // Zapisz ustawienia
                SaveData(FILE_NAME, _settrings);
            }
        }

        /// <summary>
        /// Zwraca ustawienia
        /// </summary>
        /// <returns>Zwracane ustawienia</returns>
        public Settings GetSettings()
        {
            //if(_settrings == null)
                //LoadData(FILE_NAME);
            // Zwróć ustawienia
            return _settrings;
        }

        /// <summary>
        /// Odczytuje ustawienia z pliku
        /// </summary>
        /// <returns>Odczytane ustawienia</returns>
        private async void LoadData(string fileName)
        {
            // Odczytaj
            XmlReader xmlReader = new XmlReader(fileName);
            _settrings = await xmlReader.ReadAsync<Settings>();
            // Jesli ustawienia puste
            if (_settrings == null)
            {
                _settrings = GetDefaultSettings();
            }
        }

        /// <summary>
        /// Zapisuje ustawienia do pliku
        /// </summary>
        /// <param name="newSettings">Nowe ustawienia</param>
        private async void SaveData(string fileName, Settings newSettings)
        {
            // Zapisz dane
            XmlSaver xmlSaver = new XmlSaver(fileName);
            await xmlSaver.SaveAsync<Settings>(_settrings);
        }


        /// <summary>
        /// Zwraca domyślne ustawienia
        /// </summary>
        /// <returns></returns>
        private Settings GetDefaultSettings()
        {
            // Domyślne ustawienia
            Settings settings = new Settings()
            {
                WorkDuration = 25,
                ShorBreakDuration = 5,
                LongBreakDuration = 15,
                DailyTarget = 7,
                PomodoroToLongBreak = 4,
                IsAutoContinue = false,
                IsMuteSound = false,
                IsSceenOn = false
            };
            // Zwróć ustawienia
            return settings;
        }

        #region Instance

        /// <summary>
        /// Singelton
        /// </summary>
        private static SettingLocalData _instance = null;
        public static SettingLocalData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SettingLocalData();
                return _instance;
            }
        }

        #endregion
    }
}
