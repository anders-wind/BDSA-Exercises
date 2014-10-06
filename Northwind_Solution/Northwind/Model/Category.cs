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
        private int _id;
        private string _name;
        private string _description;
        private string _picture; // must be something else
        public Category(int id, string name, string description, string picture)
        {
            _id = id;
            _name = name;
            _description = description;
            _picture = picture;
        }

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        //Needs getter and setter for picture.
    }
}
