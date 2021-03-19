using ShopWithProducts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWithProducts.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Write(string input)
        {
            System.Console.WriteLine(input);
        }

        public string Read()
        {
            return System.Console.ReadLine();
        }
    }
}
