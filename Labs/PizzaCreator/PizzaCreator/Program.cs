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
                Console.WriteLine("N: New Order");
                Console.WriteLine("M: Modify Order");
                Console.WriteLine("D: Display Order");
                Console.WriteLine("Q: Quit");

                string input = ValidatingInput();
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
            dummySizeOfPizza = PizzaSize();

            if (dummySizeOfPizza == pizzaSizeSmall)
                realSizeOfPizza = "Small";

            if (dummySizeOfPizza == pizzaSizeMedium)
                realSizeOfPizza = "Medium";

            if (dummySizeOfPizza == pizzaSizeLarge)
                realSizeOfPizza = "Large";

            PizzaMeatToppings();

        }

        private static bool PizzaSize()
        {
            while (true)
            {
                Console.WriteLine("Size of Pizza: One is required");
                Console.WriteLine("\t * S: Small ($5)");
                Console.WriteLine("\t * M: Medium ($6.25)");
                Console.WriteLine("\t * L: Large ($8.75)");

                string input = ValidatingInput();

                switch (input[0])
                {
                    case 's':
                    case 'S': { pizzaSizeSmall = true; return pizzaSizeSmall; }

                    case 'm':
                    case 'M': { pizzaSizeMedium = true; return pizzaSizeMedium; }

                    case 'l':
                    case 'L': { pizzaSizeLarge = true; return pizzaSizeLarge; }

                    default: Console.WriteLine("Please enter a valid input."); break;
                };
            };
        }

        private static void PizzaMeatToppings()
        { 
            Console.WriteLine("Do you want any meats on your pizza?");
            Console.WriteLine("'Y' for Yes or 'N' for No");

            string input = ValidatingInput();
            string confirmationInput = input.ToUpper();

            if (confirmationInput[0] == 'Y')
            {
                    while (true)
                    { 
                        Console.WriteLine("\n Your options are: (Note) for each topping it is an additional $0.75 ");
                        Console.WriteLine(" B: Bacon\n H: Ham\n P: Pepperoni\n S: Sausage ");

                        Console.WriteLine("The meat toppings you currently have selected are:\n");

                        if (meatToppings[0] == true)
                            Console.WriteLine("Bacon");

                        if (meatToppings[1] == true)
                            Console.WriteLine("Ham");

                        if (meatToppings[2] == true)
                            Console.WriteLine("Pepperoni");

                        if (meatToppings[3] == true)
                            Console.WriteLine("Sausage");

                        string meatInput = ValidatingInput();
                        switch (meatInput[0])
                        {
                            case 'b':
                            case 'B':
                                {
                                    if (meatToppings[0] == true)
                                    {
                                        meatToppings[0] = false;
                                    };

                                    if (meatToppings[0] == false)
                                    {
                                        meatToppings[0] = true;
                                    };
                                    break;
                                }

                            case 'h':
                            case 'H':
                                {
                                    if (meatToppings[1] == true)
                                    {
                                        meatToppings[1] = false;
                                    };

                                    if (meatToppings[1] == false)
                                    {
                                        meatToppings[1] = true;
                                    };

                                    break;
                                }

                            case 'p':
                            case 'P':
                                {
                                    if (meatToppings[2] == true)
                                    {
                                        meatToppings[2] = false;
                                    };

                                    if (meatToppings[2] == false)
                                    {
                                        meatToppings[2] = true;
                                    };

                                    break;
                                }

                            case 's':
                            case 'S':
                                {
                                    if (meatToppings[3] == true)
                                    {
                                        meatToppings[3] = false;
                                    };

                                    if (meatToppings[3] == false)
                                    {
                                        meatToppings[3] = true;
                                    };

                                    break;
                                }

                            default: Console.WriteLine("Please enter a valid input."); break;

                        }

                        Console.WriteLine("Would you like more meat toppings?");
                        Console.WriteLine("'Y' for Yes or 'N' for No");

                        string additionalMeatInput = ValidatingInput();
                        switch (additionalMeatInput[0])
                        {
                            case 'y':
                            case 'Y': break;

                            case 'n':
                            case 'N': return;

                            default: Console.WriteLine("Please enter a valid input"); break;
                        }
                    };
                    
     
            }

            if (confirmationInput[0] == 'N')
                return;

        }

    

        private static string ValidatingInput()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                    return input;

            };
        }

        static string realSizeOfPizza;

        static bool[] meatToppings = new bool[3];

        static bool dummySizeOfPizza;
        static bool pizzaSizeSmall;
        static bool pizzaSizeMedium;
        static bool pizzaSizeLarge;
    }
}
