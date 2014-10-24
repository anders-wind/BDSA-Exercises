using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CalendarSystem.Controller;
using CalendarSystem.Exceptions;

namespace CalendarSystem.Model
{
    /// <summary>
    /// The event class implements the IEvent interface and represents a period of time at a given time, with a couple of other fields.
    /// Invariants:
    /// Events will always take place on a valid date
    /// <para> @inv (1990,1,1) &lt;= dateTime &gt;= (2100,1,1)  </para>
    /// <para> @inv this.ID &lt; storage.MaxValue(ID) </para>
    /// <para> @inv this.ID &gt; -1 </para>
    /// TODO Invariants made for this class
    /// </summary>
    public class Event : IEvent
    {
        public INotification _notification { get; set; }

        public DateTime? _date
        {
            get { return _date; }
            set
            {
                _date = value;
                checkInvariant();
            }
        }

        public TimeSpan ?_timeSpan { get; set; }

        public string _description { get; set; }

        public int _ID { get; private set; }
        public int tag { get; private set; }

        public Event(string description, TimeSpan? timespan, DateTime? date, INotification notification, int ID)
        {
            _date = date;
            _timeSpan = timespan;
            _description = description;
            _notification = notification;
            _ID = ID;
            checkInvariant();
        }

        // getters og setters for _date, startTime, endTime, _description (event description) og tag

        private void checkInvariant()
        {
            if (_ID < 0) throw new FaultyIDException();
            if (_date < new DateTime(1900, 1, 1) || _date > new DateTime(2100, 1, 1)) throw new InvalidDataException();
        }
        
        /// <summary>
        /// Change the tag of the 
        /// </summary>
        /// <param name="tag"></param>
        public void changeTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
