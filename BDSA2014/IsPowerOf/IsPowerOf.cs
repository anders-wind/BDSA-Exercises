using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPowerOf
{
    class IsPowerOf
    {
        static bool IsPowerOfMethod(int a, int b)
        {
            if (a%b != 0 || b <= 0) //Prevents integer rounding errors and can catch false-results before jumping into the next if statement.
            {
                return false;
            }
            if (b == 1)
            {
                if (a == 1)
                {
                    return true;
                }
                return false;
            }
            if (a >= b && (a.Equals(b) || IsPowerOfMethod((a / b), b) == true))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Requires exactly 2 arguments!");
            }
            else
            {
                Console.WriteLine("Is " + args[0] + " a power of " + args[1] + "?.\nThe answer is ...");
                Console.Out.WriteLine(IsPowerOfMethod(Convert.ToInt32(args[0]), Convert.ToInt32(args[1])));
            }
            
        }     
    }
}
