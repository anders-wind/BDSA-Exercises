using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class OfflineConnectionStrategy : IConnectionBaseStrategy
    {
        public IStorage GetStorage()
        {
            return new LocalStorageImplementor();
        }

        public void saveEvent(IList<IEvent> events)
        {
            throw new NotImplementedException();
        }
    }
}
