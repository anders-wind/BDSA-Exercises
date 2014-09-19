using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceRPC_Project
{
    class InheritanceRPC
    {
        private Dictionary<string, IOperation> operations;

        static void Main(string[] args)
        {
            String rpce = "";

            for (int i = 0; i < args.Length; i++)
            {
                rpce = rpce + args[i] + " ";
            }

            InheritanceRPC iRPC = new InheritanceRPC();
            rpce = "5 1 2 + 4 * + 3 -";
            Console.WriteLine("Input: " + rpce + "\nThe answer is = " + iRPC.CalculateExpression(rpce));
        }

        public InheritanceRPC()
        {
            operations = new Dictionary<string, IOperation>();
            addOperations();
        }

        private void addOperations()
        {
            operations.Add("+", new BinaryOperation((x, y) => x + y));
            operations.Add("-", new BinaryOperation((x, y) => x - y));
            operations.Add("*", new BinaryOperation((x, y) => x * y));
            operations.Add("/", new BinaryOperation((x, y) => x / y));
            operations.Add("pow", new BinaryOperation((x, y) => Math.Pow(x,y)));
            operations.Add("^", new BinaryOperation((x, y) => Math.Pow(x, y)));
            operations.Add("sqrt", new UnaryOperation((x) => Math.Sqrt(x)));
            operations.Add("abs", new UnaryOperation((x) => Math.Abs(x)));
            operations.Add("sin", new UnaryOperation((x) => Math.Sin(x)));
            operations.Add("cos", new UnaryOperation((x) => Math.Cos(x)));

        }

        /// <summary>
        /// Calculates the input reverse calculator string expression. Can handle a number of faulties.
        /// </summary>
        /// <param name="rpce">A String in the Reverse Polish Calculator expression format</param>
        /// <returns>0 if faulty otherwise the result</returns>
        public double CalculateExpression(string rpce)
        {
            if (rpce == null || rpce.Trim().Equals(""))
            {
                return 0;
            }
            string[] rpceTokens = rpce.ToLower().Split(' ');
            var operands = new Stack<double>();
            double firstStackPop = 0.0;
                foreach (string token in rpceTokens)
                {
                    if (double.TryParse(token, out firstStackPop))
                    {
                        operands.Push(firstStackPop);
                    }
                    else if (operations.ContainsKey(token))
                    {
                        if (operations[token] is UnaryOperation)
                        {
                            operands.Push(operations[token].Execute(operands.Pop()));
                        }
                        else if (operations[token] is BinaryOperation)
                        {
                            var v2 = operands.Pop();
                            var v1 = operands.Pop();
                            operands.Push(operations[token].Execute(v1, v2));
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                if (operands.Count == 1)
                {
                    return operands.Pop();
                }
            throw new Exception();
        }
    }
    public interface IOperation
    {
        double Execute(double arg1, params double[] argn);
    }

    public class BinaryOperation : IOperation
    {
        private Func<double, double, double> operation;
        public BinaryOperation(Func<double, double, double> operation)
        {
            this.operation = operation;
        }

        public double Execute(double arg1, params double[] argn)
        {
            return operation(arg1, argn[0]);
        }
    }

    public class UnaryOperation : IOperation
    {
        private Func<double, double> operation;
        public UnaryOperation(Func<double, double> operation)
        {
            this.operation = operation;
        }

        public double Execute(double arg1, params double[] argn)
        {
            return operation(arg1);
        }
    }
}
