﻿using System;
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
                Console.WriteLine("N: New Order");
                Console.WriteLine("M: Modify Order");
                Console.WriteLine("D: Display Order");
                Console.WriteLine("Q: Quit");

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
            sizeOfPizza = PizzaSize();
                            
        }

        private static bool PizzaSize()
        {
            while (true)
            {
                bool pizzaSizeSmall;
                bool pizzaSizeMedium;
                bool pizzaSizeLarge;

                Console.WriteLine("Size of Pizza: One is required");
                Console.WriteLine("\t * S: Small ($5)");
                Console.WriteLine("\t * M: Medium ($6.25)");
                Console.WriteLine("\t * L: Large ($8.75)");

                string input = ValidatingStrings();

                switch (input[0])
                {
                    case 's':
                    case 'S': { pizzaSizeSmall = true; return pizzaSizeSmall; }

                    case 'm':
                    case 'M': { pizzaSizeMedium = true; return pizzaSizeMedium; }

                    case 'l':
                    case 'L': { pizzaSizeLarge = true; return pizzaSizeLarge; }

                    default: Console.WriteLine("Please enter a valid value"); break;
                };
            };
        }

        private static string ValidatingStrings()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine("Please enter something into the command prompt:");
                Console.WriteLine("Size of Pizza: One is required");
                Console.WriteLine("\t * S: Small ($5)");
                Console.WriteLine("\t * M: Medium ($6.25)");
                Console.WriteLine("\t * L: Large ($8.75)");

            };
        }

        static bool sizeOfPizza;
    }
}
