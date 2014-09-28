using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Calendar
    {
        private IList<ISubscriber> subscribers = new List<ISubscriber>();
        private IList<Event> events = new List<Event>();

        
        
        
        
        
        
        
        
        
        private void notifySubscribers()
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Notify();
            }
        }

        public void Subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void createCalenderEntry(int month, int day, int startHour, int startMinute, int endHour, int endMinute)
        {
            Event CalenderEvent = new Event(month, day, startHour, startMinute, endHour, endMinute);
            events.Add(CalenderEvent);
        }

        public void updateCalenderEntry()
        {

        }

        public void createHistoryReport()
        {

        }
    }


    

}
