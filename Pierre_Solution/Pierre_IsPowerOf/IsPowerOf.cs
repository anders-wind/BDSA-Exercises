﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierre_IsPowerOf
{
    class IsPowerOf
    {
        public static Boolean IsTrue;

        private static bool IsPowerOfMethod(int a, int b)
        {
            // YOUR CODE GOES HERE

            if (a % b != 0 || b <= 0)
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


            if ((a / b) > 1)
            {
                a = (a / b);
                IsTrue = false;
                IsPowerOfMethod(a, b);
            }

            if ((a / b).Equals(1))
            {
                IsTrue = true;
            }

            return IsTrue;
        }

        static void Main(string[] args)
        {
            Console.Out.WriteLine(IsPowerOfMethod(27, 3));
        }
    }
}
