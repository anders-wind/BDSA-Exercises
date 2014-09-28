using System;

namespace CalendarSystem.Model
{
    public class Event
    {
        private DateTime date; //date for event
        private TimeSpan startTime; //start time for event
        private TimeSpan endTime; //end time for event
        private String ed; //event description
        private Tag et; //event tag (skal være en liste?, kan der være flere tags på samme event?)

        public Event(int month, int day, int startHour, int startMinute, int endHour, int endMinute)
        {
            date = new DateTime(DateTime.Now.Year, month, day);
            startTime = new TimeSpan(startHour, startMinute, 0);
            endTime = new TimeSpan(endHour, endMinute, 0);
        }

        public void chooseTag()
        {
           
        }

        public void setNotification()
        {

        }

        public void getNotification()
        {

        }

        // getters og setters for date, startTime, endTime, ed (event description) og tag
    }
}
