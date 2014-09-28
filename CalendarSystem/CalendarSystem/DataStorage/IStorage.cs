using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    interface IStorage
    {
        Calendar GetCalendar(User user);
        bool IsCalendarUpToDate(User user);

        void SaveEvent(User user, Event saveEvent);
        void SaveTag(User user, Tag tag);
    }
}
