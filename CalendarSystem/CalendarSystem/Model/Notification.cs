using System;

namespace CalendarSystem.Model
{
    /// <summary>
    /// A class which has a date for when the notification enters an alarmstate and a description.
    /// </summary>
    public class Notification : INotification
    {
        private DateTime _date; //date for notification
        public string Description { get; set; }

        public Notification(DateTime date, string description)
        {
            _date = date;
            Description = description;
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

        // getters og setters for date, startTime, endTime, nd (notification description) og nt (notification tag)
    }
}
