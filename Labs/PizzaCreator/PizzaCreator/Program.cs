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
            while (true)
            {
                Console.WriteLine("Size of Pizza: One is required\n");
                Console.WriteLine("\t* Small \"S\" ($5)\n");
                Console.WriteLine("\t* Medium \"M\" ($6.25)\n");
                Console.WriteLine("\t* Large \"L\"($8.75)\n");

                string pizzaSizeInput = Console.ReadLine();
                switch (pizzaSizeInput[0])
                {

                    case 's': 
                    case 'S': Console.WriteLine("Small"); break;
                                                          
                    case 'm':                             
                    case 'M': Console.WriteLine("Medium"); break;
                                                          
                    case 'l':                             
                    case 'L': Console.WriteLine("Large"); break;

                    default: Console.WriteLine("Invalid Input, please try to enter the given options again."); break;
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
