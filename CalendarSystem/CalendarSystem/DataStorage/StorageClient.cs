using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class StorageClient
    {
        public StorageAbstractionBridge Storage { get; private set; }

        /// <summary>
        /// The constructor takes a connection and a storagetype to create the storage and the given connection.
        /// </summary>
        /// <param name="storageFactory">The factory which creates the storage.</param>
        public StorageClient(IConnectionBaseStrategy connection)
        {
            Storage = connection.GetStorageFactory().CreateStorage();
        }

        public void saveToGoogle(LinkedEventsComposite linkedEvents)
        {
            CommandManager commandManager = new CommandManager();
            var tempList = new List<IEvent>();
            tempList.Add(linkedEvents);
            foreach (var IEvent in tempList)
            {
                if (IEvent is Event || IEvent is GoogleCalendarEventAdapter)
                {
                    commandManager.QueueCommands(new StoreToGoogleCommand(IEvent));
                }
                else if (IEvent is LinkedEventsComposite)
                {
                    foreach (var child in (LinkedEventsComposite)IEvent)
                    {
                        tempList.Add(child);
                    }
                }
            }
            try
            {
                commandManager.runCommands();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
