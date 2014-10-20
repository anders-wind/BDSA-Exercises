using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.DataStorage
{
    abstract class AbstractStorageFactory
    {
        public abstract IStorage CreateStorage();
    }
}
