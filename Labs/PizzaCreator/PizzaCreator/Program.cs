/*
 * ITSE 1430
 * Pizza Creator
 */
using System;

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
                    PizzaMeatToppings("Would you like to change your meat toppings?");
                    PizzaVegetableToppings("Would you like to change your vegetable toppings?");
                    PizzaSauce("Would you like to change the sauce on your pizza?");
                    PizzaCheese("Would you like to change the cheese on your pizza?");
                    PizzaDelivery("Would you like to change how you would like to get your order?");
                    TotalOrder();
                    DisplayOrder();
                    return;
                }
                if (input[0] == 'N')
                    return;
                else
                {
                    Console.WriteLine("Invalid Input");
                    ModifyOrder();
                };
            };

            if (existingOrder == false)
            {
                Console.WriteLine("You do not have an existing order: Returning to main menu.");
                return;
            };
        }

        private static void PizzaDelivery(string message)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine(message);
            Console.WriteLine("This is the method you currently have selected for how to acquire your order.");
            Console.WriteLine(pizzaDelivery);
            Console.WriteLine("'Y' for Yes or 'N' for No");

            string input = ValidatingInput();
            if (input[0] == 'Y')
            {
                while (true)
                {
                    Console.WriteLine("Do you want it delivered or to come pick it up?");
                    Console.WriteLine("\t * D: Delivery");
                    Console.WriteLine("\t * T: Take out");

                    string newInput = ValidatingInput();
                    switch (newInput[0])
                    {
                        case 'D': pizzaDelivery = "Delivery"; return;

                        case 'T': pizzaDelivery = "Take out"; return;

                        default: Console.WriteLine("Please enter a valid input"); break;
                    };
                };
            }
            if (input[0] == 'N')
                return;
            else
            {
                Console.WriteLine("Invalid Input");
                PizzaDelivery("Would you like to change how you would like to get your order?");
            };
        }

        private static void PizzaCheese(string message)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine(message);
            Console.WriteLine("This is the cheese you currently have selected.");
            Console.WriteLine(pizzaCheese);
            Console.WriteLine("'Y' for Yes or 'N' for No");

            string input = ValidatingInput();
            if (input[0] == 'Y')
            {
                while (true)
                {
                    Console.WriteLine("Cheese you would like on your pizza: One is required");
                    Console.WriteLine("\t * R: Regular ($0)");
                    Console.WriteLine("\t * E: Extra ($1.25)");

                    string newInput = ValidatingInput();
                    switch (newInput[0])
                    {
                        case 'R': pizzaCheese = "Regular"; return;

                        case 'E': pizzaCheese = "Extra"; return;

                        default: Console.WriteLine("Please enter a valid input"); break;
                    };
                };
            }
            if (input[0] == 'N')
                return;
            else
            {
                Console.WriteLine("Invalid Input");
                PizzaCheese("Would you like to change the cheese on your pizza?");
            };
        }

        private static void PizzaSauce(string message)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine(message);
            Console.WriteLine("This is the sauce you currently have selected.");
            Console.WriteLine(pizzaSauce);
            Console.WriteLine("'Y' for Yes or 'N' for No");

            string input = ValidatingInput();
            if (input[0] == 'Y')
            {
                while (true)
                {
                    Console.WriteLine("Sauce you would like on your pizza: One is required");
                    Console.WriteLine("\t * T: Traditional ($0)");
                    Console.WriteLine("\t * G: Garlic ($1)");
                    Console.WriteLine("\t * O: Oregano ($1)");

                    string newInput = ValidatingInput();
                    switch (newInput[0])
                    {
                        case 'T': pizzaSauce = "Traditional"; return;

                        case 'G': pizzaSauce = "Garlic"; return;

                        case 'O': pizzaSauce = "Oregano"; return;

                        default: Console.WriteLine("Please enter a valid input"); break;
                    };
                };
            }
            if (input[0] == 'N')
                return;
            else
            {
                Console.WriteLine("Invalid input");
                PizzaSauce("Would you like to change the sauce on your pizza?");
            };

        }

        private static void PizzaVegetableToppings(string message)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine(message);
            Console.WriteLine("These are the vegetable toppings you currently have selected.");
            if (!String.IsNullOrEmpty(oliveTopping))
                Console.WriteLine(oliveTopping);

            if (!String.IsNullOrEmpty(mushroomTopping))
                Console.WriteLine(mushroomTopping);

            if (!String.IsNullOrEmpty(onionTopping))
                Console.WriteLine(onionTopping);

            if (!String.IsNullOrEmpty(pepperTopping))
                Console.WriteLine(pepperTopping);

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
            }
            if (input[0] == 'N')
                return;
            else
            {
                Console.WriteLine("Invalid input");
                PizzaVegetableToppings("Would you like to change your vegetable toppings?");
            };
        }

        private static void PizzaMeatToppings(string message)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine(message);
            Console.WriteLine("These are the meat toppings you currently have selected.");
            if (!String.IsNullOrEmpty(baconTopping))
                Console.WriteLine(baconTopping);

            if (!String.IsNullOrEmpty(hamTopping))
                Console.WriteLine(hamTopping);

            if (!String.IsNullOrEmpty(pepperoniTopping))
                Console.WriteLine(pepperoniTopping);

            if (!String.IsNullOrEmpty(sausageTopping))
                Console.WriteLine(sausageTopping);

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
            else
            {
                Console.WriteLine("Invalid Input");
                PizzaMeatToppings("Would you like to change your meat toppings?");
            };

        }

        private static void PizzaSize(string message)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine(message);
            Console.WriteLine("This is the size of pizza you currently have selected.");
            Console.WriteLine($"{sizeOfPizza} Pizza");
            Console.WriteLine("'Y' for Yes or 'N' for No");

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
            }
            if (input[0] == 'N')
                return;
            else
            {
                Console.WriteLine("Invalid Input");
                PizzaSize("Would you like to change the size of your pizza?");
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
                    return;
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
                return;
            };
        }

        private static void TotalOrder()
        {
            if (sizeOfPizza == "Small")
            {
                oldSizeOfPizzaCost = 5.00;
                sizeOfPizzaCost = oldSizeOfPizzaCost.ToString();
            };

            if (sizeOfPizza == "Medium")
            {
                oldSizeOfPizzaCost = 6.25;
                sizeOfPizzaCost = oldSizeOfPizzaCost.ToString();
            };

            if (sizeOfPizza == "Large")
            {
                oldSizeOfPizzaCost = 8.75;
                sizeOfPizzaCost = oldSizeOfPizzaCost.ToString();
            };

            foreach(bool numberOfMeat in meatToppings)
            {
                if (numberOfMeat == true)
                {
                    oldMeatToppingCost = oldMeatToppingCost + 0.75;
                    meatToppingCost = oldMeatToppingCost.ToString();
                };

            };

            foreach(bool numberOfVegetable in vegetablesToppings)
            {
                if (numberOfVegetable == true)
                {
                    oldVegetableToppingCost = oldVegetableToppingCost + 0.75;
                    vegetableToppingCost = oldVegetableToppingCost.ToString();
                };
            };

            if (pizzaSauce == "Traditional")
            {
                oldPizzaSauceCost = 0;
                pizzaSauceCost = oldPizzaSauceCost.ToString();
            };

            if (pizzaSauce == "Garlic")
            {
                oldPizzaSauceCost = 1.00;
                pizzaSauceCost = oldPizzaSauceCost.ToString();
            };

            if (pizzaSauce == "Oregano")
            {
                oldPizzaSauceCost = 1.00;
                pizzaSauceCost = oldPizzaSauceCost.ToString();
            };

            if (pizzaCheese == "Regular")
            {
                oldPizzaCheeseCost = 0;
                pizzaCheeseCost = oldPizzaCheeseCost.ToString();
            };

            if (pizzaCheese == "Extra")
            {
                oldPizzaCheeseCost = 1.25;
                pizzaCheeseCost = oldPizzaCheeseCost.ToString();
            };

            if (pizzaDelivery == "Delivery")
            {
                oldPizzaDeliveryCost = 2.50;
                pizzaDeliveryCost = oldPizzaDeliveryCost.ToString();
            };

            if (pizzaDelivery == "Takeout")
            {
                oldPizzaDeliveryCost = 0;
                pizzaDeliveryCost = oldPizzaDeliveryCost.ToString();
            };

            result = oldSizeOfPizzaCost + oldMeatToppingCost + oldVegetableToppingCost + oldPizzaSauceCost + oldPizzaCheeseCost + oldPizzaDeliveryCost;
            total = result.ToString();
        }

        private static void DisplayOrder()
        {
            Console.WriteLine("********************************************");

            Console.WriteLine("Existing Order:");
            Console.WriteLine($"{sizeOfPizza} Pizza ${sizeOfPizzaCost}");
            Console.WriteLine(pizzaDelivery);

            Console.WriteLine($"\nMeats: ${meatToppingCost}");

            if (!String.IsNullOrEmpty(baconTopping))
                Console.WriteLine($"    {baconTopping}");

            if (!String.IsNullOrEmpty(hamTopping))
                Console.WriteLine($"    {hamTopping}");

            if (!String.IsNullOrEmpty(pepperoniTopping))
                Console.WriteLine($"    {pepperoniTopping}");

            if (!String.IsNullOrEmpty(sausageTopping))
                Console.WriteLine($"    {sausageTopping}");

            Console.WriteLine($"\nVegetables: ${vegetableToppingCost}");

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
            }
            if (input[0] == 'N')
                return;
            else
            {
                Console.WriteLine("Invalid input");
                PizzaVegetableToppings();
            };
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
            }
            if (input[0] == 'N')
                return;
            else
            {
                Console.WriteLine("Invalid Input");
                PizzaMeatToppings();
            };
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
        static string total = "0";
        static string pizzaDeliveryCost;
        static string sizeOfPizzaCost;
        static string pizzaSauceCost;
        static string pizzaCheeseCost;
        static string meatToppingCost = "0";
        static string vegetableToppingCost = "0";

        static bool existingOrder;
        static bool[] meatToppings = new bool[4];
        static bool[] vegetablesToppings = new bool[4];

        static double result;
        static double oldSizeOfPizzaCost;
        static double oldPizzaSauceCost;
        static double oldPizzaCheeseCost;
        static double oldPizzaDeliveryCost;
        static double oldMeatToppingCost;
        static double oldVegetableToppingCost;
    }
}
