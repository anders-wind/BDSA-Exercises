using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.DataStorage
{
    class ConcreteLocalStorageFactory : AbstractStorageFactory
    {
        public override IStorage CreateStorage()
        {
            return new LocalStorageImplementor();
        }
    }
}
