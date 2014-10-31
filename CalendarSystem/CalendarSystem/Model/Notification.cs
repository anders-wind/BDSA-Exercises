using System;
using System.IO;
using CalendarSystem.Exceptions;

namespace CalendarSystem.Model
{
    // todo invariant implementation
    /// <summary>
    /// A class which has a date for when the notification enters an alarmstate and a description.
    /// </summary>
    public class Notification : INotification
    {
        private DateTime _date; //date for notification
        public string Description { get; set; }

        public Notification(DateTime date)
        {
            _date = date;
        }

        public Notification(DateTime date, string description)
        {
            _date = date;
            Description = description;
        }

        public bool IsInAlarmState()
        {
            return (DateTime.Now > _date);
        }

        private void checkInvariants()
        {
            if (_date < new DateTime(1900, 1, 1) || _date > new DateTime(2100, 1, 1)) throw new InvalidDataException();
            if (DateTime.Now > _date != IsInAlarmState()) throw new NotificationAlarmStateException();
        }
    }
}
