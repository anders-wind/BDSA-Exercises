using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    /// <summary>
    /// Interface for objects of type notification
    /// Invariants:
    /// Notifications will always have a date
    /// <para> @inv _date != null </para>
    /// IsInAlarmState must always be true if the current time is greater than the time set for the notification
    /// <para> @inv DateTime.Now &gt; _date == IsInAlarmState </para>
    /// </summary>
    public interface INotification
    {
        string Description { get; set; }
        bool IsInAlarmState();


    }
}
