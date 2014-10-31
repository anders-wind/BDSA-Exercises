using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class StorageException : Exception
    {
        public override string Message
        {
            get { return base.Message + "A error occured in the Storage"; }
        }
        public StorageException()
        {

        }

        public StorageException(string message)
            : base(message)
        {
        }

        public StorageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
