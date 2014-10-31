using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    class StorageFailedToDeleteEventException : StorageException
    {
        public override string Message
        {
            get { return base.Message + ": The Storage failed to delete an event"; }
        }
        public StorageFailedToDeleteEventException()
        {

        }

        public StorageFailedToDeleteEventException(string message)
            : base(message)
        {
        }

        public StorageFailedToDeleteEventException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
