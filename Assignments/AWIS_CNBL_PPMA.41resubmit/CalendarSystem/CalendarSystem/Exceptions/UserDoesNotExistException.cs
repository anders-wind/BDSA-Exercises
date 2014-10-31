using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        public override string Message
        {
            get { return base.Message + ": The User does not exist in the system"; }
        }
        public UserDoesNotExistException()
        {

        }

        public UserDoesNotExistException(string message)
            : base(message)
        {
        }

        public UserDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
