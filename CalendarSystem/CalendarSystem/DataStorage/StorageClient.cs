using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class StorageClient
    {
        public IStorage Storage { get; private set; };

        /// <summary>
        /// The constructor takes a connection and a storagetype to create the storage and the given connection.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="storageType"></param>
        public StorageClient(AbstractStorageFactory storageFactory)
        {
            Storage = storageFactory.CreateStorage();
        }
    }
}
