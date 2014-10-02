using System;
using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    interface IStorage : IObservable
    {
        /// <summary>
        /// Authenticate and download Calendar and events belonging to that user.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User loginAuthentication(string userName, string password);

        /// <summary>
        /// Save an event to the storage
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dateTime"></param>
        /// <param name="timeSpan"></param>
        /// <param name="notification"></param>
        void SaveEvent(string description, DateTime dateTime, TimeSpan timeSpan, Notification notification);
        void UpdateEvent(int ID, string description, DateTime dateTime, TimeSpan timeSpan, Notification notification);
        IList<IEvent> GetAllEvents();
        IEvent GetEvent(int ID);
        IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime enDateTime);
        void SaveTag(Tag tag);
    }
}
