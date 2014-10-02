﻿using System;
using System.Collections.Generic;

namespace CalendarSystem.Model
{
    /// <summary>
    /// A class containing a datastructure with IEvents and provides methods to get the events from the datastructure.
    /// </summary>
    public class Calendar
    {
        // eventually a tree structure to create faster gets
        public IList<IEvent> _Events = new List<IEvent>();

        public void createCalenderEntry(IEvent newEvent)
        {
            _Events.Add(newEvent);
        }

        public void updateCalenderEntry(IEvent newEvent)
        {
            IEvent eventToRemove = null;
            foreach (IEvent eventToUpdate in _Events)
            {
                if (newEvent._ID == eventToUpdate._ID)
                {
                    eventToRemove = eventToUpdate;
                    break;
                }
            }
            if (eventToRemove != null)
            {
                _Events.Remove(eventToRemove);
                _Events.Add(newEvent);
            }
            throw new Exception(); // could not find event
        }

        public IEvent GetEvent(int ID)
        {
            foreach (IEvent eventToReturn in _Events)
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
