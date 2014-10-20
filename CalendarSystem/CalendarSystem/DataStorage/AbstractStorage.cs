using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class AbstractStorage : IAbstractStorage
    {
        private IStorage _storage;
        public IConnection _connection { private get; set; }
        public enum storageTypes
        {
            TestStub,
            Database

        }

        /// <summary>
        /// Create the Istorage depending on a given storage type.
        /// </summary>
        /// <param name="storageType"></param>
        /// <returns></returns>
        private IStorage createStorage(storageTypes storageType)
        {
            if (storageType == storageTypes.TestStub)
            {
                return new FakeStorage();
            }
            else if (storageType == storageTypes.Database)
            {
                return new DatabaseStorage();
            }
            throw new Exception();
        }

        /// <summary>
        /// The constructor takes a connection and a storagetype to create the storage and the given connection.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="storageType"></param>
        public AbstractStorage(IConnection connection, storageTypes storageType)
        {
            _storage = createStorage(storageType);
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
            return _storage.GetAllEvents();
        }
        public IEvent GetEvent(int ID)
        {
            return _storage.GetEvent(ID);
        }
        public IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime)
        {
            return _storage.GetEventsBetweenDates(beginDateTime, endDateTime);
        }
        public void CreateTag(string tag)
        {
            _storage.CreateTag(tag);
        }
    }
}
