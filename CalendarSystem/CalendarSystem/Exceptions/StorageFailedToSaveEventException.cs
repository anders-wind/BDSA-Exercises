using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class StorageFailedToSaveEventException : StorageException
    {
        public StorageFailedToSaveEventException()
        {

        }

        public StorageFailedToSaveEventException(string message)
            : base(message)
        {
        }

        public StorageFailedToSaveEventException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
