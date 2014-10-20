using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.DataStorage
{
    class OfflineConnectionStrategy : IConnectionBaseStrategy
    {
        public IStorage GetStorage()
        {
            return new FakeStorageImplementor();
        }
    }
}
