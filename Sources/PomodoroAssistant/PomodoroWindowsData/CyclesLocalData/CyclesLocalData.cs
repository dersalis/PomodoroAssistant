using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrx.Mobile.Windows.Pomodoro.Data.CyclesLocalData
{
    /// <summary>
    /// Baza cykli
    /// </summary>
    public class CyclesLocalData
    {
        // Lista cykli
        private static List<Cycle> _dataBase = null;


        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        public CyclesLocalData()
        {
            // Zainicjuj bazę
            _dataBase = new List<Cycle>();
            // Obczytaj dane
        }


        /// <summary>
        /// Zwraca wszystkie cykle
        /// </summary>
        /// <returns>Lista cykli</returns>
        public static List<Cycle> GetAllCycles()
        {
            // Zwróć zadania
            return _dataBase;
        }


        /// <summary>
        /// Wyszukuje cykl o podanym id
        /// </summary>
        /// <param name="cycleId">Id szukanego cyklu</param>
        /// <returns>Wyszukany cykl lub null - gdy brak cyklu</returns>
        private static Cycle FindCycleOfId(string cycleId)
        {
            Cycle foundCycle = null; // Znalezione cyklu
            // Przeszukaj bazę
            foreach (var cycle in _dataBase)
            {
                // Sprawdz czy id aktualnego cyklu jest równe podanemu id
                if (cycle.Id == cycleId)
                {
                    // Jesli są równe to zapamiętaj cykl i przerwij przeszukiwanie
                    foundCycle = cycle;
                    break;
                }
            }
            return foundCycle;
        }


        /// <summary>
        /// Wyszukuje cykl o podanym id zadania
        /// </summary>
        /// <param name="taskId">Id zadania szukanego cyklu</param>
        /// <returns>Wyszukany cykl lub null - gdy brak cyklu</returns>
        private static Cycle FindCycleOfTaskId(string taskId)
        {
            Cycle foundCycle = null; // Znalezione cykle
            // Przeszukaj bazę
            foreach (var cycle in _dataBase)
            {
                // Sprawdz czy id aktualnego cyklu jest równe podanemu id
                if (cycle.TaskId == taskId)
                {
                    // Jesli są równe to zapamiętaj cykl i przerwij przeszukiwanie
                    foundCycle = cycle;
                    break;
                }
            }
            return foundCycle;
        }


        /// <summary>
        /// Wyszukuje cykle o podanym id zadania
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        private static List<Cycle> FindAllCyclesOfTaskId(string taskId)
        {
            List<Cycle> foundCycles = new List<Cycle>(); // Znalezione cykle
            // Przeszukaj bazę
            foreach(var cycle in _dataBase)
            {
                // Jeśli id są równe to dodaj
                if (cycle.TaskId == taskId)
                {
                    foundCycles.Add(cycle);
                }
            }
            return foundCycles;
        }
    }
}
