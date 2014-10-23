using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    class NotificationProxy : INotification
    {
        private DateTime _date;
        private INotification _trueNotification;

        public NotificationProxy(DateTime dateTime)
        {
            _date = dateTime;
        }
        public string Description
        {
            get
            {
                if (_trueNotification == null) // get true notification
                { }
                return _trueNotification.Description;
            }
            set
            {
                if (_trueNotification == null) // get true notification
                { }
                _trueNotification.Description = value;
            }
        }

        public bool isInAlarmState()
        {
            if (DateTime.Now < _date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
