using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class StorageRefinedAbstractionBridge : StorageAbstractionBridge
    {
        // can override the methods neccesary.
        public override void LoginAuthentication(string userName, string password)
        {
            Storage.loginAuthentication(userName, password);
        }

        public override void SaveEvent(IEvent eventToSave)
        {
            Storage.SaveEvent(eventToSave._description, eventToSave._date, eventToSave._timeSpan, eventToSave._notification);
        }

        public override void UpdateEvent(IEvent eventToUpdate)
        {
            Storage.UpdateEvent(eventToUpdate._ID, eventToUpdate._description, eventToUpdate._date, eventToUpdate._timeSpan, eventToUpdate._notification);
        }

        public override IList<IEvent> GetAllEvents()
        {
            return Storage.GetAllEvents();
        }

        public override IEvent GetEvent(int ID)
        {
            return Storage.GetEvent(ID);
        }

        public override IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime)
        {
            return Storage.GetEventsBetweenDates(beginDateTime, endDateTime);
        }

        public override void CreateTag(string tag)
        {
            Storage.CreateTag(tag);
        }
    }
}
