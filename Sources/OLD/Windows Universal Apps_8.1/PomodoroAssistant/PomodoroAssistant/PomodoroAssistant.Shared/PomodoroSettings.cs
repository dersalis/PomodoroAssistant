using System;
using System.Collections.Generic;
using System.Text;

using Windows.Storage;

namespace PomodoroAssistant
{
    public class PomodoroSettings
    {
        private const string POMODORO_TIME = "PomodoroTime"; // Nazwa ustawienia czas pomodoro
        private const string LONG_BREAK_TIME = "LongBreakTime"; // Nazwa ustawienia czas długiej przerwy
        private const string SHORT_BREAK_TIME = "ShortBreakTime"; // Nazwa ustawienia czas krótkiej przerwy
        private const string DAILY_TARGET = "DailyTarget"; // Nazwa ustawienia dzienny cel
        private const string POMODOROS_TO_LONG_BREAK = "PomodorosToLongBreak"; // Nazwa ustawienia liczba pomodoro do długiej przerwy


        //
        // Ogólna metoda zapisująca ustawienia
        //
        private static void SaveSettings(string setName, int setValue)
        {
            ApplicationData.Current.RoamingSettings.Values[setName] = setValue;
        }


        //
        // Ogólna metoda odczytująca ustawienia
        //Sa
        private static int LoadSettings(string setName, int alternativeValue)
        {
            int value = alternativeValue;
            if (ApplicationData.Current.RoamingSettings.Values.ContainsKey(setName))
                value =(int)ApplicationData.Current.RoamingSettings.Values[setName];
            return value;
        }


        //
        // Zapisz czas pomodoro
        //
        public static void SavePomodoroTime(int value)
        {
            SaveSettings(POMODORO_TIME, value);
        }


        //
        // Zapisz czas długiej przerwy
        //
        public static void SaveLongBreakTime(int value)
        {
            SaveSettings(LONG_BREAK_TIME, value);
        }


        //
        // Zapisz czas krótkiej przerwy
        //
        public static void SaveShortBreakTime(int value)
        {
            SaveSettings(SHORT_BREAK_TIME, value);
        }


        //
        // Zapisz dzienny cel
        //
        public static void SaveDailyTarget(int value)
        {
            SaveSettings(DAILY_TARGET, value);
        }


        //
        // Zapisz liczbę pomodoro do długiej przerwy
        //
        public static void SavePomodorosToLongBreak(int value)
        {
            SaveSettings(POMODOROS_TO_LONG_BREAK, value);
        }


        //
        // Odczytaj czas pomodoro
        //
        public static int LoadPomodoroTime()
        {
            return LoadSettings(POMODORO_TIME, 25);
        }


        //
        // Odczytaj czas długiej przerwy
        //
        public static int LoadLongBreakTime()
        {
            return LoadSettings(LONG_BREAK_TIME, 15);
        }


        //
        // Odczytaj czas krótkiej przerwy
        //
        public static int LoadShortBreakTime()
        {
            return LoadSettings(SHORT_BREAK_TIME, 5);
        }


        //
        // Odczytaj dzienny limit
        //
        public static int LoadDailyTarget()
        {
            return LoadSettings(DAILY_TARGET, 5);
        }


        //
        // Odczytaj liczbę pomodoro do długiej przerwy
        //
        public static int LoadPomodorosToLongBreak()
        {
            return LoadSettings(POMODOROS_TO_LONG_BREAK, 4);
        }

    }
}
