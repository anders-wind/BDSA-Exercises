using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    /// <summary>
    /// This Proxy makes the client able to generate events with a date and an ID only. Therefore saving retrieving a lot of data from the storage in case of a large amount of events.
    /// By doing this we can have all events in the system and first when the user reaches chooses the daily view or opens the event do we have to pick the rest of the information.
    /// This Class is a part of the Delaying expensive computations version of the Proxy Pattern.
    /// </summary>
    public class EventProxy : IEvent
    {
        private IEvent _trueEvent;

        public EventProxy(DateTime? date, int ID)
        {
            _date = date;
            _ID = ID;
        }

        public INotification _notification
        {
            get
            {
                if (_trueEvent == null) // get true event
                { }
                return _trueEvent._notification;
            }
            set
            {
                if(_trueEvent == null) // get true event
                { }
                _trueEvent._notification = value;
            }
        }
        public DateTime? _date 
        { get
            {
                if (_trueEvent == null) // get true event
                { }
                return _trueEvent._date;
            }
            set
            {
                if(_trueEvent == null) // get true event
                { }
                _trueEvent._date = value;
            } 
        }

        public TimeSpan? _timeSpan
        {
            get
            {
                if (_trueEvent == null) // get true event
                { }
                return _trueEvent._timeSpan;
            }
            set
            {
                if(_trueEvent == null) // get true event
                { }
                _trueEvent._timeSpan = value;
            }
        }

        public string _description
        {
            get
            {
                if (_trueEvent == null) // get true event
                { }
                return _trueEvent._description;
            }
            set
            {
                if(_trueEvent == null) // get true event
                { }
                _trueEvent._description = value;
            }
        }
        public int _ID { get; private set; }

        public int tag
        {
            get
            {
                if (_trueEvent == null) // get true event
                { }
                return _trueEvent.tag;
            }
        }
    }
}
