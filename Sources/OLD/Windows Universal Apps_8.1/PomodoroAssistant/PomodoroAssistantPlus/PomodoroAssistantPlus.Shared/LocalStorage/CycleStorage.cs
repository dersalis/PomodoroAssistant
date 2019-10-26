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
    public class CycleStorage
    {
        // Nazwa pliku
        private const string FILE_NAME = "cycles.xml";
        // Lista categori wczytanych z pliku
        private static List<Model.PomodoroCycle> _data = new List<Model.PomodoroCycle>();


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
                // W trybie debug dodaj dane testowe
#if DEBUG_WINDOWSPHONE
                // Dodaj dane testowe
                _data.AddRange(TestData.TasksTestData.GetPomodoroCyclesFromTestFile(TestData.TasksTestData.GetTasksFromTestFile(TestData.TasksTestData.GetCategoriesFromTestFile())));
                // Zapisz plik
                await SaveData<Model.Task>();
#endif
            }
        }


        //
        // Zapisuje dane
        //
        public static async Task SaveData<T>()
        {
            await Windows.System.Threading.ThreadPool.RunAsync((sender) => SaveAsync<T>().Wait(), Windows.System.Threading.WorkItemPriority.Normal);
        }


        //
        // Zwraca wszystkie dane
        //
        public static List<Model.PomodoroCycle> GetData()
        {
            // Zwróć
            return _data;
        }


        public void RemoveItem(int itemIndex)
        {
            throw new NotImplementedException();
        }


        //
        // Usuwa cykl o danym id
        //
        public static async void RemoveCycleOfTaskIndex(string taskIndex)
        { 
            // Przeszukaj
            foreach (var cycle in _data)
            {
                if (cycle.TaskId == taskIndex)
                    _data.Remove(cycle);
            }
            // Zapisz zmiany
            await SaveData<Model.Task>();
        }


        public void ChangeItem<T>(T item)
        {
            throw new NotImplementedException();
        }


        //
        // Usuwa wszytkie pozycje
        //
        public static async void ClearData()
        {
            // Usuń wszytko
            _data.Clear();
            // Zapisz zmiany
            await SaveData<Model.Task>();
        }


        public void AddItem<T>(T item)
        {
            throw new NotImplementedException();
        }


        //
        // Zapisuje dane
        //
        private static async Task SaveAsync<T>()
        {
            StorageFile sessionFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(FILE_NAME, CreationCollisionOption.ReplaceExisting);
            IRandomAccessStream sessionRandomAccess = await sessionFile.OpenAsync(FileAccessMode.ReadWrite);
            IOutputStream sessionOutputStream = sessionRandomAccess.GetOutputStreamAt(0);
            var serializer = new XmlSerializer(typeof(List<Model.PomodoroCycle>), new Type[] { typeof(T) });

            serializer.Serialize(sessionOutputStream.AsStreamForWrite(), _data);
            sessionRandomAccess.Dispose();
            await sessionOutputStream.FlushAsync();
            sessionOutputStream.Dispose();
        }


        //
        // Odczytuje dane
        //
        static async private Task LoadAsync<T>()
        {
            StorageFile sessionFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(FILE_NAME, CreationCollisionOption.OpenIfExists);
            if (sessionFile == null)
            {
                return;
            }
            IInputStream sessionInputStream = await sessionFile.OpenReadAsync();

            var serializer = new XmlSerializer(typeof(List<Model.PomodoroCycle>), new Type[] { typeof(T) });
            _data = (List<Model.PomodoroCycle>)serializer.Deserialize(sessionInputStream.AsStreamForRead());
            sessionInputStream.Dispose();
        }
    }
}
