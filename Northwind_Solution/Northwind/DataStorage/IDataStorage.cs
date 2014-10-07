using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model;

namespace Northwind.DataStorage
{
    interface IDataStorage
    {
        IList<Product> Products();
        IList<Category> Categories(int ID);
        IList<Order> Orders();
        void CreateOrder(Order order);
    }
}
