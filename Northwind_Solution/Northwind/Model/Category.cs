using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class Category
    {
        public int _id { get; private set; }
        private string _name { get; set; }
        private string _description { get; set; }
        private string _picture; // must be something else { get; set; }
        public Category(int id, string name, string description, string picture)
        {
            _id = id;
            _name = name;
            _description = description;
            _picture = picture;
        }

        public override string ToString()
        {
            return "Category\n      ID: " + _id +
                "\n      Name: " + _name +
                "\n      Description: " + _description;
        }

        //Needs getter and setter for picture.
    }
}
