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


        public virtual void LoginAuthentication(string userName, string password)
        {
            Storage.LoginAuthentication(userName,password);
        }

        public virtual void SaveEvent(IEvent eventToSave)
        {
            Storage.SaveEvent(eventToSave);
        }

        public virtual void UpdateEvent(IEvent eventToUpdate)
        {
            Storage.UpdateEvent(eventToUpdate);
        }

        public virtual IList<IEvent> GetAllEvents()
        {
            return Storage.GetAllEvents();
        }

        public virtual IEvent GetEvent(int ID)
        {
            return Storage.GetEvent(ID);
        }

        public virtual IList<IEvent> GetEventsBetweenDates(DateTime beginDateTime, DateTime endDateTime)
        {
            return Storage.GetEventsBetweenDates(beginDateTime, endDateTime);
        }

        public virtual void CreateTag(string tag)
        {
            Storage.CreateTag(tag);
        }
    }
}
