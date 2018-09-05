using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart
{
    class Program
    {
        static void Main(string[] args)
        {
            var home = new Home();
            home.Display();
            Console.ReadKey();
        }
    }
}