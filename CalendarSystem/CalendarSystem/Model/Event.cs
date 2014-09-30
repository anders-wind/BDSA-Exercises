using System;
using System.Security.Cryptography.X509Certificates;

namespace CalendarSystem.Model
{
    public class Event : IEvent
    {
        public Notification _Notification { get; set; }

        public DateTime _Date { get; set; }

        public TimeSpan _TimeSpan { get; set; }

        public string _Description { get; set; }

        public Event(int month, int day, int startHour, int endHour)
        {
            _Date = new DateTime(DateTime.Now.Year, month, day);
            _TimeSpan = new TimeSpan(startHour, endHour, 0);
        }

        // getters og setters for _date, startTime, endTime, _description (event description) og tag

        

        public void changeTag(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
