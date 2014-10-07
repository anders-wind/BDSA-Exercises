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
            NorthwindController northwindController = new NorthwindController(new DataStorageCSVfiles());

            northwindController.Subscribe((o, order) => Console.WriteLine(order));

            Console.ReadKey();
        }

    }
}
