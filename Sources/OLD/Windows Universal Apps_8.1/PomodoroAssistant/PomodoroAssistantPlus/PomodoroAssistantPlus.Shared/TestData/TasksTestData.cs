using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml.Media;

using PomodoroAssistantPlus.Model;

namespace PomodoroAssistantPlus.TestData
{
    public static class TasksTestData
    {
        // Zwraca aktywne zadania
        public static List<ActiveTaskView> GetActiveTasks()
        {
            List<ActiveTaskView> activeTasksList = new List<ActiveTaskView>()
            {
                new ActiveTaskView()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Koszenie trawy", 
                    Note = "Koszenie wokół osiedla",
                    CategoryColor = new SolidColorBrush(Windows.UI.Colors.BlueViolet).ToString(),
                    AddDate = DateTime.Now - new TimeSpan(20, 4, 30, 0),
                    LastEditionDate = DateTime.Now,
                    TotalTime = new TimeSpan(1, 34, 0)
                },
                new ActiveTaskView()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Projekt śmigłowca cywilnego dla pogotowia ratunkowego", 
                    Note = "Przygotować projekt małego śmigłowca cywilnego o prędkości przelotowej 200 km/h",
                    CategoryColor = new SolidColorBrush(Windows.UI.Colors.OrangeRed).ToString(),
                    AddDate = (DateTime.Now)-new TimeSpan(1, 3, 23, 0),
                    LastEditionDate = DateTime.Now,
                    TotalTime = new TimeSpan(1, 14, 0)
                }
            };

