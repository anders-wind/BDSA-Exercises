using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataStorage;

namespace Northwind
{
    class Startup
    {
        static void Main(string[] args)
        {
            IDataStorage storage = new DataStorageCSVfiles();
            NorthwindController northwindController = new NorthwindController(storage);
            northwindController._subscribers.Add(e => e);

            Console.ReadKey();
        }
    }
}
