using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class OnlineConnectionStrategy : IConnectionBaseStrategy
    {
        public IStorage GetStorage()
        {
            return new DatabaseStorageImplementor();
        }

        public void saveEvent(IList<IEvent> events)
        {
            var commandManager = new CommandManager();
            foreach (var iEvent in events)
            {
                if (iEvent is Event)
                {
                    commandManager.QueueCommands(new StoreToGoogleCommand(iEvent));
                }
                if (iEvent is LinkedEventsComposite)
                {
                    foreach (var child in (LinkedEventsComposite)iEvent)
                    {
                        events.Add(child);
                    }
                }
            }
            // if this fails change the strategy pattern to the offline strategy.
            try
            {
                commandManager.runCommands();
            }
            catch (Exception ex)
            {
                /// change to an offline connection.
                throw ex;
            }
        }
    }
}
