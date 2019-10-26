using System.Threading.Tasks;

namespace PomodoroWindowsData.SettingsLocalData
{
    public class SettingLocalData
    {
        /// <summary>
        /// Ustawienia
        /// </summary>
        private Models.Settings _settrings = null;
        /// <summary>
        /// Nazwa pliku ustawień
        /// </summary>
        private const string FILE_NAME = "PomodoroAssistantSettings.dat";

        /// <summary>
        /// Konstruktor
        /// </summary>
        public SettingLocalData()
        {
            LoadData(FILE_NAME);
        }


        /// <summary>
        /// Ustawia ustawienia
        /// </summary>
        /// <param name="newSettings"></param>
        public void SetSettings(Models.Settings newSettings)
        {
            // Sprawdź ustawienia
            if (_settrings != null && _settrings != newSettings)
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
        public Models.Settings GetSettings()
        {
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
            _settrings = await xmlReader.ReadAsync<Models.Settings>();
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
        private async void SaveData(string fileName, Models.Settings newSettings)
        {
            // Zapisz dane
            XmlSaver xmlSaver = new XmlSaver(fileName);
            await xmlSaver.SaveAsync<Models.Settings>(_settrings);
        }


        /// <summary>
        /// Zwraca domyślne ustawienia
        /// </summary>
        /// <returns></returns>
        private Models.Settings GetDefaultSettings()
        {
            // Domyślne ustawienia
            Models.Settings settings = new Models.Settings(25, 5, 15, 7, 4, false, false, false);
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
                if (_instance == null) _instance = new SettingLocalData();
                return _instance;
            }
        }

        #endregion
    }
}
