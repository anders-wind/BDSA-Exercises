using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    class LinkedEventsComposite : IEvent
    {

        private IList<IEvent> events = new List<IEvent>();
        public Notification _notification { get; set; }
        public DateTime _date { get; set; }
        public TimeSpan _timeSpan { get; set; }
        public string _description { get; set; }

        public int _ID { get; private set; }
        public int tag { get; private set; }

        public void AddEvent(IEvent anEvent)
        {
            events.Add(anEvent);
        }
        public void AddRangeOfEvent(IList<IEvent> someEvents)
        {
            events.Concat(someEvents);
        }

        public void changeTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
