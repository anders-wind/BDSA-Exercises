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
            new DataStorageCSVfiles().Products();
        }
    }
}
