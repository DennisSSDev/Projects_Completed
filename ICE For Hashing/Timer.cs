using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ICE_For_Hashing
{
    class Timer
    {
        public double TotalTIme { get; set; }
        System.Timers.Timer aTimer;
        public Timer()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 50;
            aTimer.Elapsed += new ElapsedEventHandler(elapsedTimeCount);
        }

        public void StartTimer()
        {
            aTimer.Start();
        }
        private void elapsedTimeCount(object source, ElapsedEventArgs e)
        {
            TotalTIme+=0.05;
        }
        public void StopTimer()
        {
            aTimer.Stop();
        }

    }
}
