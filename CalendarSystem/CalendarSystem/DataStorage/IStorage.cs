using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    interface IStorage
    {
        User loginAuthentication(string userName, string password);
        void SaveEvent(string description, int month, int day, int startHour, int endHour);
        void UpdateEvent(int ID, string description, int month, int day, int startHour, int endHour);
        IList<IEvent> GetEvents();
        IEvent GetEvent(int ID);
        void SaveTag(Tag tag);
    }
}
