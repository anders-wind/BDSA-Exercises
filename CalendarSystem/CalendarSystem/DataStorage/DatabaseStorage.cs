﻿using System;
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

        public void SaveEvent(string description, DateTime dateTime, TimeSpan timeSpan, Notification notification)
        {
            int ID = 0; // get ID from DB
            IEvent tempEvent = new Event(description,timeSpan,dateTime, notification, ID);
            
            _calendar.createCalenderEntry(tempEvent);
            // upload
        }

        public void UpdateEvent(int ID, string description, DateTime dateTime, TimeSpan timeSpan, Notification notification)
        {
            IEvent tempEvent = new Event(description, timeSpan, dateTime, notification, ID);
            
            _calendar.updateCalenderEntry(tempEvent);
            // upload
        }

        public IList<IEvent> GetAllEvents()
        {
            return _calendar._Events;
        }

        public IEvent GetEvent(int ID)
        {
            return _calendar.GetEvent(ID);
        }

        public IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime enDateTime)
        {
            throw new NotImplementedException();
        }

        public void SaveTag(Tag tag)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyObservers()
        {
            foreach (var observer in _Observers)
            {
                observer.BeNotifiedByObserved();
            }
        }

        public void BeObserved(IObserver observer)
        {
            _Observers.Add(observer);
        }

        public void BeObserved(IList<IObserver> observers)
        {
            foreach (var observer in observers)
            {
                _Observers.Add(observer);
            }
        }
    }
}
