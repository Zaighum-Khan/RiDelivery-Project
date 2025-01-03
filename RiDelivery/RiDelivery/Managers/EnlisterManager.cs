
namespace RiDelivery
{
    public class RestaurantEnlisterManager
    {
    
        public static void restaurantRegistration()
        {
            Console.Clear();
            while (true)
            {
                
                Console.WriteLine("Personal Info :");
                string userName = RegistrationCheckers.userNameChecker();
                string restaurantName = RegistrationCheckers.restaurantNameChecker();
                string fName = restaurantName + ".txt";
                if(!Directory.Exists("Providers/ROwners"))
                {
                    Directory.CreateDirectory("Providers/ROwners");
                }
                string filepath = $"Providers/ROwners/{fName}";
                if (!File.Exists(filepath))
                {
                    string email = RegistrationCheckers.emailChecker();
                    string phoneNumber = RegistrationCheckers.numberChecker();
                    Console.Write("Please enter Your Address : ");
                    string address = Console.ReadLine() ?? "";

                    // we need to make a separate directory for restaurant names.
                    menuWriter($"Providers/Restaurants/{fName}");

                    Console.WriteLine("\nCreate Password :");
                    string password = RegistrationCheckers.passwordChecker();


                    using (StreamWriter sw = new StreamWriter(filepath, true))
                    {
                        sw.WriteLine($"{email},{password},{userName},{phoneNumber},{address},{restaurantName}");
                    }
                    Console.WriteLine("\nYou are Registered Successfully !! Now Login to Continue.");
                    Thread.Sleep(1500);
                    Menu.LoginMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("User Name already Taken!\nEnter any other User Name.");
                }
            }
        }

        public static void restaurantLogin()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("\nPlease Enter Restaurant Name : ");
                string fName = Console.ReadLine();
                string filepath = $"Providers/ROwners/{fName}.txt";
                if (File.Exists(filepath))
                {
                    LoginCheckers.passLoginChecker(filepath);
                    EnlisterInterface.ROwnerInterface(fName);
                    break;
                }
                else
                {
                    Console.WriteLine("UserName not Found !!\nPlease Try Again");
                }
            }
        }

        public static void menuWriter(string fname)
        {
            char ans;
            Console.WriteLine("\nAvailable Food items : ");
            using (StreamWriter sw = new StreamWriter(fname, true))
            {
                do
                {
                    Console.Write("\nEnter the Item Name : ");
                    string itemName = Console.ReadLine();
                    
                    while (true)
                    {
                        Console.Write("Enter Item Price : ");
                        string price = Console.ReadLine();
                        if (RegistrationCheckers.IsDigitsOnly(price))
                        {
                            sw.WriteLine($"{itemName},{price}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Price should be in digits only!!\n");
                        }
                    }

                    while (true)
                    {
                        Console.Write("\nAre there any more items ? (y/n) : ");
                        ans = Convert.ToChar(Console.ReadLine().ToLower());
                        if (ans == 'y' || ans == 'n')
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter 'Y' or 'N' only !");
                        }
                    }
                }
                while (ans == 'y');
            }
        }
}

        public class ShopEnlisterManager
        {
            public static void shopRegistration()
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Personal Info :");
                    string userName = RegistrationCheckers.userNameChecker();
                    Console.Write("Enter Your Shop Name : ");
                    string shopName = Console.ReadLine() ?? "";
                    string fName = shopName + ".txt";
                    if (!Directory.Exists("Providers/SOwners"))
                    {
                        Directory.CreateDirectory("Providers/SOwners");
                    }
                    string filepath = $"Providers/SOwners/{fName}";
                    if (!File.Exists(filepath))
                    {
                        string email = RegistrationCheckers.emailChecker();
                        string phoneNumber = RegistrationCheckers.numberChecker();
                        Console.Write("Please enter Your Address : ");
                        string address = Console.ReadLine() ?? "";


                        groceryWriter($"Providers/Shops/{fName}");

                        Console.Write("\nCreate Password :");
                        string password = RegistrationCheckers.passwordChecker();
                        using (StreamWriter sw = new StreamWriter(filepath, true))
                    {
                        sw.WriteLine($"{email},{password},{userName},{phoneNumber},{address},{shopName}");
                    }
                    Console.WriteLine("\nYou are Registered Successfully !! Now Login to Continue.");
                    Thread.Sleep(1500);
                    Menu.LoginMenu();
                    break;

                    }
                }
            }

            public static void shopLogin()
            {
                Console.Clear();
                while (true)
                {
                    Console.Write("\nPlease Enter Shop Name : ");
                    string fName = Console.ReadLine();
                    string filepath = $"Providers/SOwners/{fName}.txt";
                    if (File.Exists(filepath))
                    {
                        LoginCheckers.passLoginChecker(filepath);
                        EnlisterInterface.SOwnerInterface(fName);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("UserName not Found !!\nPlease Try Again");
                    }
                }
            }

            public static void groceryWriter(string fname)
        {
            char ans;
            Console.WriteLine("\nAvailable Food items : ");
            using (StreamWriter sw = new StreamWriter(fname, true))
            {
                do
                {
                    Console.Write("\nEnter the Item Name : ");
                    string itemName = Console.ReadLine();
                    
                    while (true)
                    {
                        Console.Write("Enter Item Price : ");
                        string price = Console.ReadLine();
                        if (RegistrationCheckers.IsDigitsOnly(price))
                        {
                            sw.WriteLine($"{itemName},{price}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Price should be in digits only!!\n");
                        }
                    }

                    while (true)
                    {
                        Console.Write("\nAre there any more items ? (y/n) : ");
                        ans = Convert.ToChar(Console.ReadLine().ToLower());
                        if (ans == 'y' || ans == 'n')
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter 'Y' or 'N' only !");
                        }
                    }
                }
                while (ans == 'y');
            }
        }
        }

    }
    
