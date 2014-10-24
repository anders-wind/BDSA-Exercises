using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    /// <summary>
    /// This class is a proxy class for the storage. Instead of the storage retrieving the events from the database everytime they are needed, they can be called for only once. 
    /// This class is part of the Caching Proxy
    /// </summary>
    class StorageProxy : IStorage
    {
        private IStorage _trueStorage;
        private IList<IEvent> allEvents;

        public StorageProxy(IStorage trueStorage)
        {
            _trueStorage = trueStorage;
        }
        public void loginAuthentication(string userName, string password)
        {
            _trueStorage.loginAuthentication(userName,password);
        }

        public void SaveEvent(IEvent eventToSave)
        {
            _trueStorage.SaveEvent(eventToSave);
        }

        public void UpdateEvent(IEvent eventToUpdate)
        {
            _trueStorage.UpdateEvent(eventToUpdate);
        }

        public void DeleteEvent(int ID)
        {
            throw new NotImplementedException();
        }

        public IList<IEvent> GetAllEvents()
        {
            if (allEvents == null) allEvents = _trueStorage.GetAllEvents();
            return allEvents;
        }

        public IEvent GetEvent(int ID)
        {
            if (allEvents != null)
            {
                foreach (var anEvent in allEvents)
                {
                    if (anEvent._ID == ID) return anEvent;
                }
                return null;
            }
            return _trueStorage.GetEvent(ID);
        }

        public IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime)
        {
            var tempList = new List<IEvent>();
            if (allEvents != null)
            {
                foreach (var anEvent in allEvents)
                {
                    // find the events add them to the list
                }
                return tempList;
            }
            return _trueStorage.GetEventsBetweenDates(beginDateTime, endDateTime);
        }

        public void CreateTag(string tag)
        {
            throw new NotImplementedException();
        }

        public int GetMaxID()
        {
            throw new NotImplementedException();
        }
    }
}
