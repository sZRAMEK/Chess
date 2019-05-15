using Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Timer : ITimer
    {
        public int maxTime { get; private set; }
        private TimeSpan timeDelta;
        private DateTime _startDate;
        
       public Timer(int maxTime)
        {
            this.maxTime = maxTime;
            timeDelta = TimeSpan.FromMinutes(maxTime);
        }

        public void Start()
        {
            _startDate = DateTime.Now; 
        }

        public void Stop()
        {
            TimeSpan temp  = DateTime.Now.Subtract(_startDate);
            timeDelta = timeDelta.Subtract(temp);
        }

        public int TimeFromStart()
        {
            return timeDelta.Seconds;
        }
    }
}
