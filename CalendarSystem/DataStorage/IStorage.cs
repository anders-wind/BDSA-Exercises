using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataStorage
{
    interface IStorage
    {
        Calendar GetCalendar(User user);
        bool isCalendarUpToDate(User user);

        void SaveEvent(User user, Event saveEvent);
        void SaveTag(User user, Tag tag);
    }
}
