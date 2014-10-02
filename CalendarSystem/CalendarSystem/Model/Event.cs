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

        public Event(string description, TimeSpan timespan, DateTime date, Notification notification)
        {
            _date = date;
            _timeSpan = timespan;
            _description = description;
            _notification = notification;
        }

        // getters og setters for _date, startTime, endTime, _description (event description) og tag


        
        /// <summary>
        /// Change the tag of the 
        /// </summary>
        /// <param name="tag"></param>
        public void changeTag(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
