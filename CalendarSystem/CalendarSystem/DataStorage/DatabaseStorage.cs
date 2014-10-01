using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class DatabaseStorage : IStorage
    {
        private string _username;
        private string _password;
        private Calendar _calendar;

        public User loginAuthentication(string userName, string password)
        {
            // check if okay
            _username = userName;
            _password = password;
            _calendar = getCalendar();
        }

        private Calendar getCalendar()
        {
            // download
            return null;
        }

        public void SaveEvent(string description, int month, int day, int startHour, int endHour)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEvent(int ID, string description, int month, int day, int startHour, int endHour)
        {
            throw new System.NotImplementedException();
        }

        public IList<IEvent> GetEvents()
        {
            throw new System.NotImplementedException();
        }

        public IEvent GetEvent(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void SaveTag(Tag tag)
        {
            throw new System.NotImplementedException();
        }
    }
}
