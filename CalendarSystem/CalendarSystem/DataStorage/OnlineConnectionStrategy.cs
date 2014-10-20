using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.DataStorage
{
    class OnlineConnectionStrategy : IConnectionBaseStrategy
    {
        public IStorage GetStorage()
        {
            return new DatabaseStorageImplementor();
        }
    }
}
