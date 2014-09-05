using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blundell_ReversePolishCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReverseCalculate("5 5 + 6 * 7 4 - /"));
        }

        private static int ReverseCalculate(String rpn)
        {
            if (rpn == null) //checks for valid input(including whitepaces)
            {
                return 0;
            }

            rpn = rpn.Trim(); //Removes leading and trailing whitespaces

            if (rpn == "") //Checks to see if input consisted solely on whitespaces
            {
                return 0;
            }

            var stack = new Stack<int>();

            while (rpn.Length > 0)
            {
                if (stack.Count > 1)
                {
                    String input = rpn.Substring(0, 1);

                    if (input.Equals("-"))
                    {
                        int subtrahend = stack.Pop();
                        int minuend = stack.Pop();
                        stack.Push(minuend - subtrahend);
                        rpn = rpn.Substring(1).Trim();
                        continue;
                    }

                    else if (input.Equals("+"))
                    {
                        int addend = stack.Pop();
                        int augend = stack.Pop();
                        stack.Push(augend + addend);
                        rpn = rpn.Substring(1).Trim();
                        continue;
                    }

                    else if (input.Equals("/"))
                    {
                        int divisor = stack.Pop();
                        int dividend = stack.Pop();
                        stack.Push(dividend / divisor);
                        rpn = rpn.Substring(1).Trim();
                        continue;
                    }

                    else if (input.Equals("*"))
                    {
                        int multiplier = stack.Pop();
                        int multiplicand = stack.Pop();
                        stack.Push(multiplicand * multiplier);
                        rpn = rpn.Substring(1).Trim();
                        continue;
                    }
                    
                }


                //SPØRG DOCTOR SHOTS

                rpn = rpn + " ";
                int index = rpn.IndexOf(" ");

                try
                {
                    stack.Push(Convert.ToInt32(rpn.Substring(0, index)));
                }
                catch (FormatException ex)
                {
                    // if a char(non numeral or operational) is found then return 0.
                    return 0;
                }
                rpn = rpn.Substring(index).Trim();

                //SPØRG DOCTOR SHOTS


            }

            if (stack.Count > 1)
                {
                    return 0;
                }
                return stack.Pop();

        }
    }
}
