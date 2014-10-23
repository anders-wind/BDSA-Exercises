using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
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
