using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    class GoogleCalendarEvent : IEvent
    {
        private GoogleCalendarEntry _googleCalendarEntry;

        public GoogleCalendarEvent(GoogleCalendarEntry googleCalendarEntry)
        {
            _googleCalendarEntry = new GoogleCalendarEntry();
        }

        public Notification _notification { get; set; }
        public DateTime _date { get; set; }
        public TimeSpan _timeSpan { get; set; }
        public string _description { get; set; }
        public int _ID { get; private set; }
        public int tag { get; private set; }

        public void changeTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
