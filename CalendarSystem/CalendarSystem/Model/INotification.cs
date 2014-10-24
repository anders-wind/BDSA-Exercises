using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    // todo invariants here
    /// <summary>
    /// Interface for objects of type notification
    /// Invariants:
    /// Notifications will always have a date between year 1900 and 2100
    /// <para> @inv (1990,1,1) &lt;= date &gt;= (2100,1,1)  </para>
    /// IsInAlarmState must always be true if the current time is greater than the time set for the notification
    /// <para> @inv DateTime.Now &gt; _date == IsInAlarmState </para>
    /// </summary>
    public interface INotification
    {
        string Description { get; set; }
        bool IsInAlarmState();


    }
}
