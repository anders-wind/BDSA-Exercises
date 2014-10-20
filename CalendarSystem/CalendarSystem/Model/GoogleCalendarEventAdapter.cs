using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    class GoogleCalendarEventAdapter : IEvent
    {
        private GoogleCalendarEntry _googleCalendarEntry;

        public GoogleCalendarEventAdapter(GoogleCalendarEntry googleCalendarEntry)
        {
            _googleCalendarEntry = new GoogleCalendarEntry();
        }

        public Notification _notification
        {
            get { return _googleCalendarEntry.GoogleNotification; }
            set { _googleCalendarEntry.GoogleNotification = value; }
        }

        public DateTime _date
        {
            get { return _googleCalendarEntry.GoogleDate; }
            set { _googleCalendarEntry.GoogleDate = value; }
        }

        public TimeSpan _timeSpan
        {
            get { return _googleCalendarEntry.GoogleTimeSpan; }
            set { _googleCalendarEntry.GoogleTimeSpan = value; }
        }

        public string _description
        {
            get { return _googleCalendarEntry.GoogleDescription; }
            set { _googleCalendarEntry.GoogleDescription = value; }
        }

        public int _ID
        {
            get { return _googleCalendarEntry.GoogleID; }
        }

        public int tag
        {
            get { return _googleCalendarEntry.GoogleTag; }
        }

        public void changeTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
