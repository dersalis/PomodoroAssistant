using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace Atrx.Mobile.Windows.Pomodoro.Repository
{
    /// <summary>
    /// Zapisuje obiekt do pliku Xml
    /// </summary>
    public class XmlReader
    {
        // Nazwa pliku
        private string _fileName = string.Empty;


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="fileName">Nazwa pliku</param>
        public XmlReader(string fileName)
        {
            // Ustaw nazwę pliku
            if (fileName != string.Empty && _fileName != fileName)
            {
                _fileName = fileName;
            }
        }


        /// <summary>
        /// Odczytuje ustawienia z pliku
        /// </summary>
        /// <typeparam name="T">Odczytywany typ</typeparam>
        /// <returns>Odczytane dane</returns>
        public async Task<T> ReadAsync<T>()
        {
            // this reads XML content from a file ("_filename") and returns an object  from the XML
            T objectFromXml = default(T);
            var serializer = new XmlSerializer(typeof(T));
            //StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFolder folder = ApplicationData.Current.RoamingFolder;
            if (!await FileExistAsync(folder, _fileName))
                return objectFromXml;
            StorageFile file = await folder.GetFileAsync(_fileName);
            Stream stream = await file.OpenStreamForReadAsync();
            objectFromXml = (T)serializer.Deserialize(stream);
            stream.Dispose();
            return objectFromXml;
        }


        private async Task<bool> FileExistAsync(StorageFolder folder, string fileName)
        {
            try
            {
                await folder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
