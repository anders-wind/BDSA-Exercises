using System;
using System.Security.Cryptography.X509Certificates;

namespace CalendarSystem.Model
{
    public class Event
    {
        private DateTime _date; //_date for event
        private TimeSpan _timeSpan; //start time for event
        private String _description; //event description
        public Tag _tag{ get; set; } //event tag (skal være en liste?, kan der være flere tags på samme event?)
        private Notification _notification { get; set; }

        public Event(int month, int day, int startHour, int endHour)
        {
            _date = new DateTime(DateTime.Now.Year, month, day);
            _timeSpan = new TimeSpan(startHour, endHour, 0);
        }

        public void chooseTag()
        {
           
        }

        // getters og setters for _date, startTime, endTime, _description (event description) og tag
    }
}
