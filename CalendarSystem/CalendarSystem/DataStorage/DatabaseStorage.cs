using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class DatabaseStorage : IStorage
    {
        public Calendar GetCalendar(User user)
        {
            throw new System.NotImplementedException();
        }

        public bool isCalendarUpToDate(User user)
        {
            throw new System.NotImplementedException();
        }

        public void SaveEvent(User user, Event saveEvent)
        {
            throw new System.NotImplementedException();
        }

        public void SaveTag(User user, Tag tag)
        {
            throw new System.NotImplementedException();
        }
    }
}
