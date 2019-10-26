using System;
using System.Collections.Generic;
using System.Text;

using PomodoroAssistantPlus.Model;

namespace PomodoroAssistantPlus.Pomodoro
{
    public static class TimeManager
    {
        // 
        // Oblicza całkowity czas zadań
        //
        public static TimeSpan CalculateTotalTasksTime(List<PomodoroCycle> cycles, string taskId)
        {
            TimeSpan totalTime = new TimeSpan(0, 0, 0);
            foreach (var cycle in cycles)
            {
                if (cycle.TaskId == taskId)
                    totalTime += cycle.Duration;
            }
            return totalTime;
        }


        // 
        // Oblicza całkowity czas kategorii
        //
        public static TimeSpan CalculateTotalCategoryTime(List<PomodoroCycle> cycles, string categoryId)
        {
            TimeSpan totalTime = new TimeSpan(0, 0, 0);
            foreach (var cycle in cycles)
            {
                if (cycle.CategoryId == categoryId)
                    totalTime += cycle.Duration;
            }
            return totalTime;
        }
    }
}
