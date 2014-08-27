using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wind_ReversePolishCalculator
{
    class ReversePolishCalculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine(calculate("5 1 2 + 4 * + 3 - 2"));
            Console.ReadKey();
        }

        static int calculate(String input)
        {
            if (input == null) return 0;

            input = input.Trim();

            if (input.Equals("")) return 0;

            var stack = new Stack<int>();

            while(input.Length > 0)
            {
                if (stack.Count > 1)
                {
                    String operation = input.Substring(0, 1);
                    if (operation.Equals("+"))
                    {
                        stack.Push(stack.Pop() + stack.Pop());
                        input = input.Substring(1).Trim();
                        continue;
                    }
                    else if (operation.Equals("-"))
                    {
                        stack.Push(-stack.Pop() + stack.Pop());
                        input = input.Substring(1).Trim();
                        continue;
                    }
                    else if (operation.Equals("*"))
                    {
                        stack.Push(stack.Pop() * stack.Pop());
                        input = input.Substring(1).Trim();
                        continue;
                    }
                    else if (operation.Equals("/"))
                    {
                        int bot = stack.Pop();
                        int top = stack.Pop();
                        stack.Push(top / bot);
                        input = input.Substring(1).Trim();
                        continue;
                    }
                }

                input = input + " ";
                int index = input.IndexOf(" ");

                try
                {
                    stack.Push(Convert.ToInt32(input.Substring(0, index)));
                }catch(FormatException ex)
                {
                    // if a char(non numeral or operational) is found then return 0.
                    return 0;
                }
                input = input.Substring(index).Trim();
            }
            if (stack.Count > 1) return 0;
            return stack.Pop();
        }
    }
}
