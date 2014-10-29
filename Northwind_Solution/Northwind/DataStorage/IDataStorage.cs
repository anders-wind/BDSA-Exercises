using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataStorage
{
    public interface IDataStorage
    {
        /// <summary>
        /// Returns all products in the storage
        /// </summary>
        /// <returns>A list of Product objects</returns>
        IList<Product> Products();
        /// <summary>
        /// Returns all products of a given Catagory
        /// </summary>
        /// <param name="ID">The Category ID the products must have</param>
        /// <returns>A list of Product objects</returns>
        IList<Product> Categories(int ID);
        /// <summary>
        /// Returns all the Orders in the storage
        /// </summary>
        /// <returns>A list of Order objects</returns>
        IList<Order> Orders();
        IList<Employee> Employees();
        IList<Order_Detail> OrderDetails();
        /// <summary>
        /// Creates an Order and save it in the storage
        /// </summary>
        /// <param name="order">The Order which must be saved into the storage</param>
        void CreateOrder(Order order);
        /// <summary>
        /// Returns the Highest OrderId in the storage
        /// </summary>
        /// <returns>The Highest OrderID int</returns>
        int maxOrderID();
    }
}
