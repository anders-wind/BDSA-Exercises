using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDatabaseProject
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            using (var db = new NORTHWNDEntities())
            {
                var orders = from Category in db.Categories
                    select Category;
                orders.ToList().ForEach(Console.WriteLine);
            }
            
        }
    }
}
