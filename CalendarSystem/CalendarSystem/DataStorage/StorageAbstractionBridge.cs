using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class StorageAbstractionBridge
    {
        public IStorage Storage { get; set; }


        public virtual void loginAuthentication(string userName, string password)
        {
            Storage.loginAuthentication(userName,password);
        }

        public virtual void SaveEvent(IEvent eventToSave)
        {
            Storage.SaveEvent(eventToSave._description, eventToSave._date, eventToSave._timeSpan, eventToSave._notification);
        }

        public virtual void UpdateEvent(IEvent eventToUpdate)
        {
            Storage.UpdateEvent(eventToUpdate._ID, eventToUpdate._description, eventToUpdate._date, eventToUpdate._timeSpan, eventToUpdate._notification);
        }

        public virtual IList<IEvent> GetAllEvents()
        {
            Storage.GetAllEvents();
        }

        public virtual IEvent GetEvent(int ID)
        {
            Storage.GetEvent(ID);
        }

        public virtual IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime)
        {
            Storage.GetEventsBetweenDates(beginDateTime, endDateTime);
        }

        public virtual void CreateTag(string tag)
        {
            Storage.CreateTag(tag);
        }
    }
}
