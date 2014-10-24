using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    class GoogleCalendarEntry
    {
        public INotification GoogleNotification { get; set; }
        public DateTime GoogleDate { get; set; }
        public TimeSpan GoogleTimeSpan { get; set; }
        public string GoogleDescription { get; set; }
        public int GoogleID { get; private set; }
        public int GoogleTag { get; private set; }

        public void changeGoogleTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
