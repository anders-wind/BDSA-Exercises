using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Event
    {
        private DateTime dt;
        private TimeSpan startTime;
        private TimeSpan endTime;

        public Event()
        {
            dt = new DateTime();
            startTime = new TimeSpan();
            endTime = new TimeSpan();
        }
        
    }
}
