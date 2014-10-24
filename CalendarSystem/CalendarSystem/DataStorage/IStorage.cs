using System;
using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    /// <summary>
    /// An interface for a storage class. The interface has methods which will make it possible to get and save events into the calendar, without knowing the actual implementation.
    /// Invariants:
    /// The number of events are always less or equal to the max ID
    /// <para> @inv GetAllEvents().Count() %lt;= GetMaxID() </para> 
    /// Only data belonging to the authenticated user will be loaded
    /// <para> @inv EventsBelongTo(events, userName) </para>
    /// Events will always take place on a valid date
    /// <para> @inv (1990,1,1) &lt;= dateTime &gt;= (2100,1,1)  </para>
    /// </summary>
    interface IStorage
    {
        // TODO make pre and post conditions SDD
        /// <summary>
        /// Authenticate and download Calendar and events belonging to that user.
        /// <para> @pre userName != null </para>
        /// <para> @pre password != null </para>
        /// <para> @pre match(username, password)</para>
        /// <para> @pre exists(username)</para>
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        void loginAuthentication(string userName, string password);

        // TODO sdd the post and pre here DONE       
        /// <summary>
        /// Save an event to the storage
        /// <para>@pre eventToSave != null </para>
        /// <para>@pre GetEvent(eventToSave.ID) == null </para>
        /// <para>@pre eventToSave.ID &lt; 0 </para>
        /// <para>@post GetAllEvents().Count == self@pre.GetAllEvents().Count + 1</para>
        /// <para>@post GetEvent(eventToSave.ID) == eventToSave </para>
        /// </summary>
        /// <param name="eventToSave"></param>
        void SaveEvent(IEvent eventToSave);

        // TODO sdd the post and pre here DONE
        /// <summary>
        /// Update an event to the storage
        /// <para> @pre eventToUpdate != null </para>
        /// <para> @pre GetEvent(eventToUpdate.ID) != null </para> 
        /// <para> @post getAllEvents().Count == self@pre.GetAllEvents().Count</para>
        /// <para> @post GetEvent(eventToUpdate.ID) == eventToUpdate</para>
        /// </summary>
        /// <param name="eventToUpdate"></param>
        void UpdateEvent(IEvent eventToUpdate);

        // TODO make pre and post conditions
        /// <summary>
        /// Deletes the event with the given ID
        /// <para> @pre GetEvent(ID) != null </para>
        /// <para> @pre ID &gt; -1 </para> 
        /// <para> @post GetEvent(ID) == null </para>
        /// <para> @post getAllEvents().Count == self@pre.GetAllEvents().Count -1</para>
        /// </summary>
        /// <param name="ID">The ID of the </param>
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
        /// <returns>null if does not exist otherwise return an Event object</returns>
        IEvent GetEvent(int ID);

        // TODO sdd the post and pre here CHECK WITH TA check return in ocl
        /// <summary>
        /// Return all events between to given dates.
        /// <para> @pre beginDateTime &lt; endDateTime </para> 
        /// <para> @pre beginDateTime &gt;= new Date(1900,1,1) </para> 
        /// <para> @pre endDateTime &gt;= new Date(1900,1,1) </para> 
        /// <para> @pre beginDateTime &lt;= new Date(2100,1,1) </para> 
        /// <para> @pre endDateTime &lt;= new Date(2100,1,1) </para> 
        /// <para> @post return.TrueForAll(e=>e._date.Value >= beginDateTime && e._date.Value <= endDateTime)</para>
        /// <para> @post return != null</para>
        /// </summary>
        /// <param name="beginDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns>A list of events</returns>
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
        /// Checks if a username and password matches
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>true if they match, false otherwise</returns>
        bool match(string username, string password);

        /// <summary>
        /// Checks if a username exists in the storage
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>true if it exists, false otherwise</returns>
        bool exists(string username);

        /// <summary>
        /// Checks if the events belong to the user.
        /// </summary>
        /// <param name="events"></param>
        /// <returns> True if events belong to user </returns>
        bool EventsBelongsto(IList<IEvent> events, string userName);
    }
}
