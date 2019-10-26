using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace Atrx.Mobile.Windows.Pomodoro.Repository
{
    /// <summary>
    /// Zapisuje dane do pliku XML
    /// </summary>
    public class XmlSaver
    {
        // Nazwa pliku
        private string _fileName;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="fileName">Nazwa pliku</param>
        public XmlSaver(string fileName)
        {
            // Sprawdz nazwe
            if (fileName != string.Empty && _fileName != fileName)
            {
                _fileName = fileName;
            }
        }


        /// <summary>
        /// Zapisuje dane do pliku XML
        /// </summary>
        /// <typeparam name="T">Typ zapisywanych danych</typeparam>
        /// <param name="objectToSave">Zapisywane dane</param>
        /// <returns></returns>
        public async Task SaveAsync<T>(T objectToSave)
        {
            // stores an object in XML format in file called 'filename'
            var serializer = new XmlSerializer(typeof(T));
            //StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFolder folder = ApplicationData.Current.RoamingFolder;
            StorageFile file = await folder.CreateFileAsync(_fileName, CreationCollisionOption.ReplaceExisting);
            Stream stream = await file.OpenStreamForWriteAsync();

            using (stream)
            {
                serializer.Serialize(stream, objectToSave);
            }
        }

    }
}
