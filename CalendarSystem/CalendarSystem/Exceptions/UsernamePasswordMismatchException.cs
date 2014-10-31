using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class UsernamePasswordMismatchException : Exception
    {
        public override string Message
        {
            get { return base.Message + ": The Username and password does not match"; }
        }
        public UsernamePasswordMismatchException()
        {

        }

        public UsernamePasswordMismatchException(string message)
            : base(message)
        {
        }

        public UsernamePasswordMismatchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
