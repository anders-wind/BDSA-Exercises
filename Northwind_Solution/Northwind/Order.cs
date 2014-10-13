//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Northwind
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.Order_Details = new HashSet<Order_Detail>();
        }

        public Order(int orderId, DateTime? orderDate, DateTime? requiredDate, DateTime? shippedDate, decimal? freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, ICollection<Order_Detail> orderDetails, string shipCountry)
        {
            OrderID = orderId;
            OrderDate = orderDate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            Freight = freight;
            ShipName = shipName;
            ShipAddress = shipAddress;
            ShipCity = shipCity;
            ShipRegion = shipRegion;
            ShipPostalCode = shipPostalCode;
            Order_Details = orderDetails;
            ShipCountry = shipCountry;
        }

        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<int> ShipVia { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Order_Detail> Order_Details { get; set; }
        public virtual Shipper Shipper { get; set; }


        public override string ToString()
        {
            return "Order" +
                "\n      Order ID: " + OrderID + 
                "\n      Order Details: " + Order_Details +
                "\n      Order Date: " + OrderDate +
                "\n      Required Date: " + RequiredDate +
                "\n      Shipped Date: " + ShippedDate +
                "\n      Freight: " + Freight +
                "\n      Ship Name: " + ShipName +
                "\n      Ship Adress: " + ShipAddress +
                "\n      Ship City: " + ShipCity +
                "\n      Ship Region: " + ShipRegion +
                "\n      Ship Postal Code: " + ShipPostalCode +
                "\n      Ship Country: " + ShipCountry;
        }
    }
}