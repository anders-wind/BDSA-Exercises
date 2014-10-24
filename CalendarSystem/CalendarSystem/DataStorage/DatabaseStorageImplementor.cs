using System;
using System.Collections.Generic;
using CalendarSystem.Exceptions;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    //TODO the code implementation of pre post conditions is in this class document
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
            if(userName == null || password == null) throw new ArgumentNullException();
            if(exists(userName) != true) throw new UserDoesNotExistException();
            if(match(userName,password) != true) throw new UsernamePasswordMismatchException();

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
            if(eventToSave == null) throw new ArgumentNullException();
            if(GetEvent(eventToSave._ID) != null) throw new EventAlreadyExistsException();
            if (eventToSave._ID < 0) throw new FaultyIDException();
            var beforeEventsCount = GetAllEvents().Count;

            _calendar.createCalenderEntry(eventToSave);
            // upload

            if (beforeEventsCount + 1 != GetAllEvents().Count || GetEvent(eventToSave._ID) != eventToSave) throw new StorageFailedToSaveEventException();
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
