using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    interface IStorage
    {
        Calendar GetCalendar(User user);
        bool IsCalendarUpToDate(User user);
        User loginAuthentication(string userName, string password);
        void SaveEvent(User user, Event saveEvent);
        void SaveTag(User user, Tag tag);
    }
}
