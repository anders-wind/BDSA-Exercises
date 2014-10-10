using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.DataStorage
{
    interface IUndoableCommand
    {
        void Undo();
        void Execute();
    }
}
