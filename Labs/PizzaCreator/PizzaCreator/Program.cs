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

            string input = Console.ReadLine();
            switch (input [0])
            {

                case 'N': NewOrder(); break;
                case 'M': ModifyOrder(); break;
                case 'D': DisplayOrder(); break;
                case 'Q':; break;

                default: Console.WriteLine("Invalid Input, please try to enter the options again."); break;


            }

        }

        private static void NewOrder()
        {
            Console.WriteLine("VOID");
        }

         private static void ModifyOrder()
        {
            throw new NotImplementedException();

        }private static void DisplayOrder()
        {
            throw new NotImplementedException();
        }

       

        
    }
}
