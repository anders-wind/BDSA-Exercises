using System;

namespace CalendarSystem.Model
{
    public class Notification
    {
        private DateTime _date; //date for notification
        private String _description; //notification description

        public Notification(DateTime date, string description)
        {
            _date = date;
            _description = description;
        }

        // getters og setters for date, startTime, endTime, nd (notification description) og nt (notification tag)
    }
}
