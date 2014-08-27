using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wind_HelloWorld
{
    public class CommandLine
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Wind");
            Console.ReadKey();

            new CommandLine();
            Console.ReadKey();

            Console.WriteLine("\nFor loop");
            Console.WriteLine("Number of command line parameters = {0}", args.Length);
            for(int i = 0; i<args.Length ; i++)
            {
                Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }
            Console.ReadKey();

            Console.WriteLine("\nForeach");
            foreach (string s in args)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }

        public CommandLine()
        {
            writeHelloWind5Times();
        }

        private void writeHelloWind5Times()
        {
            for(int i = 0 ; i<5 ;i++)
            {
                Console.WriteLine("\nHello Wind");
            }
        }
    }
}
