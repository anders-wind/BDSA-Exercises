using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class StorageFailedToUpdateEventException : Exception
    {
        public StorageFailedToUpdateEventException()
        {

        }

        public StorageFailedToUpdateEventException(string message)
            : base(message)
        {
        }

        public StorageFailedToUpdateEventException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
