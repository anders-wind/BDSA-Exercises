using System;
using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class FakeStorage : IStorage
    {
        public User loginAuthentication(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void SaveEvent(string description, int month, int day, int startHour, int endHour)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(int ID, string description, int month, int day, int startHour, int endHour)
        {
            throw new NotImplementedException();
        }

        public IList<IEvent> GetEvents()
        {
            throw new NotImplementedException();
        }

        public IEvent GetEvent(int ID)
        {
            throw new NotImplementedException();
        }

        public void SaveTag(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
