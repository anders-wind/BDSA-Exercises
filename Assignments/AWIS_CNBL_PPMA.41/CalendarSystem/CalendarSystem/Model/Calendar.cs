using System;
using System.Collections.Generic;

namespace CalendarSystem.Model
{
    /// <summary>
    /// A class containing a datastructure with IEvents and provides methods to get the events from the datastructure.
    /// </summary>
    public class Calendar
    {
        // eventually a tree structure to create faster gets
        public IList<IEvent> Events = new List<IEvent>();

        public void createCalenderEntry(IEvent newEvent)
        {
            Events.Add(newEvent);
        }

        public void updateCalenderEntry(IEvent newEvent)
        {
            IEvent eventToRemove = null;
            foreach (IEvent eventToUpdate in Events)
            {
                if (newEvent._ID == eventToUpdate._ID)
                {
                    eventToRemove = eventToUpdate;
                    break;
                }
            }
            if (eventToRemove != null)
            {
                Events.Remove(eventToRemove);
                Events.Add(newEvent);
            }
            throw new Exception(); // could not find event
        }

        public IEvent GetEvent(int ID)
        {
            foreach (IEvent eventToReturn in Events)
            {
                if (ID == eventToReturn._ID)
                {
                    return eventToReturn;
                }
            }
            throw new Exception(); // could not find event
        }
    }
}
