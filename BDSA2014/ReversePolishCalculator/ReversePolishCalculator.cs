using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishCalculator
{
    /// <summary>
    /// The class takes a string as input, and if the string is in the format of a reverse Polish calculator expression, then it will calculate and return the result.
    /// Features
    ///     Can handle the operators: +, -, *, /, sqrt, cos, sin and pov (^)
    ///     Can handle negative numbers if written in the form -x
    ///     Tokens are separated by a whitespace.
    ///     If a "token" includes a letter then the token is ignored.
    /// 
    /// </summary>
    class ReversePolishCalculator
    {

        static void Main(string[] args)
        {
            String rpce = "";

            for (int i = 0; i < args.Length; i++)
            {
                rpce = rpce + args[i] + " ";
            }

            //string rpce = "5 1 2 + 4 * + 3 -";
            Console.WriteLine(CalculateExpression(rpce));
        }

        /// <summary>
        /// Calculates the input reverse calculator string expression. Can handle a number of faulties.
        /// </summary>
        /// <param name="rpce">A String in the Reverse Polish Calculator expression format</param>
        /// <returns>0 if faulty otherwise the result</returns>
        public static decimal CalculateExpression(string rpce)
        {
            try
            {
                string[] rpceTokens = rpce.ToLower().Split(' ');
                var operands = new Stack<decimal>();
                decimal firstStackPop = 0;

                foreach (string token in rpceTokens)
                {
                    if (decimal.TryParse(token, out firstStackPop))
                    {
                        operands.Push(firstStackPop);
                    }
                    else
                    {
                        switch (token)
                        {
                            case "+":
                                {
                                    operands.Push(operands.Pop() + operands.Pop());
                                    break;
                                }
                            case "-":
                                {
                                    operands.Push(-operands.Pop() + operands.Pop());
                                    break;
                                }
                            case "*":
                                {
                                    operands.Push(operands.Pop() * operands.Pop());
                                    break;
                                }
                            case "/":
                                {
                                    firstStackPop = operands.Pop();
                                    operands.Push(operands.Pop() / firstStackPop);
                                    break;
                                }
                            case "^":
                            case "pov":
                            {
                                firstStackPop = operands.Pop();
                                operands.Push((decimal)Math.Pow((double)operands.Pop(), (double)firstStackPop));
                                break;
                            }
                            case "sqrt":
                            {
                                operands.Push((decimal)Math.Sqrt((double)operands.Pop()));
                                break;
                            }
                            case "cos":
                            {
                                operands.Push((decimal)Math.Cos((double)operands.Pop()));
                                break;
                            }
                            case "sin":
                            {
                                operands.Push((decimal)Math.Sin((double)operands.Pop()));
                                break;
                            }
                        }
                    }
                }
                if (operands.Count == 1)
                {
                    return operands.Pop();
                }
                else
                {
                    Console.WriteLine("The stack is either empty or there are more than two tokens left in the stack");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Input caused an exception - uHazDumbzzssz");
                return 0;
            }
        }
    }
}
