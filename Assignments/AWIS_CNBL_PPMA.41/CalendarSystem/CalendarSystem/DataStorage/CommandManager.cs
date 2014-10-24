using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalendarSystem.DataStorage
{
    class CommandManager
    {
        Queue<IUndoableCommand> Commands = new Queue<IUndoableCommand>();
        Stack<IUndoableCommand> UndoableCommands = new Stack<IUndoableCommand>();

        public void QueueCommands(IUndoableCommand command)
        {
            Commands.Enqueue(command);
        }

        public void runCommands()
        {
            try
            {
                while (Commands.Count != 0)
                {
                    var tempCommand = Commands.Dequeue();
                    UndoableCommands.Push(tempCommand);
                    tempCommand.Execute();
                }
            }
            catch (Exception ex)
            {
                undoAll();
                throw ex;
            }
        }
        
        public void undoLast()
        {
            if(UndoableCommands.Count != 0)UndoableCommands.Pop().Undo();
        }

        public void undoAll()
        {
            while (UndoableCommands.Count != 0)
            {
                UndoableCommands.Pop().Undo();
            }
        }
    }
}
