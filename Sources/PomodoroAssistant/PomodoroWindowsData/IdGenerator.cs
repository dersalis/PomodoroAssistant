using System;

namespace PomodoroWindowsData
{
    /// <summary>
    /// Odpowiada za tworzenie nowego id
    /// </summary>
    public static class IdGenerator
    {
        /// <summary>
        /// Tworzy nowe id
        /// </summary>
        /// <returns>Nowe id</returns>
        public static string NewId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
