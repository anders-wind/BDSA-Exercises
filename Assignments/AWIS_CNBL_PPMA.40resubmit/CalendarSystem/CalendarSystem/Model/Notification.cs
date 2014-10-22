using System;

namespace CalendarSystem.Model
{
    /// <summary>
    /// A class which has a date for when the notification enters an alarmstate and a description.
    /// </summary>
    public class Notification
    {
        private DateTime _date; //date for notification
        private String _description; //notification description

        public Notification(DateTime date, string description)
        {
            _date = date;
            _description = description;
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
