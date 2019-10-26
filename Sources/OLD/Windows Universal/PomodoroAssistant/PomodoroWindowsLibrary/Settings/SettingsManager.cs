using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;

namespace Atrx.Mobile.Windows.Pomodoro.Settings
{
    public static class SettingsManager
    {
        // Ustawienia
        private static PomodoroSettings _settings = null;

        private const string WORK_TIME = "PomodoroTime"; // Nazwa ustawienia czas pomodoro
        private const string LONG_BREAK_TIME = "LongBreakTime"; // Nazwa ustawienia czas długiej przerwy
        private const string SHORT_BREAK_TIME = "ShortBreakTime"; // Nazwa ustawienia czas krótkiej przerwy
        private const string DAILY_TARGET = "DailyTarget"; // Nazwa ustawienia dzienny cel
        private const string POMODOROS_TO_LONG_BREAK = "PomodorosToLongBreak"; // Nazwa ustawienia liczba pomodoro do długiej przerwy
        private const string MUTE_SOUND = "MuteSound"; // Nazwa ustawienia wyciszenie
        private const string AUTO_CONTINUE = "AutoContinue"; // Nazwa ustawienia auto kontynuacja

        //
        // Konstruktor
        //
        static SettingsManager()
        {
            // Odcztaj i ustaw ustawienia
            _settings = ReadAllSettings();
        }


        // Zwraca ustawienia
        public static PomodoroSettings GetSettings()
        {
            // Zwróć ustawienia
            return _settings;
        }


        // Ustawia ustawienia
        public static void SetSettings(PomodoroSettings settings)
        {
            // Ustaw 
            _settings = settings;
            // Zapisz ustawienia
            SaveAllSettings();
        }


        //
        // Zapisz ustawienia
        //
        private static void SaveAllSettings()
        {
            // Zapisz
            SaveSettingsToRomingSettings(WORK_TIME, _settings.WorkDuration.ToString());
            SaveSettingsToRomingSettings(SHORT_BREAK_TIME, _settings.ShorBreakDuration.ToString());
            SaveSettingsToRomingSettings(LONG_BREAK_TIME, _settings.LongBreakDuration.ToString());
            SaveSettingsToRomingSettings(DAILY_TARGET, _settings.DailyTarget.ToString());
            SaveSettingsToRomingSettings(POMODOROS_TO_LONG_BREAK, _settings.PomodoroToLongBreak.ToString());
            SaveSettingsToRomingSettings(MUTE_SOUND, _settings.IsMuteSound.ToString());
            SaveSettingsToRomingSettings(AUTO_CONTINUE, _settings.IsAutoContinue.ToString());
        }


        //
        // Osczytaj ustawienia
        //
        private static PomodoroSettings ReadAllSettings()
        {
            // Tymczasowe ustawienia
            PomodoroSettings set = new PomodoroSettings();

            set.WorkDuration = int.Parse(ReadSettingsFromRomingSettings(WORK_TIME, 25.ToString()));
            set.ShorBreakDuration = int.Parse(ReadSettingsFromRomingSettings(SHORT_BREAK_TIME, 5.ToString()));
            set.LongBreakDuration = int.Parse(ReadSettingsFromRomingSettings(LONG_BREAK_TIME, 15.ToString()));
            set.DailyTarget = int.Parse(ReadSettingsFromRomingSettings(DAILY_TARGET, 7.ToString()));
            set.PomodoroToLongBreak = int.Parse(ReadSettingsFromRomingSettings(POMODOROS_TO_LONG_BREAK, 4.ToString()));
            set.IsMuteSound = bool.Parse(ReadSettingsFromRomingSettings(MUTE_SOUND, true.ToString()));
            set.IsAutoContinue = bool.Parse(ReadSettingsFromRomingSettings(AUTO_CONTINUE, true.ToString()));

            return set;
        }


        //
        // Odczytuje pojedyncze ustawienie z RomingSettings
        //
        private static string ReadSettingsFromRomingSettings(string settingsName, string alternativeValue)
        {
            // Ustaw jako odczytaną wartość, wartość alternatywną
            string value = alternativeValue;
            // Sprawdź czy ustawienie istnieje
            if (ApplicationData.Current.RoamingSettings.Values.ContainsKey(settingsName))
                // Odczytaj ustawienie
                value = (string)ApplicationData.Current.RoamingSettings.Values[settingsName];
            // Zwróć ustawienie
            return value;
        }


        //
        // Zapisuje pojedyncze ustawienie do RomingSettings
        //
        private static void SaveSettingsToRomingSettings(string settingsName, string value)
        {
            // Zapisz ustawienie
            ApplicationData.Current.RoamingSettings.Values[settingsName] = value;
        }
    }
}
