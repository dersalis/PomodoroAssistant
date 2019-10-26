using System;

namespace Atrx.Mobile.Windows.Pomodoro.Repository
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
