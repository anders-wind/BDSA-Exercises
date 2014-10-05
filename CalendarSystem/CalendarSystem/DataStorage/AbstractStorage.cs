﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class AbstractStorage : IAbstractStorage
    {
        public enum storageTypes
        {
            TestStub,
            Database

        }

        private IStorage createStorageFactory(storageTypes storageType)
        {
            if (storageType == storageTypes.TestStub)
            {
                return new FakeStorage();
            }
            else if (storageType == storageTypes.TestStub)
            {
                return new DatabaseStorage();
            }
            throw new Exception();
        }

        private IStorage _storage;
        public IConnection _connection { private get; set; }

        public AbstractStorage(IStorage storage, IConnection connection, storageTypes storageType )
        {
            _storage = createStorageFactory(storageType);
            _connection = connection;
        }

        public void loginAuthentication(string userName, string password)
        {
            _storage.loginAuthentication(userName, password);
        }
        public void SaveEvent(string description, DateTime dateTime, TimeSpan timeSpan, Notification notification)
        {
            _storage.SaveEvent(description,dateTime,timeSpan,notification);
        }
        public void UpdateEvent(int ID, string description, DateTime dateTime, TimeSpan timeSpan, Notification notification)
        {
            _storage.UpdateEvent(ID, description, dateTime, timeSpan, notification);
        }
        public IList<IEvent> GetAllEvents()
        {
            _storage.GetAllEvents();
        }
        public IEvent GetEvent(int ID)
        {
            _storage.GetEvent(ID);
        }
        public IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime)
        {
            _storage.GetEventsBetweenDates(beginDateTime, endDateTime);
        }
        public void CreateTag(Tag tag)
        {
            _storage.CreateTag(tag);
        }
        public void NotifyObservers()
        {
            _storage.NotifyObservers();
        }
        public void BeObserved(IObserver observer)
        {
            _storage.BeObserved(observer);
        }
        public void BeObserved(IList<IObserver> observers)
        {
            _storage.BeObserved(observers);
        }
    }
}
