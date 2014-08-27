using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPowerOf
{
    class IsPowerOf
    {
        /**
         * Has problems because it uses ints (28,3 returns true)
         */
        static bool IsPowerOfBad(int a, int b)
        {
            if (a == b) return true;
            if (a > b)
            {
                if (IsPowerOfBad(a / b, b) == true) return true;
            }
            return false;
        }

        static bool IsPowerOfGood(int a, int b, int originalB)
        {
            if (a == b) return true;
            if (a > b)
            {
                if (IsPowerOfGood(a, originalB * b, originalB) == true) return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            if(args.Length > 1)
            {
                Console.WriteLine(Convert.ToInt32(args[0]) + " " + Convert.ToInt32(args[1]));
                int args1 = Convert.ToInt32(args[0]);
                int args2 = Convert.ToInt32(args[1]);
                Console.WriteLine("\nBad method");
                Console.WriteLine("Is " + args1 + " a power of " + args2 + "? " + IsPowerOfBad(args1, args2));
                Console.WriteLine("\nGood method");
                Console.WriteLine("Is " + args1 + " a power of " + args2 + "? " + IsPowerOfGood(args1, args2, args2));
                Console.WriteLine();
            }
        }
    }   
}
