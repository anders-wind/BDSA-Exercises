using System;
using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    /// <summary>
    /// A storage class which implements the IStorage interface.
    /// The class is a fake storage in that sense that the fields and methods return components that are created at runtime. Therefore no events will be accessible from between runs of the system.
    /// </summary>
    class FakeStorageImplementor : IStorage
    {

        public void loginAuthentication(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void SaveEvent(string description, DateTime dateTime, TimeSpan timeSpan, Notification notification)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(int ID, string description, DateTime dateTime, TimeSpan timeSpan, Notification notification)
        {
            throw new NotImplementedException();
        }

        public IList<IEvent> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public IEvent GetEvent(int ID)
        {
            throw new NotImplementedException();
        }

        public IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public void CreateTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
