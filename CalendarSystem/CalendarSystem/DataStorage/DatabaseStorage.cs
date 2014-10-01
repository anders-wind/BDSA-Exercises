using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class DatabaseStorage : IStorage
    {
        private IList<IObserver> _Observers = new List<IObserver>();

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

        public void NotifyObservers()
        {
            foreach (var observer in _Observers)
            {
                observer.NotifyObserver();
            }
        }

        public void Observe(IObserver observer)
        {
            _Observers.Add(observer);
        }

        public void Observe(IList<IObserver> observers)
        {
            foreach (var observer in observers)
            {
                _Observers.Add(observer);
            }
        }
    }
}
