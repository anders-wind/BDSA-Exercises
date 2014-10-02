using System;
using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class FakeStorage : IStorage
    {
        private IList<IObserver> _Observers = new List<IObserver>();

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

        public IList<IEvent> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public IEvent GetEvent(int ID)
        {
            throw new NotImplementedException();
        }

        public IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime enDateTime)
        {
            throw new NotImplementedException();
        }

        public void SaveTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void NotifyObservers()
        {
            throw new NotImplementedException();
        }

        public void BeObserved(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void BeObserved(IList<IObserver> observers)
        {
            throw new NotImplementedException();
        }
    }
}
