using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierre_ReversedPolishCalculator
{
    class ReversedPolishCalculator
    {
        static void Main(string[] args)
        {
            string rpce = "5 1 2 + 4 * + 3 -";

            Console.WriteLine(CalculateExpression(rpce));
            Console.ReadKey();
        }

        static int CalculateExpression(string rpce)
        {
            try
            {
                string[] rpceTokens = rpce.Split(' ');
                Stack<int> operands = new Stack<int>();
                int firstStackPop = 0;

                foreach (string token in rpceTokens)
                {
                    if (int.TryParse(token, out firstStackPop))
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
                                    firstStackPop = operands.Pop();
                                    operands.Push(operands.Pop() - firstStackPop);
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
                        }
                    }
                }
                return operands.Pop();
            }
            catch (Exception ex)
            {
                if(ex is NullReferenceException || ex is InvalidOperationException)
                {
                    return 0;
                }
                return 0;
            }
        }
    }
}
