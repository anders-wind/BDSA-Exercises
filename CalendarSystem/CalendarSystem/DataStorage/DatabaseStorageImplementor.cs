using System;
using System.Collections.Generic;
using CalendarSystem.Exceptions;
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
            if(userName == null || password == null) throw new ArgumentNullException();
            if(exists(userName) != true) throw new UserDoesNotExistException();
            if(match(userName,password) != true) throw new UsernamePasswordMismatchException();

            _username = userName;
            _password = password;
            _calendar = getCalendar();
        }
        /// <summary>
        /// checks invariants
        /// </summary>
        private void checkInvariants()
        {
            if(GetAllEvents().Count != GetMaxID()) throw new Exception();
            if (EventsBelongsto(_calendar.Events, _username)) throw new Exception();
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
            if (eventToUpdate == null) new ArgumentNullException();
            if (GetEvent(eventToUpdate._ID) == null) new EventDoesNotExistException();
            var beforeEventsCount = GetAllEvents().Count;

            _calendar.updateCalenderEntry(eventToUpdate);
            // upload

            if (GetAllEvents().Count != beforeEventsCount || GetEvent(eventToUpdate._ID) == eventToUpdate) throw new StorageFailedToUpdateEventException();
        }

        public void DeleteEvent(int ID)
        {
            if(GetEvent(ID) == null) throw new ArgumentNullException();
            if(ID < 0) throw new FaultyIDException();
            var beforeEventsCount = GetAllEvents().Count;

            if (GetEvent(ID) != null || beforeEventsCount -1 != GetAllEvents().Count) throw new StorageFailedToDeleteEventException();
        }

        public IList<IEvent> GetAllEvents()
        {
            return _calendar.Events;
        }

        public IEvent GetEvent(int ID)
        {
            return _calendar.GetEvent(ID);
        }

        public IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime)
        {
            if(beginDateTime > endDateTime) throw new BeginDateIsLesserThanEndDateException();
            if(beginDateTime < new DateTime(1900,1,1) || beginDateTime > new DateTime(2100,1,1)) throw new InvalidBeginDateException();
            if(endDateTime < new DateTime(1900, 1, 1) || endDateTime > new DateTime(2100, 1, 1)) throw new InvalidEndDateException();
            var listToReturn = new List<IEvent>();

            if (listToReturn == null || !listToReturn.TrueForAll(e=>e._date.Value >= beginDateTime && e._date.Value <= endDateTime)) throw new StorageFailedToRetrieveEventsException();
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

        public bool EventsBelongsto(IList<IEvent> events, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
