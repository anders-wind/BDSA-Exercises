using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    class FaultyIDException : Exception
    {
        public override string Message
        {
            get { return base.Message + "The Id is not valid. The ID must be larger than 0."; }
        }
        public FaultyIDException()
        {

        }

        public FaultyIDException(string message)
            : base(message)
        {
        }

        public FaultyIDException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
