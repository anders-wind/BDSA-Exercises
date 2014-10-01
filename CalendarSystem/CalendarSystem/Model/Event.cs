using System;
using System.Security.Cryptography.X509Certificates;

namespace CalendarSystem.Model
{
    public class Event : IEvent
    {
        public Notification _notification { get; set; }

        public DateTime _date { get; set; }

        public TimeSpan _timeSpan { get; set; }

        public string _description { get; set; }

        public int _ID { get; private set; }

        public Event(string description, int month, int day, int startHour, int endHour, int ID)
        {
            _date = new DateTime(DateTime.Now.Year, month, day);
            _timeSpan = new TimeSpan(startHour, endHour, 0);
            _description = description;
            _ID = ID;
        }

        // getters og setters for _date, startTime, endTime, _description (event description) og tag


        

        public void changeTag(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
