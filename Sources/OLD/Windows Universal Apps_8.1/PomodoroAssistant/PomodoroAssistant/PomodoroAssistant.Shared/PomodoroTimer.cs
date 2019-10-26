using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml;

namespace PomodoroAssistant
{
    public class PomodoroTimer
    {
        // Stany timera
        public enum TimerState { Started, Paused, Stopped };

        // Instancja timera
        private DispatcherTimer _timer;
        // Jednostka 1 sec.
        public static TimeSpan ONE_SECOND = new TimeSpan(0, 0, 1);
        // Zero sekund
        public static TimeSpan ZERO_SECONDS = new TimeSpan(0, 0, 0);


        // 
        // KONSTRUKTOR
        //
        public PomodoroTimer(EventHandler<object> tickedMethod)
        { 
            // Timer
            _timer = new DispatcherTimer();
            // Odmierzana jednostka czasu
            _timer.Interval = ONE_SECOND;
            // Zdarzenie wykonywane co jednostkę czasu
            _timer.Tick += tickedMethod;
        }

        //
        // Uruchamia timer
        //
        public TimerState Start()
        {
            // Uruchom timer
            _timer.Start();
            // Zwróć stan uruchomiony
            return TimerState.Started;
        }


        //
        // Zatrzymuje timer
        //
        public TimerState Stop()
        {
            // Zatrzymaj timer
            _timer.Stop();
            // Zwróć stan zatrzymany
            return TimerState.Stopped;
        }


        //
        // Wstrzymaj timer
        //
        public TimerState Pause()
        {
            // Zatrzymaj timer
            _timer.Stop();
            // Zwróć stan pauza
            return TimerState.Paused;
        }
    }
}
