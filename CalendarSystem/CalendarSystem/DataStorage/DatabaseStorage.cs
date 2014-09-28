using System;

namespace CalendarSystem.DataStorage
{
    class DatabaseStorage : IStorage
    {
        public Calendar GetCalendar(User user)
        {
            throw new NotImplementedException();
        }

        public bool isCalendarUpToDate(User user)
        {
            throw new NotImplementedException();
        }

        public void SaveEvent(User user, Event saveEvent)
        {
            throw new NotImplementedException();
        }

        public void SaveTag(User user, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
