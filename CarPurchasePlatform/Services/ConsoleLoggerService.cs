using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public class ConsoleLoggerService : ILoggerService
    {
        public void Write(string str)
        {
            Console.Write(str);
        }

        public void Write(StringBuilder str)
        {
            Write(str.ToString());
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public void WriteLine(StringBuilder str)
        {
            Console.WriteLine(str.ToString());
        }

        public void Dispose()
        {
            
        }

    }
}
