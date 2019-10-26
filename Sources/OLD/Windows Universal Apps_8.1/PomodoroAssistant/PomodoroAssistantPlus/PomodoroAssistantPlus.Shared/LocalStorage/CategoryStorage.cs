using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using System.IO;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using System.Linq;

namespace PomodoroAssistantPlus.LocalStorage
{
    public class CategoryStorage
    {
        // Nazwa pliku
        private const string FILE_NAME = "categories.xml";
        // Lista categori wczytanych z pliku
        private static List<Model.Category> _data = new List<Model.Category>();
        

        //
        // Zwraca wszystkie kategorie
        //
        public static List<Model.Category> GetData()
        {
            return _data;
        }


        //
        // Utwórz perwszą kategorię - No name
        //
        private static Model.Category CreateNoNameCategory()
        {
            // Dodaj kategorię bez nazwy
            Model.Category noNameCategory = new Model.Category()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "No name",
                Color = (new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Transparent)).Color.ToString(),
                IsPermissionDelete = false
            };
            // Zwróć
            return noNameCategory;
        }

        
        //
        // Zapisuje dane
        //
        public static async Task SaveData<T>()
        {
            await Windows.System.Threading.ThreadPool.RunAsync((sender) => SaveAsync<T>().Wait(), Windows.System.Threading.WorkItemPriority.Normal);
        }


        //
        // Zapisuje dane
        //
        private static async Task SaveAsync<T>()
        {
            StorageFile sessionFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(FILE_NAME, CreationCollisionOption.ReplaceExisting);
            IRandomAccessStream sessionRandomAccess = await sessionFile.OpenAsync(FileAccessMode.ReadWrite);
            IOutputStream sessionOutputStream = sessionRandomAccess.GetOutputStreamAt(0);
            var serializer = new XmlSerializer(typeof(List<Model.Category>), new Type[] { typeof(T) });

            //Using DataContractSerializer , look at the cat-class
            //var sessionSerializer = new DataContractSerializer(typeof(List<object>), new Type[] { typeof(T) });
            //sessionSerializer.WriteObject(sessionOutputStream.AsStreamForWrite(), _data);

            //Using XmlSerializer , look at the Dog-class
            serializer.Serialize(sessionOutputStream.AsStreamForWrite(), _data);
            sessionRandomAccess.Dispose();
            await sessionOutputStream.FlushAsync();
            sessionOutputStream.Dispose();
        }



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
                _data.Add(CreateNoNameCategory());
                // W trybie debug dodaj dane testowe
#if DEBUG_WINDOWSPHONE
                // Dodaj dane testowe
                _data.AddRange(TestData.TasksTestData.GetCategoriesFromTestFile());
#endif
                // Zapisz plik
                await SaveData<Model.Category>();
            }
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

            //Using DataContractSerializer , look at the cat-class
            // var sessionSerializer = new DataContractSerializer(typeof(List<object>), new Type[] { typeof(T) });
            //_data = (List<object>)sessionSerializer.ReadObject(sessionInputStream.AsStreamForRead());

            //Using XmlSerializer , look at the Dog-class
            var serializer = new XmlSerializer(typeof(List<Model.Category>), new Type[] { typeof(T) });
            _data = (List<Model.Category>)serializer.Deserialize(sessionInputStream.AsStreamForRead());
            sessionInputStream.Dispose();
        }


        //
        // Usuwa kategorie
        //
        public static async void RemoveItem(string itemIndex)
        {
            // Odszukaj zadanie
            //var selectedTask = SelectTaskOfIndex(itemIndex);
            // Usuń zadanie
            RemoveCategoryOfIndex(itemIndex);
            // Zapisz zadanie
            await SaveData<Model.Category>();
        }


        //
        // Usuwa kategorie o danym indeksie
        //
        private static async void RemoveCategoryOfIndex(string itemIndex)
        {
            // Przeszukaj kategorie
            foreach (var cat in _data)
            {
                // Porównaj indeksy
                if (cat.Id == itemIndex)
                {
                    // Sprawdź czy jest ot domyślna kategoria
                    if (cat.IsPermissionDelete == false)
                    { 
                        //TODO ZMIENIC!!!
                        // Nie można usuńąć
                        var dialog = new MessageDialog("Kategorii domyślnej nie można usunąć!", "Kategoria domyślna");
                        dialog.Commands.Add(new UICommand("Ok"));
                        await dialog.ShowAsync();
                        break;
                    }
                    // Usuń zadanie
                    _data.Remove(cat);
                    break;
                }
            }
        }


        //
        // Dodaje kategorie
        //
        public static async void AddItem(Model.Category category)
        {
            // Dodaj 
            _data.Add(category);
            // Zapisz
            await SaveData<Model.Category>();
        }

        // 
        // Zwraca kategorię o podanym id
        //
        public static Model.Category GetCategoryOfId(string id)
        {
            // Wyszukaj kategorię
            Model.Category category = (from cat in _data where cat.Id == id select cat).FirstOrDefault();
            // Zwróć
            return category;
        }


        //
        // Edytuje kategorie o podanym id
        //
        public static void EditCategory(Model.Category category)
        {
            RemoveCategoryOfIndex(category.Id);
            AddItem(category);
        }

    }
}
