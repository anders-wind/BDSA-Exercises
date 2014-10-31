using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class NotificationAlarmStateException : Exception
    {
        public override string Message
        {
            get { return base.Message + "The Notification error occured. Its alarmstate did not hold the invariant"; }
        }

        public NotificationAlarmStateException()
        {
        }

        public NotificationAlarmStateException(string message)
            : base(message)
        {
        }

        public NotificationAlarmStateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
