using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Windows.Storage;

namespace PomodoroAssistantPlus.LocalStorage
{
    public class FileChecker
    {
        //
        // Sprawdza czy plik istnieje
        //
        public static async Task<bool> DoesFileExistAsync(string fileName)
        {
            try
            {
                // Jeśli powodzenie to zwróć prawdę - true
                await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
