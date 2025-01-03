

namespace RiDelivery
{
    public static class Menu
    {

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.Write("1. Register \n2. Login \n3. Exit");
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine() ?? "";
            switch (choice)
            {
                case "1":
                    RegisterMenu();
                    break;
                case "2":
                    LoginMenu();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(1500);
                    DisplayMenu();
                    break;
            }
        }

        public static void RegisterMenu()
        {
            Console.Clear();
            Console.Write("1. Register as a User \n2. Register as a Rider\n3. Register as a Provider \n4. Exit \n5. Go Back");
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine() ?? "";
            switch (choice)
            {
                case "1":
                    UserManager.CustomerRegistration();
                    break;
                case "2":
                    RiderManager.riderRegistration();
                    break;
                case "3":
                    string returning = RestaurantorShop.whatBusiness();
                    if (returning == "restaurant")
                    {
                        RestaurantEnlisterManager.restaurantRegistration();
                    }
                    else if (returning == "shop")
                    {
                        ShopEnlisterManager.shopRegistration();
                    }
                    break;
                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                case "5":
                    DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(1500);
                    RegisterMenu();
                    break;
            }
        }

        public static void LoginMenu()
        {
            Console.Clear();
            Console.Write("1. Login as a User \n2. Login as a Rider \n3. Login as a Provider \n4. Exit \n5. Go Back");
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine() ?? "";
            switch (choice)
            {
                case "1":
                    UserManager.CustomerLogin();
                    break;
                case "2":
                    RiderManager.riderLogin();
                    break;
                case "3":
                    string returner = RestaurantorShop.whatBusiness();
                    if (returner == "restaurant")
                    {
                        RestaurantEnlisterManager.restaurantLogin();
                    }
                    else if (returner == "shop")
                    {
                        ShopEnlisterManager.shopLogin();
                    }
                    break;
                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                case "5":
                    DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(1500);
                    LoginMenu();
                    break;
            }
        }
    }
}