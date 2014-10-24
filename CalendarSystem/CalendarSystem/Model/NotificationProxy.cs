using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    /// <summary>
    /// This - like the EventProxy - is a proxy which enables to generate notifications only with a date so the storage doesnt have to retrieve description before its neccesary.
    /// In the case that a user wants to watch a notification or the notification pops up due to an alarm state the full notification can be retrieved.
    /// This Class is a part of the Delaying expensive computations version of the Proxy Pattern.
    /// Notes: this might not be very efficient for a number of reasons.
    ///     1. The only field which retrieval time is saved is the description
    ///     2. The time it takes to connect to the storage and create this proxy and later the original object might be bigger than the amount of time saved.
    ///     3. The user will probably not have many notifications therefore saving even less time.
    /// The proxy pattern do provide some scalability in case we might want to extend the notification class.
    /// </summary>
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

        public bool IsInAlarmState()
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
