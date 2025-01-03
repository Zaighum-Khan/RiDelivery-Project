using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RiDelivery
{
    public class UserOrderInterface
    {
        public static void OrderInterface(string uName)
        {
            Console.Clear();
            Console.WriteLine("Restaurant or Grocery Store?");
            
            string choice = Console.ReadLine() ?? "";
            if(choice.Equals("Restaurant", StringComparison.OrdinalIgnoreCase))
            {

            string fName = "Providers/Restaurants";
            string[] files = Directory.GetFiles(fName);
            Console.WriteLine("Files in directory:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileNameWithoutExtension(file));
            }
            menuReader(uName);
            }
            else if (choice.Equals("Grocery Store", StringComparison.OrdinalIgnoreCase))
            {
                string fName = "Shops";
                string[] files = Directory.GetFiles($"Providers/{fName}");
                Console.WriteLine("Files in directory:");
                foreach (string file in files)
                {
                    Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                }
                groceryReader(uName);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        public static void menuReader(string uName)
        {
            Console.Write("\nPlease Enter the Restaurant Name : ");
            string restaurant = Console.ReadLine();
            string fname = "Providers/Restaurants/" + restaurant + ".txt";

            if (File.Exists(fname))
            {
                using (StreamReader sr = new StreamReader(fname))
                {
                    string line;
                    Console.WriteLine($"\n{restaurant}'s Menu :");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        Console.WriteLine($"\tItem Name : {parts[0]} \t\tPrice : {(int.Parse(parts[1])):C}");
                    }
                }
                customerReceiptRestauarant(restaurant , uName);
            }
            else
            {
                Console.WriteLine("Entered Restaurant is not available. Please select from the Given list only.");
                menuReader(uName);
            }
        }

        public static void groceryReader(string uName)
        {
            Console.Write("\nPlease Enter the Shop Name : ");
            string shopName = Console.ReadLine();
            string fname = "Providers/Shops/" + shopName + ".txt";

            if (File.Exists(fname))
            {
                using (StreamReader sr = new StreamReader(fname))
                {
                    string line;
                    Console.WriteLine($"\n{shopName}'s Grocery List :");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        Console.WriteLine($"\tItem Name : {parts[0]} \t\tPrice : {(int.Parse(parts[1])):C}");
                    }
                }
                customerReceiptGroceryShop(shopName , uName);
            }
            else
            {
                Console.WriteLine("Entered Shop is not available. Please select from the Given list only.");
                groceryReader(uName);
            }
        }

        public static void customerReceiptRestauarant(string restaurant , string uName)
        {
            string fname = "Providers/Restaurants/" + restaurant + ".txt";
            StreamReader sr = new StreamReader(fname);

            string ans;
            int totalBill = 0;
            var orderDetails = new List<(string itemName, int itemPrice, int quantity)>();

            Console.WriteLine("\nWhat do you want to buy:");
            string[] lines = File.ReadAllLines(fname);

            do
            {
                Console.Write("Enter item name: ");
                string itemName = Console.ReadLine();
                bool itemFound = false;

                // Search for the item in the file
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts[0].Trim().Equals(itemName, StringComparison.OrdinalIgnoreCase))
                    {
                        itemFound = true;

                        int quantity;
                        while (true)
                        {
                            Console.Write("Enter item quantity: ");
                            string checkQuantity = Console.ReadLine();
                            if (RegistrationCheckers.IsDigitsOnly(checkQuantity))
                            {
                                quantity = int.Parse(checkQuantity);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter digits only.");
                            }
                        }

                        int itemPrice = int.Parse(parts[1].Trim());
                        int bill = itemPrice * quantity;
                        totalBill += bill;

                        orderDetails.Add((itemName, itemPrice, quantity));

                        Console.WriteLine($"\nItem Name: {itemName}");
                        Console.WriteLine($"Item Quantity: {quantity}");
                        Console.WriteLine($"Item Price: {itemPrice}");
                        Console.WriteLine($"Current Bill: {bill:C}");
                        break;
                    }
                }

                if (!itemFound)
                {
                    Console.WriteLine("Item is not on the list. Please try again!");
                }

                while (true)
                {
                    Console.Write("\nDo you want to buy anything else? (y/n): ");
                    ans = Console.ReadLine();
                    if (ans.Equals("y", StringComparison.OrdinalIgnoreCase) || ans.Equals("n", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Y' or 'N' only!");
                    }
                }

            } while (ans.Equals("y", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nYour Total Bill: {totalBill:C}");
            Console.WriteLine($"Thank you for buying from {restaurant}.");

            RestaurantOrderHistoryForUser(uName, restaurant, orderDetails, totalBill);
            RestaurantOrderHistoryForROwner(uName, restaurant, orderDetails, totalBill);
        }

        public static void customerReceiptGroceryShop(string shopName , string uName)
        {
            string fname = "Providers/SOwners/" + shopName + ".txt";
            StreamReader sr = new StreamReader(fname);

            string ans;
            int totalBill = 0;
            var orderDetails = new List<(string itemName, int itemPrice, int quantity)>();

            Console.WriteLine("\nWhat do you want to buy:");
            string[] lines = File.ReadAllLines(fname);

            do
            {
                Console.Write("Enter item name: ");
                string itemName = Console.ReadLine();
                bool itemFound = false;

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts[0].Trim().Equals(itemName, StringComparison.OrdinalIgnoreCase))
                    {
                        itemFound = true;

                        int quantity;
                        while (true)
                        {
                            Console.Write("Enter item quantity: ");
                            string checkQuantity = Console.ReadLine();
                            if (RegistrationCheckers.IsDigitsOnly(checkQuantity))
                            {
                                quantity = int.Parse(checkQuantity);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter digits only.");
                            }
                        }

                        int itemPrice = int.Parse(parts[1].Trim());
                        int bill = itemPrice * quantity;
                        totalBill += bill;

                        orderDetails.Add((itemName, itemPrice, quantity));

                        Console.WriteLine($"\nItem Name: {itemName}");
                        Console.WriteLine($"Item Quantity: {quantity}");
                        Console.WriteLine($"Item Price: {itemPrice}");
                        Console.WriteLine($"Current Bill: {bill:C}");
                        break;
                    }
                }

                if (!itemFound)
                {
                    Console.WriteLine("Item is not on the list. Please try again!");
                }

                while (true)
                {
                    Console.Write("\nDo you want to buy anything else? (y/n): ");
                    ans = Console.ReadLine();
                    if (ans.Equals("y", StringComparison.OrdinalIgnoreCase) || ans.Equals("n", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Y' or 'N' only!");
                    }
                }

            } while (ans.Equals("y", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nYour Total Bill: {totalBill:C}");
            Console.WriteLine($"Thank you for buying from {shopName}.");

            ShopOrderHistoryForUser(uName, shopName, orderDetails, totalBill);
            ShopOrderHistoryForSOwner(uName, shopName, orderDetails, totalBill);
        }

        public static void RestaurantOrderHistoryForUser(string userName, string restaurant, List<(string itemName, int itemPrice, int quantity)> orderDetails, int totalBill)
        {
            if(!Directory.Exists("Users/Orders"))
            {
                Directory.CreateDirectory("Users/Orders");
            }
            string fName = $"Users/Orders/{userName}_OrderHistory.txt";
            using (StreamWriter sw = new StreamWriter(fName, true))
            {
                sw.WriteLine($"Order Date: {DateTime.Now}");
                sw.WriteLine($"Customer's Name: {userName}");
                sw.WriteLine($"Restaurant: {restaurant}");
                sw.WriteLine("Items Ordered:");
                foreach (var item in orderDetails)
                {
                    sw.WriteLine($"Item Name: {item.itemName}, Quantity: {item.quantity}, Price: {item.itemPrice:C}");
                }
                sw.WriteLine($"Total Bill: {totalBill:C}");
                sw.WriteLine(new String('-', 50));
            }
        }

        public static void RestaurantOrderHistoryForROwner(string userName, string restaurant, List<(string itemName, int itemPrice, int quantity)> orderDetails, int totalBill)
        {
            if(!Directory.Exists("Providers/ROwners/Orders"))
            {
                Directory.CreateDirectory("Providers/ROwners/Orders");
            }
            string fName = $"Providers/ROwners/Orders/{restaurant}_OrderHistory.txt";
            using (StreamWriter sw = new StreamWriter(fName, true))
            {
                sw.WriteLine($"Order Date: {DateTime.Now}");
                sw.WriteLine($"Customer's Name: {userName}");
                sw.WriteLine($"Restaurant: {restaurant}");
                sw.WriteLine("Items Ordered:");
                foreach (var item in orderDetails)
                {
                    sw.WriteLine($"Item Name: {item.itemName}, Quantity: {item.quantity}, Price: {item.itemPrice:C}");
                }
                sw.WriteLine($"Total Bill: {totalBill:C}");
                sw.WriteLine(new String('-', 50));
            }
        }

        public static void ShopOrderHistoryForUser(string userName, string shopName, List<(string itemName, int itemPrice, int quantity)> orderDetails, int totalBill)
        {
            if(!Directory.Exists("Users/ShopOrders"))
            {
                Directory.CreateDirectory("Users/ShopOrders");
            }
            string fName = $"Users/ShopOrders/{userName}_OrderHistory.txt";
            using (StreamWriter sw = new StreamWriter(fName, true))
            {
                sw.WriteLine($"Order Date: {DateTime.Now}");
                sw.WriteLine($"Customer's Name: {userName}");
                sw.WriteLine($"Restaurant: {shopName}");
                sw.WriteLine("Items Ordered:");
                foreach (var item in orderDetails)
                {
                    sw.WriteLine($"Item Name: {item.itemName}, Quantity: {item.quantity}, Price: {item.itemPrice:C}");
                }
                sw.WriteLine($"Total Bill: {totalBill:C}");
                sw.WriteLine(new String('-', 50));
            }
        }

        public static void ShopOrderHistoryForSOwner(string userName, string shopName, List<(string itemName, int itemPrice, int quantity)> orderDetails, int totalBill)
        {
            if(!Directory.Exists("Providers/ROwners/Orders"))
            {
                Directory.CreateDirectory("Providers/ROwners/Orders");
            }
            string fName = $"Providers/ROwners/Orders/{shopName}_OrderHistory.txt";
            using (StreamWriter sw = new StreamWriter(fName, true))
            {
                sw.WriteLine($"Order Date: {DateTime.Now}");
                sw.WriteLine($"Customer's Name: {userName}");
                sw.WriteLine($"Shop: {shopName}");
                sw.WriteLine("Items Ordered:");
                foreach (var item in orderDetails)
                {
                    sw.WriteLine($"Item Name: {item.itemName}, Quantity: {item.quantity}, Price: {item.itemPrice:C}");
                }
                sw.WriteLine($"Total Bill: {totalBill:C}");
                sw.WriteLine(new String('-', 50));
            }
        }
    }
}