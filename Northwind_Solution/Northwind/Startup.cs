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
            var test = new DataStorageCSVfiles().Orders();

            foreach(var el in test)
            {
                foreach(var t in el.orderDetails)
                {
                    Console.WriteLine(t.id);
                }
            }

            Console.ReadKey();
        }
    }
}
