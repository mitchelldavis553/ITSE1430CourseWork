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
                Console.WriteLine($"\n\t Total: ${total}");

                string input = ValidatingInput();
                switch (input[0])
                {
                    case 'N': NewOrder(); return true;

                    case 'M': ModifyOrder(); return true;

                    case 'D': DisplayOrder(); return true;

                    case 'Q':; return false;

                    default: Console.WriteLine("Invalid Input, please try to enter the given options again."); return true;
                };
            };

        }

        private static void ModifyOrder()
        {
            if (existingOrder == true)
            {
                DisplayOrder();
                Console.WriteLine("Are you sure you want to change the order?");
                Console.WriteLine("'Y' for Yes or 'N' for No");
                string input = ValidatingInput();
                
                if (input[0] == 'Y')
                {
                    PizzaSize("Would you like to change the size of your pizza?");
                };

                if (input[0] == 'N')
                    return;
            };

            if (existingOrder == false)
            {
                Console.WriteLine("You do not have an existing order: Returning to main menu.");
                return;
            };
        }

        private static void PizzaSize(string message)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine(message);
            Console.WriteLine($"{sizeOfPizza} Pizza");

            string input = ValidatingInput();
            if (input[0] == 'Y')
            {
                while (true)
                {
                    Console.WriteLine("Size of Pizza: One is required");
                    Console.WriteLine("\t * S: Small ($5)");
                    Console.WriteLine("\t * M: Medium ($6.25)");
                    Console.WriteLine("\t * L: Large ($8.75)");

                    string newInput = ValidatingInput();
                    switch (newInput[0])
                    {
                        case 'S': sizeOfPizza = "Small"; return;

                        case 'M': sizeOfPizza = "Medium"; return;

                        case 'L': sizeOfPizza = "Large"; return;

                        default: Console.WriteLine("Please enter a valid input."); break;
                    };
                };
            };

            if (input[0] == 'N')
            {
                return;
            };
        }

        private static void NewOrder()
        {
            if (existingOrder == true)
            {
                Console.WriteLine("You already have an existing order.");
                Console.WriteLine("Are you sure you want to delete the old order and start the new one?");

                DisplayOrder();

                Console.WriteLine("'Y' for Yes or 'N' for No");
                string input = ValidatingInput();
                if (input[0] == 'Y')
                {
                    PizzaSize();
                    PizzaMeatToppings();
                    PizzaVegetableToppings();
                    PizzaPineapple();
                    PizzaSauce();
                    PizzaCheese();
                    PizzaDelivery();
                    TotalOrder();
                    DisplayOrder();

                    existingOrder = true;
                }
                else
                    return;

            }
            if (existingOrder == false)
            {
                PizzaSize();
                PizzaMeatToppings();
                PizzaVegetableToppings();
                PizzaPineapple();
                PizzaSauce();
                PizzaCheese();
                PizzaDelivery();
                TotalOrder();
                DisplayOrder();

                existingOrder = true;
            };
        }

        private static void TotalOrder()
        {
            if (sizeOfPizza == "Small")
                sizeOfPizzaCost = 5.00;

            if (sizeOfPizza == "Medium")
                sizeOfPizzaCost = 6.25;

            if (sizeOfPizza == "Large")
                sizeOfPizzaCost = 8.75;

            foreach(bool numberOfMeat in meatToppings)
            {
                if (numberOfMeat == true)
                    meatToppingCost = meatToppingCost + 0.75;
            };

            foreach(bool numberOfVegetable in vegetablesToppings)
            {
                if (numberOfVegetable == true)
                    vegetableToppingCost = vegetableToppingCost + 0.75;
            };

            if (pizzaSauce == "Traditional")
                pizzaSauceCost = 0;

            if (pizzaSauce == "Garlic")
                pizzaSauceCost = 1.00;

            if (pizzaSauce == "Oregano")
                pizzaSauceCost = 1.00;

            if (pizzaCheese == "Regular")
                pizzaCheeseCost = 0;

            if (pizzaCheese == "Extra")
                pizzaCheeseCost = 1.25;

            if (pizzaDelivery == "Delivery")
                pizzaDeliveryCost = 2.50;

            if (pizzaDelivery == "Takeout")
                pizzaDeliveryCost = 0;

            total = sizeOfPizzaCost + meatToppingCost + vegetableToppingCost + pizzaSauceCost + pizzaCheeseCost + pizzaDeliveryCost;
        }

        private static void DisplayOrder()
        {
            Console.WriteLine("********************************************");

            Console.WriteLine("Existing Order:");
            Console.WriteLine($"{sizeOfPizza} Pizza ${sizeOfPizzaCost}");
            Console.WriteLine(pizzaDelivery);

            Console.WriteLine($"\nMeats: ${meatToppingCost} ");

            if (!String.IsNullOrEmpty(baconTopping))
                Console.WriteLine($"    {baconTopping}");

            if (!String.IsNullOrEmpty(hamTopping))
                Console.WriteLine($"    {hamTopping}");

            if (!String.IsNullOrEmpty(pepperoniTopping))
                Console.WriteLine($"    {pepperoniTopping}");

            if (!String.IsNullOrEmpty(sausageTopping))
                Console.WriteLine($"    {sausageTopping}");

            Console.WriteLine($"\nVegetables: ${vegetableToppingCost} ");

            if (!String.IsNullOrEmpty(oliveTopping))
                Console.WriteLine($"    {oliveTopping}");

            if (!String.IsNullOrEmpty(mushroomTopping))
                Console.WriteLine($"    {mushroomTopping}");

            if (!String.IsNullOrEmpty(onionTopping))
                Console.WriteLine($"    {onionTopping}");

            if (!String.IsNullOrEmpty(pepperTopping))
                Console.WriteLine($"    {pepperTopping}");

            Console.WriteLine($"Sauce: ${pizzaSauceCost}");
            Console.WriteLine($"    {pizzaSauce}");

            Console.WriteLine($"Cheese: ${pizzaCheeseCost}");
            Console.WriteLine($"    {pizzaCheese}");

            Console.WriteLine("----------------");
            Console.WriteLine($"Total:\t ${total}");


            Console.WriteLine("********************************************");
        }

        private static void PizzaDelivery()
        {
            Console.WriteLine("********************************************");
            while (true)
            {
                Console.WriteLine("Do you want it delivered or to come pick it up?");
                Console.WriteLine("\t * D: Delivery");
                Console.WriteLine("\t * T: Take out");

                string input = ValidatingInput();
                switch (input[0])
                {
                    case 'D': pizzaDelivery = "Delivery"; return;

                    case 'T': pizzaDelivery = "Take out"; return;

                    default: Console.WriteLine("Please enter a valid input"); break;
                }; 
            };
        }

        private static void PizzaCheese()
        {
            Console.WriteLine("********************************************");
            while (true)
            {
                Console.WriteLine("Cheese you would like on your pizza: One is required");
                Console.WriteLine("\t * R: Regular ($0)");
                Console.WriteLine("\t * E: Extra ($1.25)");

                string input = ValidatingInput();
                switch (input[0])
                {
                    case 'R': pizzaCheese = "Regular"; return;

                    case 'E': pizzaCheese = "Extra"; return;

                    default: Console.WriteLine("Please enter a valid input"); break;
                };
            };
        }

        private static void PizzaPineapple()
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("Would you like Pineapple on your pizza? >:)");
            Console.WriteLine("'Y' for Yes or 'N' for No");

            string input = ValidatingInput();
            switch (input[0])
            {
                case 'Y': Console.WriteLine("\nToo bad\n"); return;

                case 'N': return;
            };
        }

        private static void PizzaSauce()
        {
            Console.WriteLine("********************************************");
            while (true)
            {
                Console.WriteLine("Sauce you would like on your pizza: One is required");
                Console.WriteLine("\t * T: Traditional ($0)");
                Console.WriteLine("\t * G: Garlic ($1)");
                Console.WriteLine("\t * O: Oregano ($1)");

                string input = ValidatingInput();
                switch (input[0])
                {
                    case 'T': pizzaSauce = "Traditional"; return;

                    case 'G': pizzaSauce = "Garlic"; return;

                    case 'O': pizzaSauce = "Oregano"; return;

                    default: Console.WriteLine("Please enter a valid input"); break;
                };
            };
        }

        private static void PizzaVegetableToppings()
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("Do you want any vegetables on your pizza?");
            Console.WriteLine("'Y' for Yes or 'N' for No");

            string input = ValidatingInput();

            if (input[0] == 'Y')
            {
                    while (true)
                    {
                        Console.WriteLine("\n Your options are: (Note for each topping it is an additional $0.50 ");
                        Console.WriteLine(" B: Black Olives\n M: Mushrooms\n O: Onionns\n P: Peppers");

                        string vegetableInput = ValidatingInput();
                        switch (vegetableInput[0])
                        {
                            case 'B': vegetablesToppings[0] = !vegetablesToppings[0]; break;

                            case 'M': vegetablesToppings[1] = !vegetablesToppings[1]; break;

                            case 'O': vegetablesToppings[2] = !vegetablesToppings[2]; break;

                            case 'P': vegetablesToppings[3] = !vegetablesToppings[3]; break;

                            default: Console.WriteLine("Please Enter a Valid Input"); break;
                        };

                        Console.WriteLine("The Vegetable toppings you currently have selected are:\n"); // Displaying Vegetables Selected

                        if (vegetablesToppings[0] == true)
                        {
                            Console.WriteLine("Black Olives\n");
                            oliveTopping = "Black Olives";
                        }
                        else
                             oliveTopping = "";

                        if (vegetablesToppings[1] == true)
                        {
                            Console.WriteLine("Mushrooms\n");
                            mushroomTopping = "Mushrooms";
                        }
                        else
                            mushroomTopping = "";

                        if (vegetablesToppings[2] == true)
                        {
                            Console.WriteLine("Onions\n");
                            onionTopping = "Onions";
                        }
                        else
                            onionTopping = "";

                        if (vegetablesToppings[3] == true)
                        {
                            Console.WriteLine("Peppers\n");
                            pepperTopping = "Peppers";
                        }
                        else
                            pepperTopping = "";

                        Console.WriteLine("Would you like more Vegetable toppings?");
                        Console.WriteLine("'Y' for Yes or 'N' for No");

                        string additionalVegetableInput = ValidatingInput();
                        switch (additionalVegetableInput[0])
                        {
                            case 'Y': break;

                            case 'N': return;
                        };
                    };
            };

            if (input[0] == 'N')
                return;
        }

        private static void PizzaSize()
        {
            Console.WriteLine("********************************************");
            while (true)
            {
                Console.WriteLine("Size of Pizza: One is required");
                Console.WriteLine("\t * S: Small ($5)");
                Console.WriteLine("\t * M: Medium ($6.25)");
                Console.WriteLine("\t * L: Large ($8.75)");

                string input = ValidatingInput();
                switch (input[0])
                {
                    case 'S':  sizeOfPizza = "Small"; return;  

                    case 'M':  sizeOfPizza = "Medium"; return;

                    case 'L':  sizeOfPizza = "Large"; return;

                    default: Console.WriteLine("Please enter a valid input."); break;
                };
            };
        }

        private static void PizzaMeatToppings()
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("Do you want any meats on your pizza?");
            Console.WriteLine("'Y' for Yes or 'N' for No");

            string input = ValidatingInput();

            if (input[0] == 'Y')
            {
                    while (true)
                    { 
                        Console.WriteLine("\n Your options are: (Note) for each topping it is an additional $0.75 ");
                        Console.WriteLine(" B: Bacon\n H: Ham\n P: Pepperoni\n S: Sausage ");

                        string meatInput = ValidatingInput();
                        switch (meatInput[0]) // Toggling Meats Selected
                        {
                            case 'B': meatToppings[0] = !meatToppings[0]; break;
;
                            case 'H': meatToppings[1] = !meatToppings[1]; break;
                              
                            case 'P': meatToppings[2] = !meatToppings[2]; break;

                            case 'S': meatToppings[3] = !meatToppings[3]; break;
                                
                            default: Console.WriteLine("Please enter a valid input."); break;
                        };

                        Console.WriteLine("The Meat toppings you currently have selected are:\n"); //Displaying Meats Selected

                        if (meatToppings[0] == true)
                        {
                            Console.WriteLine("Bacon");
                            baconTopping = "Bacon";
                        }
                        else
                            baconTopping = "";

                        if (meatToppings[1] == true)
                        {
                            Console.WriteLine("Ham");
                            hamTopping = "Ham";
                        }
                        else
                            hamTopping = "";

                        if (meatToppings[2] == true)
                        {
                            Console.WriteLine("Pepperoni");
                            pepperoniTopping = "Pepperoni";
                        }
                        else
                            pepperoniTopping = "";

                        if (meatToppings[3] == true)
                        {
                            Console.WriteLine("Sausage");
                            sausageTopping = "Sausage";
                        }
                        else
                            sausageTopping = "";

                        Console.WriteLine("Would you like more Meat toppings?");
                        Console.WriteLine("'Y' for Yes or 'N' for No");

                        string additionalMeatInput = ValidatingInput();
                        switch (additionalMeatInput[0])
                        {
                            case 'Y': break;

                            case 'N': return;

                            default: Console.WriteLine("Please enter a valid input"); break;
                        };
                    };
            };

            if (input[0] == 'N')
                return;
        }

        private static string ValidatingInput()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    string newInput = input.ToUpper();
                    return newInput;
                };

            };
        }

        static string sizeOfPizza;
        static string pizzaSauce;
        static string pizzaCheese;
        static string pizzaDelivery;
        static string baconTopping;
        static string hamTopping;
        static string pepperoniTopping;
        static string sausageTopping;
        static string oliveTopping;
        static string mushroomTopping;
        static string onionTopping;
        static string pepperTopping;

        static bool existingOrder;
        static bool[] meatToppings = new bool[4];
        static bool[] vegetablesToppings = new bool[4];

        static double total;
        static double sizeOfPizzaCost;
        static double pizzaSauceCost;
        static double pizzaCheeseCost;
        static double pizzaDeliveryCost;
        static double meatToppingCost;
        static double vegetableToppingCost;
    }
}
