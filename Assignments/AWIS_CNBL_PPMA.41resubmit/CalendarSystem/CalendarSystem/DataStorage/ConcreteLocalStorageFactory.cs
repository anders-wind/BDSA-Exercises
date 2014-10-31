using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.DataStorage
{
    class ConcreteLocalStorageFactory : AbstractStorageFactory
    {
        public override StorageAbstractionBridge CreateStorage()
        {
            var tempBridge = new StorageRefinedAbstractionBridge();
            tempBridge.Storage = new LocalStorageImplementor();
            return tempBridge;
        }
    }
}
