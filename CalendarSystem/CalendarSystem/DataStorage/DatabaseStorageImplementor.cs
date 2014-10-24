using System;
using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    /// <summary>
    /// A storage class which implements the IStorage interface.
    /// The class is meant to have a connection to a database where events will be added when they are created and put in the local Calendar class.
    /// </summary>
    internal class DatabaseStorageImplementor : IStorage
    {

        private string _username;
        private string _password;
        private Calendar _calendar;

        public void loginAuthentication(string userName, string password)
        {
            // check if okay
            _username = userName;
            _password = password;
            _calendar = getCalendar();
        }

        private Calendar getCalendar()
        {
            // download
            throw new NotImplementedException();
        }

        public void SaveEvent(IEvent eventToSave)
        {

            _calendar.createCalenderEntry(eventToSave);
            // upload
        }

        public void UpdateEvent(IEvent eventToUpdate)
        {

            _calendar.updateCalenderEntry(eventToUpdate);
            // upload
        }

        public void DeleteEvent(int ID)
        {
            throw new NotImplementedException();
        }

        public IList<IEvent> GetAllEvents()
        {
            return _calendar._Events;
        }

        public IEvent GetEvent(int ID)
        {
            return _calendar.GetEvent(ID);
        }

        public IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public void CreateTag(string tag)
        {
            throw new System.NotImplementedException();
        }

        public int GetMaxID()
        {
            throw new NotImplementedException();
        }

        public bool match(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool exists(string username)
        {
            throw new NotImplementedException();
        }
    }
}
