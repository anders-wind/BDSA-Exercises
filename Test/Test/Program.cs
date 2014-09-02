using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        public static Boolean IsTrue;

        private static bool IsPowerOfMethod(int a, int b)
        {
            // YOUR CODE GOES HERE

            //if (a%b != 0 || b <= 0)
            //{
            //    return false;
            //}

            if (b == 1)
            {
                if (a == 1)
                {
                    return true;
                }
                return false;
            }

            if (b == a)
            {
                return true;
            }

            if (currentval < a)
            {
                currentval *= b;
                Console.WriteLine(b);
                IsPowerOfMethod(a, b);
            }

            if ((a/b).Equals(1))
            {
                IsTrue = true;
            }

            return IsTrue;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(IsPowerOfMethod(27, 3));
        }
    }
}
