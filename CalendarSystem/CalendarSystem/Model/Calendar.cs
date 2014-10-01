using System.Collections.Generic;

namespace CalendarSystem.Model
{
    public class Calendar
    {
        // eventually a tree structure to create faster gets
        private IList<IEvent> _Events = new List<IEvent>();

        public void createCalenderEntry(string description, int month, int day, int startHour, int endHour)
        {
            Event calenderEvent = new Event(description, month, day, startHour, endHour, _Events.Count);
            _Events.Add(calenderEvent);
        }

        public void createCalenderEntry(IEvent newEvent)
        {
            _Events.Add(newEvent);
        }

        public void updateCalenderEntry()
        {

        }
    }


    

}
