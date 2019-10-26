using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using System.IO;
using Windows.Storage.Streams;
using System.Linq;
using Windows.UI.Popups;

namespace PomodoroAssistantPlus.LocalStorage
{
    public class TaskStorage
    {
        // Nazwa pliku
        private const string FILE_NAME = "tasks.xml";
        // Lista categori wczytanych z pliku
        private static List<Model.Task> _data = new List<Model.Task>();


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
                _data.AddRange(TestData.TasksTestData.GetTasksFromTestFile(CategoryStorage.GetData()));
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
        // Zwróć wszystkie dane
        //
        public static List<Model.Task> GetData()
        {
            // Zwróć wszystkie dane
            return _data;
        }


        //
        // Usuwa zadanie
        //
        public static async void RemoveItem(string itemIndex)
        {
            // Usuń zadanie
            RemoveTaskOfIndex(itemIndex);
            // Zapisz zadanie
            await SaveData<Model.Task>();
        }


        //
        // Zmień typ zadania Aktywne / Zakończone
        //
        public static async void ChangeTaskType(string itemIndex)
        {
            // Odszukaj zadanie
            var selectedTask = SelectTaskOfIndex(itemIndex);
            // Usuń zadanie
            RemoveTaskOfIndex(itemIndex);
            // Zmień typ zadania
            selectedTask.IsAcitve = !(selectedTask.IsAcitve);
            // Dodaj zadanie
            _data.Add(selectedTask);
            // Zapisz zadanie
            await SaveData<Model.Task>();
        }


        public void ChangeItem<T>(T item)
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }


        public void AddItem<T>(T item)
        {
            throw new NotImplementedException();
        }


        //
        // Zwraca zadanie o podanym indeksie
        //
        private static Model.Task SelectTaskOfIndex(string itemIndex)
        {
            // Wybierz zadanie
            Model.Task selectedItem = (from task in _data where task.Id == itemIndex select task).First();
            // Zwróć
            return selectedItem;
        }


        //
        // Usuwa zadanie o indeksie
        //
        private static void RemoveTaskOfIndex(string itemIndex)
        { 
            // Przeszukaj zadania
            foreach (var task in _data)
            {
                // Porównaj indeksy
                if (task.Id == itemIndex)
                {
                    // Usuń zadanie
                    _data.Remove(task);
                    break;
                }
            }
        }


        //
        // Zapisuje dane
        //
        private static async Task SaveAsync<T>()
        {
            StorageFile sessionFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(FILE_NAME, CreationCollisionOption.ReplaceExisting);
            IRandomAccessStream sessionRandomAccess = await sessionFile.OpenAsync(FileAccessMode.ReadWrite);
            IOutputStream sessionOutputStream = sessionRandomAccess.GetOutputStreamAt(0);
            var serializer = new XmlSerializer(typeof(List<Model.Task>), new Type[] { typeof(T) });

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

            var serializer = new XmlSerializer(typeof(List<Model.Task>), new Type[] { typeof(T) });
            _data = (List<Model.Task>)serializer.Deserialize(sessionInputStream.AsStreamForRead());
            sessionInputStream.Dispose();
        }
    }
}
