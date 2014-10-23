using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    /// <summary>
    /// An interface for event classes, used for given the minimum an event class must be able to do, and have.
    /// </summary>
    public interface IEvent
    {
        INotification _notification { get; set; }
        DateTime ?_date  { get; set; }
        TimeSpan ?_timeSpan { get; set; }
        string _description { get; set; }
        int _ID { get; }
        int tag { get; }
    }
}
