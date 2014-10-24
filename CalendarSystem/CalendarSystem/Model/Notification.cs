using System;

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
            
        }

        // getters og setters for date, startTime, endTime, nd (notification description) og nt (notification tag)
    }
}
