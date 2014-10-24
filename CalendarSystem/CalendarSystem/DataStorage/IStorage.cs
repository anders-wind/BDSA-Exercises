using System;
using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    /// <summary>
    /// An interface for a storage class. The interface has methods which will make it possible to get and save events into the calendar, without knowing the actual implementation.
    /// </summary>
    interface IStorage
    {
        /// <summary>
        /// Authenticate and download Calendar and events belonging to that user.
        /// <para> @pre userName != null </para>
        /// <para> @pre password != null </para>
        /// <para> @pre username.match(password)</para>
        /// <para> @pre exist(username)</para>
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        // TODO make pre and post conditions make method for autherization
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

        /// <summary>
        /// Update an event to the storage
        /// <para> @pre eventToUpdate != null </para>
        /// <para> @pre GetEvent(eventToUpdate.ID) != null </para> 
        /// <para> @post getAllEvents().Count == self@pre.GetAllEvents().Count</para>
        /// <para> @post GetEvent(eventToUpdate.ID) == eventToUpdate</para>
        /// </summary>
        /// <param name="eventToUpdate"></param>
        // TODO sdd the post and pre here DONE
        void UpdateEvent(IEvent eventToUpdate);

        /// <summary>
        /// Deletes the event with the given ID
        /// <para> @pre GetEvent(ID) != null </para>
        /// <para> @pre ID &gt; -1 </para> 
        /// <para> @post GetEvent(ID) == null </para>
        /// <para> @post getAllEvents().Count == self@pre.GetAllEvents().Count -1</para>
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
        /// <returns>null if does not exist otherwise return an Event object</returns>
        IEvent GetEvent(int ID);

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
    }
}
