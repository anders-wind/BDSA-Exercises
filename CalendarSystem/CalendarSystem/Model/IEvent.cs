using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    interface IEvent
    {
        Notification _Notification { get; set; }
        DateTime _Date  { get; set; }
        TimeSpan _TimeSpan { get; set; }
        string _Description { get; set; }

        void changeTag(Tag tag);
    }
}
