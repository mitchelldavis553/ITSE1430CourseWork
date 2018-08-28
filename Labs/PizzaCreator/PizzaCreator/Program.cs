using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMenu();
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("N)ew Order");
            Console.WriteLine("M)odify Order");
            Console.WriteLine("D)isplay Order");
            Console.WriteLine("Q)uit");
        }
    }
}
