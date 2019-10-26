using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using System.IO;
using Windows.Storage.Streams;

namespace PomodoroAssistantPlus.LocalStorage
{
    public class SettingsStorage
    {
        // Nazwa pliku
        private const string FILE_NAME = "settings.xml";
        // Ustawienia wczytane z pliku
        private static Model.PomodoroSettings _data;


        //
        // Odczytuje kategorie z plików
        //
        public static async Task LoadData<T>()
        {
            // Sprawdź czy plik istnieje
            if (await FileChecker.DoesFileExistAsync(FILE_NAME))
            {
                // Jeśli istnieje to odczytaj dane
                await Windows.System.Threading.ThreadPool.RunAsync((sender) => LoadAsync<T>().Wait(), Windows.System.Threading.WorkItemPriority.Normal);
            }
            else
            {
                // Jeśli nie istnieje to dodaj pierwszą kategorię i zapisz
                _data = DefaultSettings();
                // Zapisz plik
                await SaveData<Model.PomodoroSettings>();
            }
        }


        //
        // Zapisuje dane
        //
        public static async Task SaveData<T>()
        {
            // Zapisz dane
            await Windows.System.Threading.ThreadPool.RunAsync((sender) => SaveAsync<T>().Wait(), Windows.System.Threading.WorkItemPriority.Normal);
        }

        
        //
        // Zwraca wszystkie dane
        //
        public static Model.PomodoroSettings GetData()
        {
            // Zwróć wszystkie dane
            return _data;
        }


        //
        // Zwraca domyślne ustawienia
        //
        private static Model.PomodoroSettings DefaultSettings()
        {
            Model.PomodoroSettings settings = new Model.PomodoroSettings()
            {
                ActiveTaskViewIndex = 0,
                CategoryViewIndex = 0,
                CompletedTaskViewIndex = 0,
                StartCount = 0,
                PomodoroDuration = 25,
                ShortBreakDuration = 5,
                LongBreakDutation = 15,
                LongBreakDelay = 4
            };

            return settings;
        }


        //
        // Dodaje dane
        //
        public static async void AddItem(Model.PomodoroSettings item)
        {
            // Zmień dane
            _data = item;
            // Zapisz plik
            await SaveData<Model.PomodoroSettings>();
        }


        // 
        // Zapisuje dane
        //
        private static async Task SaveAsync<T>()
        {
            StorageFile sessionFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(FILE_NAME, CreationCollisionOption.ReplaceExisting);
            IRandomAccessStream sessionRandomAccess = await sessionFile.OpenAsync(FileAccessMode.ReadWrite);
            IOutputStream sessionOutputStream = sessionRandomAccess.GetOutputStreamAt(0);
            var serializer = new XmlSerializer(typeof(Model.PomodoroSettings), new Type[] { typeof(T) });

            serializer.Serialize(sessionOutputStream.AsStreamForWrite(), _data);
            sessionRandomAccess.Dispose();
            await sessionOutputStream.FlushAsync();
            sessionOutputStream.Dispose();
        }


        //
        // Odczytuje dane
        //
        private static async Task LoadAsync<T>()
        {
            StorageFile sessionFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(FILE_NAME, CreationCollisionOption.OpenIfExists);
            if (sessionFile == null)
            {
                return;
            }
            IInputStream sessionInputStream = await sessionFile.OpenReadAsync();

            var serializer = new XmlSerializer(typeof(Model.PomodoroSettings), new Type[] { typeof(T) });
            _data = (Model.PomodoroSettings)serializer.Deserialize(sessionInputStream.AsStreamForRead());
            sessionInputStream.Dispose();
        }


        //
        // Ustaw index zadań aktywnych
        //
        public static async void SetActiveTasksIndex(int viewIndex)
        {
            // Ustaw index 
            _data.ActiveTaskViewIndex = viewIndex;
            // Zapisz plik
            await SaveData<Model.PomodoroSettings>();
        }


        //
        // Ustaw index zadań zakończonych
        //
        public static async void SetCompletedTasksIndex(int viewIndex)
        {
            // Ustaw index 
            _data.CompletedTaskViewIndex = viewIndex;
            // Zapisz plik
            await SaveData<Model.PomodoroSettings>();
        }


        //
        // Ustaw index zadań aktywnych
        //
        public static async void SetCategoryIndex(int viewIndex)
        {
            // Ustaw index 
            _data.CategoryViewIndex = viewIndex;
            // Zapisz plik
            await SaveData<Model.PomodoroSettings>();
        }
    }
}
