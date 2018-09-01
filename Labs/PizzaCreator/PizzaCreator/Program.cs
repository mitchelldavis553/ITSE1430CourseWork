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
            bool notQuit;
            do
            {
                notQuit = DisplayMenu();
            }
            while (notQuit);
        }

        private static bool DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("N)ew Order");
                Console.WriteLine("M)odify Order");
                Console.WriteLine("D)isplay Order");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();
                switch (input[0])
                {
                    case 'n':
                    case 'N': NewOrder(); return true;

                    case 'm':
                    //case 'M': ModifyOrder(); return true;

                    case 'd':
                    //case 'D': DisplayOrder(); return true;

                    case 'q':
                    case 'Q':; return false;

                    default: Console.WriteLine("Invalid Input, please try to enter the given options again."); return true;


                }
            }

        }

        private static void NewOrder()
        {
            bool pizzaSizeSmall;
            bool pizzaSizeMedium;
            bool pizzaSizeLarge;

            Console.WriteLine("Size of Pizza: (One is required)");
            Console.WriteLine("\t * S)mall ($5)");
            Console.WriteLine("\t * M)edium ($6.25)");
            Console.WriteLine("\t * L)arge ($8.75)");

            string inputPizzaSize = Console.ReadLine();
            switch (inputPizzaSize[0])
            {
                case 's':
                case 'S': pizzaSizeSmall = true; break;

                case 'm':
                case 'M': pizzaSizeMedium = true; break;

                case 'l':
                case 'L': pizzaSizeLarge = true; break;

                default: Console.WriteLine("Invalid Input, please try to enter the given options again"); break;               
            }

          
            

        }

            //private static void ModifyOrder()
            {
                Console.WriteLine("Modify Order");

            }
            //private static void DisplayOrder()
            {
                Console.WriteLine("Display Order");
            }




        }
    }
}
