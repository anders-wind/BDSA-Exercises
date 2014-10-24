using System;
using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    /// <summary>
    /// An interface for a storage class. The interface has methods which will make it possible to get and save events into the calendar, without knowing the actual implementation.
    /// Invariants:
    /// The number of events are always less or equal to the max ID
    /// <para> @inv GetAllEvents().Count() %ls;= GetMaxID() </para> 
    /// Only data belonging to the authenticated user will be loaded
    /// <para> @inv EventsBelongTo(events, userName) </para>
    /// Events can never be of value null
    /// <para> @inv IEvent != null </para>
    /// Events will always take place on a valid date
    /// <para> @inv (1990,1,1) &ls;= dateTime &gt;= (2100,1,1)  </para>
    /// </summary>
    interface IStorage
    {
        /// <summary>
        /// Authenticate and download Calendar and events belonging to that user.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <pre> userName != null </pre>
        /// <pre> password != null </pre>
        /// <pre> if(username !match password)</pre>
        /// <pre> if(username !exist)</pre>
        /// <returns></returns>
        // TODO make pre and post conditions make method for autherization
        void loginAuthentication(string userName, string password);

        /// <summary>
        /// Save an event to the storage
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dateTime"></param>
        /// <param name="timeSpan"></param>
        /// <param name="notification"></param>
        /// <pre> eventToSave != null </pre>
        /// <pre> GetEvent(eventToSave.ID) == null </pre>
        /// <pre> eventToSave.ID < 0 </pre>
        /// <post> GetAllEvents().Count == self@pre.GetAllEvents().Count + 1 </post>
        /// <post> GetEvent(eventToSave.ID) == eventToSave </post>
        // TODO sdd the post and pre here DONE
        void SaveEvent(IEvent eventToSave);

        /// <summary>
        /// Update an event to the storage
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dateTime"></param>
        /// <param name="timeSpan"></param>
        /// <param name="notification"></param>
        /// <pre> eventToUpdate != null </pre>
        /// <pre> GetEvent(eventToUpdate.ID) != null </pre> 
        /// <post> getAllEvents().Count == self@pre.GetAllEvents().Count</post>
        /// <post> GetEvent(eventToUpdate.ID) == eventToUpdate</post>
        // TODO sdd the post and pre here DONE
        void UpdateEvent(IEvent eventToUpdate);

        /// <summary>
        /// Deletes the event with the given ID
        /// </summary>
        /// <param name="ID">The ID of the </param>
        // TODO make pre and post conditions
        void DeleteEvent(int ID);

        /// <summary>
        /// Returns all events in the active calendar
        /// </summary>
        /// <returns></returns>
        IList<IEvent> GetAllEvents();

        /// <summary>
        /// Get a single event with a given ID if possible.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        IEvent GetEvent(int ID);

        /// <summary>
        /// Return all events between to given dates.
        /// </summary>
        /// <param name="beginDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <pre> beginDateTime < endDateTime </pre> 
        /// <pre> beginDateTime >= new Date(1900,1,1) </pre> 
        /// <pre> endDateTime >= new Date(1900,1,1) </pre> 
        /// <pre> beginDateTime <= new Date(2100,1,1) </pre> 
        /// <pre> endDateTime <= new Date(2100,1,1) </pre> 
        /// <post> return.TrueForAll(e=>e._date.Value >= beginDateTime && e._date.Value <= endDateTime)</post>
        /// <post> return != null</post>
        /// <returns></returns>
        // TODO sdd the post and pre here CHECK WITH TA check return in ocl
        IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime);

        /// <summary>
        /// Create a tag and save it in the storage.
        /// </summary>
        /// <param name="tag"></param>
        void CreateTag(string tag);

        /// <summary>
        /// Returns the highest ID in the storage.
        /// </summary>
        /// <returns>an Int from 0 -> Int32.MaxValue</returns>
        int GetMaxID();

        /// <summary>
        /// Checks if the events belong to the user.
        /// </summary>
        /// <param name="events"></param>
        /// <returns> True if events belong to user </returns>
        bool EventsBelongsto(IList<IEvent> events, string userName);
    }
}
