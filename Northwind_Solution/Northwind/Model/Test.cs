using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class Test
    {
        private string name;

        public Test(string n)
        {
            name = n;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}
