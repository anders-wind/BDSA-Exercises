using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataStorage
{
    class FakeStorage : IStorage
    {
        public Calendar GetCalendar(User user)
        {
            throw new NotImplementedException();
        }

        public bool isCalendarUpToDate(User user)
        {
            throw new NotImplementedException();
        }

        public void SaveEvent(User user, Event saveEvent)
        {
            throw new NotImplementedException();
        }

        public void SaveTag(User user, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