            return activeTasksList;
        }


        // Zwraca kategorie w formie pliku
        public static List<Category> GetCategoriesFromTestFile()
        {
            List<Category> category = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Dom",
                    Color = (new SolidColorBrush(Windows.UI.Colors.OrangeRed)).Color.ToString(),
                    IsPermissionDelete = true,
                },
                new Category()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Praca",
                    Color = (new SolidColorBrush(Windows.UI.Colors.Violet)).Color.ToString(),
                    IsPermissionDelete = true,
                },
                new Category()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Programowanie",
                    Color = (new SolidColorBrush(Windows.UI.Colors.YellowGreen)).Color.ToString(),
                    IsPermissionDelete = true
                }
            };

            return category;
        }

        // Zwraca zadania w formie pliku
        public static List<Task> GetTasksFromTestFile(List<Category> category)
        {
            List<Task> tasks = new List<Task>()
            {
                new Task()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Malowanie mieszkania",
                    Note = "Malowanie wszystkich scian w całym mieszkaniu",
                    IsAcitve = false,
                    CategoryId = category[0].Id,
                    AddDate = new DateTime(2014, 1, 20),
                    LastEditionDate = new DateTime(2014, 1, 20).AddMonths(2),
                    DeleteDate = new DateTime(2014, 1, 20).AddMonths(3)
                },
                new Task()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Ścinanie trawnika",
                    Note = "Koszenie trawnika wokół domu",
                    IsAcitve = true,
                    CategoryId = category[0].Id,
                    AddDate = new DateTime(2014, 1, 25),
                    LastEditionDate = new DateTime(2014, 2, 20).AddMonths(2),
                    //DeleteDate = new DateTime(2014, 1, 20).AddMonths(3)
                },
                new Task()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Projekt koła zembatego",
                    Note = "Przygotowanie modelu 3D oraz dokumentacji",
                    IsAcitve = true,
                    CategoryId = category[1].Id,
                    AddDate = new DateTime(2014, 3, 20),
                    LastEditionDate = new DateTime(2014, 3, 20).AddMonths(2),
                    //DeleteDate = new DateTime(2014, 1, 20).AddMonths(3)
                },
                new Task()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Projekt dźwigu",
                    Note = "Przygotowanie modelu 3D oraz dokumentacji",
                    IsAcitve = true,
                    CategoryId = category[1].Id,
                    AddDate = new DateTime(2014, 3, 11),
                    LastEditionDate = new DateTime(2014, 3, 20).AddMonths(2),
                    //DeleteDate = new DateTime(2014, 1, 20).AddMonths(3)
                },
                new Task()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Projekt zamka",
                    Note = "Przygotowanie modelu 3D oraz dokumentacji",
                    IsAcitve = true,
                    CategoryId = category[1].Id,
                    AddDate = new DateTime(2014, 4, 10),
                    LastEditionDate = new DateTime(2014, 4, 20).AddMonths(2),
                    //DeleteDate = new DateTime(2014, 1, 20).AddMonths(3)
                },
                new Task()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Program Smart Scale",
                    Note = "Programowanie, UI, grafika, publikacja",
                    IsAcitve = true,
                    CategoryId = category[2].Id,
                    AddDate = new DateTime(2014, 5, 20),
                    LastEditionDate = new DateTime(2014, 3, 28).AddMonths(2),
                    //DeleteDate = new DateTime(2014, 1, 20).AddMonths(3)
                },
                new Task()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Program Rocketnote",
                    Note = "Programowanie, UI, grafika, publikacja",
                    IsAcitve = true,
                    CategoryId = category[2].Id,
                    AddDate = new DateTime(2014, 6, 20),
                    LastEditionDate = new DateTime(2014, 5, 28).AddMonths(2),
                    //DeleteDate = new DateTime(2014, 1, 20).AddMonths(3)
                },
                new Task()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Program Rocketwallet",
                    Note = "Programowanie, UI, grafika, publikacja",
                    IsAcitve = false,
                    CategoryId = category[2].Id,
                    AddDate = new DateTime(2014, 5, 23),
                    LastEditionDate = new DateTime(2014, 3, 28).AddMonths(2),
                    DeleteDate = new DateTime(2014, 5, 20).AddMonths(3)
                }
            };

            return tasks;
        }

        // Zwraca cykle w formie pliku
        public static List<PomodoroCycle> GetPomodoroCyclesFromTestFile(List<Task> tasks)
        {
            List<PomodoroCycle> cycles = new List<PomodoroCycle>()
            {
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[0].Id,
                    CategoryId = tasks[0].CategoryId,
                    StartDate = new DateTime(2014, 01, 20, 7, 0, 0).AddMinutes(30),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[0].Id,
                    CategoryId = tasks[0].CategoryId,
                    StartDate = new DateTime(2014, 01, 20, 7, 0, 0).AddMinutes(60),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[0].Id,
                    CategoryId = tasks[0].CategoryId,
                    StartDate = new DateTime(2014, 01, 20, 7, 0, 0).AddMinutes(90),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[0].Id,
                    CategoryId = tasks[0].CategoryId,
                    StartDate = new DateTime(2014, 01, 20, 7, 0, 0).AddMinutes(120),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[0].Id,
                    CategoryId = tasks[0].CategoryId,
                    StartDate = new DateTime(2014, 01, 20, 7, 0, 0).AddMinutes(150),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[0].Id,
                    CategoryId = tasks[0].CategoryId,
                    StartDate = new DateTime(2014, 01, 20, 7, 0, 0).AddMinutes(180),
                    Duration = new TimeSpan(0, 25, 0)
                },


                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[1].Id,
                    CategoryId = tasks[1].CategoryId,
                    StartDate = new DateTime(2014, 01, 21, 7, 0, 0).AddMinutes(30),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[1].Id,
                    CategoryId = tasks[1].CategoryId,
                    StartDate = new DateTime(2014, 01, 21, 7, 0, 0).AddMinutes(60),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[1].Id,
                    CategoryId = tasks[1].CategoryId,
                    StartDate = new DateTime(2014, 01, 21, 7, 0, 0).AddMinutes(90),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[1].Id,
                    CategoryId = tasks[1].CategoryId,
                    StartDate = new DateTime(2014, 01, 21, 7, 0, 0).AddMinutes(120),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[1].Id,
                    CategoryId = tasks[1].CategoryId,
                    StartDate = new DateTime(2014, 01, 22, 7, 0, 0).AddMinutes(150),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[1].Id,
                    CategoryId = tasks[1].CategoryId,
                    StartDate = new DateTime(2014, 01, 22, 7, 0, 0).AddMinutes(180),
                    Duration = new TimeSpan(0, 25, 0)
                },


                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[2].Id,
                    CategoryId = tasks[2].CategoryId,
                    StartDate = new DateTime(2014, 01, 22, 7, 0, 0).AddMinutes(30),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[2].Id,
                    CategoryId = tasks[2].CategoryId,
                    StartDate = new DateTime(2014, 01, 22, 7, 0, 0).AddMinutes(60),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[2].Id,
                    CategoryId = tasks[2].CategoryId,
                    StartDate = new DateTime(2014, 01, 22, 7, 0, 0).AddMinutes(90),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[2].Id,
                    CategoryId = tasks[2].CategoryId,
                    StartDate = new DateTime(2014, 01, 22, 7, 0, 0).AddMinutes(120),
                    Duration = new TimeSpan(0, 25, 0)
                },
                

                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[3].Id,
                    CategoryId = tasks[3].CategoryId,
                    StartDate = new DateTime(2014, 01, 23, 7, 0, 0).AddMinutes(30),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[3].Id,
                    CategoryId = tasks[3].CategoryId,
                    StartDate = new DateTime(2014, 01, 23, 7, 0, 0).AddMinutes(60),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[3].Id,
                    CategoryId = tasks[3].CategoryId,
                    StartDate = new DateTime(2014, 01, 23, 7, 0, 0).AddMinutes(90),
                    Duration = new TimeSpan(0, 25, 0)
                },



                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[4].Id,
                    CategoryId = tasks[4].CategoryId,
                    StartDate = new DateTime(2014, 01, 24, 7, 0, 0).AddMinutes(30),
                    Duration = new TimeSpan(0, 25, 0)
                },
                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[4].Id,
                    CategoryId = tasks[4].CategoryId,
                    StartDate = new DateTime(2014, 01, 24, 7, 0, 0).AddMinutes(60),
                    Duration = new TimeSpan(0, 25, 0)
                },


                new PomodoroCycle()
                {
                    Id = Guid.NewGuid().ToString(),
                    TaskId = tasks[5].Id,
                    CategoryId = tasks[5].CategoryId,
                    StartDate = new DateTime(2014, 01, 25, 7, 0, 0).AddMinutes(60),
                    Duration = new TimeSpan(0, 25, 0)
                }
            };



            return cycles;
        }

    }
}
