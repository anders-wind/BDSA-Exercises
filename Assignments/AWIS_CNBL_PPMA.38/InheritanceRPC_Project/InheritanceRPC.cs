using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceRPC_Project
{
    /// <summary>
    /// The class takes a string as input, and if the string is in the format of a reverse Polish calculator expression, then it will calculate and return the result.
    /// Features
    ///     Can handle the operators: +, -, *, /, sqrt, cos, sin, abs and pow (^)
    ///     Can handle negative numbers if written in the form -x
    ///     Can handle doubles if written in the form x,x
    ///     Tokens are separated by a whitespace.
    ///     If the input is invalid an exception is thrown.
    /// The class uses a dictionary<string, IOperation>  to handle the operations. To add an operation simply add it to the dictionary.
    /// The class currently has IOperation classes for unary and binary operations but tienary and so on can be added by creating an inner class which implements the IOperation interface.s
    /// </summary>
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

        /// <summary>
        /// Constructor which sets up the class.
        /// </summary>
        public InheritanceRPC()
        {
            operations = new Dictionary<string, IOperation>();
            addOperations();
        }

        /// <summary>
        /// A method that adds the supported operations this RPC can handle.
        /// </summary>
        private void addOperations()
        {
            operations.Add("+", new BinaryOperation((x, y) => x + y));
            operations.Add("-", new BinaryOperation((x, y) => x - y));
            operations.Add("*", new BinaryOperation((x, y) => x * y));
            operations.Add("/", new BinaryOperation((x, y) => x / y));
            operations.Add("pow", new BinaryOperation((x, y) => Math.Pow(x, y)));
            operations.Add("^", new BinaryOperation((x, y) => Math.Pow(x, y)));
            operations.Add("sqrt", new UnaryOperation((x) => Math.Sqrt(x)));
            operations.Add("abs", new UnaryOperation((x) => Math.Abs(x)));
            operations.Add("sin", new UnaryOperation((x) => Math.Sin(x)));
            operations.Add("cos", new UnaryOperation((x) => Math.Cos(x)));

        }

        /// <summary>
        /// Calculates the input reverse calculator string expression. Throws exceptions if the input is not in the RPC format.
        /// </summary>
        /// <param name="rpce">A String in the Reverse Polish Calculator expression format</param>
        /// <returns>0 if input is null or empty, otherwise returns the result</returns>
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
    /// <summary>
    /// An interface which has an execute method which can take doubles as parametres.
    /// </summary>
    public interface IOperation
    {
        double Execute(double arg1, params double[] argn);
    }

    /// <summary>
    /// An operation class which extends the IOperation interface, and therefore has an execute method which takes doubles as parametre. 
    /// The class is meant to handle binary operations (operations with 2 doubles as input).
    /// </summary>
    public class BinaryOperation : IOperation
    {
        private Func<double, double, double> operation;
        /// <summary>
        /// The constructor of the operation, which is used to give the class the function which it will use in the execute method.
        /// </summary>
        /// <param name="operation">The operation wanted as a function(2 inputs 1 output)</param>
        public BinaryOperation(Func<double, double, double> operation)
        {
            this.operation = operation;
        }

        /// <summary>
        /// The Execute method which will use the operation field of the class to calculate the output given the 2 input doubles.
        /// </summary>
        /// <param name="arg1">The first double given</param>
        /// <param name="argn">A number of doubles in an array</param>
        /// <returns>The result of the operation field given arg1 and argn[0]</returns>
        public double Execute(double arg1, params double[] argn)
        {
            return operation(arg1, argn[0]);
        }
    }

    /// <summary>
    /// An operation class which extends the IOperation interface, and therefore has an execute method which takes doubles as parametre. 
    /// The class is meant to handle unary operations (operations with 1 double as input).
    /// </summary>
    public class UnaryOperation : IOperation
    {
        private Func<double, double> operation;
        /// <summary>
        /// The constructor of the operation, which is used to give the class the function which it will use in the execute method.
        /// </summary>
        /// <param name="operation">The operation wanted as a function(1 input 1 output)</param>
        public UnaryOperation(Func<double, double> operation)
        {
            this.operation = operation;
        }

        /// <summary>
        /// The Execute method which will use the operation field of the class to calculate the output given the input double.
        /// </summary>
        /// <param name="arg1">The first double given</param>
        /// <param name="argn">A number of doubles in an array</param>
        /// <returns>The result of the operation field given arg1</returns>
        public double Execute(double arg1, params double[] argn)
        {
            return operation(arg1);
        }
    }
}
