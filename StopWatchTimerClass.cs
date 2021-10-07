using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace stopWatch
{
    public class StopWatchTimerClass
    {
        public Stopwatch stopWatch;

        public StopWatchTimerClass()
        {
            stopWatch = new Stopwatch();

        }

        public void start()
        {
            stopWatch.Start();
        }
        public void stop()
        {
            stopWatch.Stop();
        }
        public void reset()
        {
            stopWatch.Reset();
        }
        public string getElasped { get; set; }
        public string elapsed
        {
            get
            {
               return stopWatch.Elapsed.ToString(@"hh\:mm\:ss");
            }
            
        }

        public bool timeRunning()
        {
            return stopWatch.IsRunning;
        }
       
    }
}
