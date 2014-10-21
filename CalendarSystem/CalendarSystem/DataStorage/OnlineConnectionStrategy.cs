using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class OnlineConnectionStrategy : IConnectionBaseStrategy
    {
        public AbstractStorageFactory GetStorageFactory()
        {
            return new ConcreteDBStorageFactory();
        }
    }
}
