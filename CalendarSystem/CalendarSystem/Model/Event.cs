using System;
using System.Security.Cryptography.X509Certificates;

namespace CalendarSystem.Model
{
    /// <summary>
    /// The event class implements the IEvent interface and represents a period of time at a given time, with a couple of other fields.
    /// </summary>
    public class Event : IEvent
    {
        public Notification _notification { get; set; }

        public DateTime _date { get; set; }

        public TimeSpan _timeSpan { get; set; }

        public string _description { get; set; }

        public int _ID { get; private set; }

        public Event(string description, TimeSpan timespan, DateTime date, Notification notification, int ID)
        {
            _date = date;
            _timeSpan = timespan;
            _description = description;
            _notification = notification;
            _ID = ID;
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
