using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    class StorageFailedToRetrieveEventsException : StorageException
    {
        public StorageFailedToRetrieveEventsException()
        {

        }

        public StorageFailedToRetrieveEventsException(string message)
            : base(message)
        {
        }

        public StorageFailedToRetrieveEventsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
