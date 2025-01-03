using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiDelivery
{
    public class EnlisterInterface
    {
        public static void ROwnerInterface(string restaurantName)
        {
            Console.Clear();
            Console.WriteLine("Welcome to RiDelivery!");
            Console.WriteLine("1. Check Restaurant's Orders History \n2. Exit \n3. Go Back \n4. Edit Menu \n5. Change Password");
            Console.Write("Enter your choice : ");
            int choice = int.Parse(Console.ReadLine() ?? "0");
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Ride History : ");
                    ROrderHistory(restaurantName);
                    break;
                case 2:
                    Console.WriteLine("Exiting the program...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                case 3:
                    Menu.DisplayMenu();
                    break;
                case 4:
                    EditRMenu(restaurantName);
                    break;
                case 5:
                    passChanger.changePass($"Providers/ROwners/{restaurantName}.txt");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    Thread.Sleep(1000);
                    ROwnerInterface(restaurantName);
                    break;
            }
        }

        public static void EditRMenu(string restaurant)
        {
            Console.Clear();
            Console.WriteLine("1. Add Items to Menu \n2. Delete Items \n3. Go Back");
            Console.Write("Enter your choice : ");
            int choice = int.Parse(Console.ReadLine() ?? "0");
            switch (choice)
            {
                case 1:
                    addItemsInRMenu(restaurant);
                    break;
                case 2:
                    deleteItemsFromRMenu(restaurant);
                    break;
                case 3:
                    ROwnerInterface(restaurant);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    Thread.Sleep(1000);
                    EditRMenu(restaurant);
                    break;
            }
        }

        public static void addItemsInRMenu(string restaurantName)
        {
            Console.Clear();
            string fname = $"Providers/Restaurants/{restaurantName}.txt";
            using (StreamReader sr = new StreamReader(fname))
            {
                string line;
                Console.WriteLine($"\n{restaurantName}'s Menu :");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Console.WriteLine($"\tItem Name : {parts[0]} \t\tPrice : {(int.Parse(parts[1])):C}");
                }
            }
            char ans;
            Console.WriteLine("\nItems You want to Add : ");
            using (StreamWriter sw = new StreamWriter(fname, true))
            {
                do
                {
                    Console.Write("\nEnter Item Name : ");
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
                            Console.WriteLine("Invalid Price. Please try Again!!\n");
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
                Console.WriteLine("\nItems Added to the list !");
                Thread.Sleep(1500);
                ROwnerInterface(restaurantName);
            }

        }

        public static void deleteItemsFromRMenu(string restaurantName)
        {
            Console.Clear();
            string fname = $"Providers/Restaurants/{restaurantName}.txt";

            Console.WriteLine($"\n{restaurantName}'s Menu:");
            bool itemFound = false;

            using (StreamReader sr = new StreamReader(fname))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Console.WriteLine($"\tItem Name: {parts[0]} \t\tPrice: {(int.Parse(parts[1])):C}");
                }
            }

            Console.Write("\nEnter the name of the item you want to delete: ");
            string itemToDelete = Console.ReadLine();

            string tempFile = fname + ".txt";
            using (StreamReader sr = new StreamReader(fname))
            using (StreamWriter sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts[0].Equals(itemToDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        itemFound = true;
                        continue;
                    }
                    sw.WriteLine(line); 
                }
            }

            if (itemFound)
            {
                File.Delete(fname);
                File.Move(tempFile, fname);
                Console.WriteLine("\nItem successfully deleted from the menu!");
            }
            else
            {
                File.Delete(tempFile);
                Console.WriteLine("\nItem not found in the menu.");
                // Zaighum bhai.. Insert timer here and kick him back to the interface. 
                // Alrighty Sir!
            }
            Thread.Sleep(1500);
            ROwnerInterface(restaurantName);
        }

        public static void ROrderHistory(string restaurantName)
        {
            Console.Clear();
            string fileName = $"Providers/ROwners/Orders/{restaurantName}_OrderHistory.txt";
            if(File.Exists(fileName))
            {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string parts = sr.ReadToEnd();
                Console.WriteLine(parts);
            }

            Console.WriteLine("Press any key to go back...");
            if(Console.ReadKey() != null)
            {
                ROwnerInterface(restaurantName);
            }
            }
            else
            {
                Console.WriteLine("No Orders Yet!");
                Thread.Sleep(1500);
                ROwnerInterface(restaurantName);
            }
        }

        public static void SOwnerInterface(string shopName)
        {
            Console.Clear();
            Console.WriteLine("Welcome to RiDelivery!");
            Console.WriteLine("1. Check Store's Orders History \n2. Exit \n3. Go Back \n4. Edit Menu \n5. Change Password");
            Console.Write("Enter your choice : ");
            int choice = int.Parse(Console.ReadLine() ?? "0");
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Ride History : ");
                    SOrderHistory(shopName);
                    break;
                case 2:
                    Console.WriteLine("Exiting the program...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                case 3:
                    Menu.DisplayMenu();
                    break;
                case 4:
                    EditSMenu(shopName);
                    break;
                case 5:
                    passChanger.changePass($"Providers/SOwners/{shopName}.txt");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    Thread.Sleep(1000);
                    SOwnerInterface(shopName);
                    break;
            }
        }

        public static void EditSMenu(string shopName)
        {
            Console.Clear();
            Console.WriteLine("1. Add Items to Menu \n2. Delete Items \n3. Go Back");
            Console.Write("Enter your choice : ");
            int choice = int.Parse(Console.ReadLine() ?? "0");
            switch (choice)
            {
                case 1:
                    addItemsInSMenu(shopName);
                    break;
                case 2:
                    deleteItemsFromSMenu(shopName);
                    break;
                case 3:
                    SOwnerInterface(shopName);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    Thread.Sleep(1000);
                    EditSMenu(shopName);
                    break;
            }
        }

        public static void addItemsInSMenu(string shopName)
        {
            Console.Clear();
            string fname = $"Providers/Shops/{shopName}.txt";
            using (StreamReader sr = new StreamReader(fname))
            {
                string line;
                Console.WriteLine($"\n{shopName}'s Menu :");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Console.WriteLine($"\tItem Name : {parts[0]} \t\tPrice : {(int.Parse(parts[1])):C}");
                }
            }
            char ans;
            Console.WriteLine("\nItems You want to Add : ");
            using (StreamWriter sw = new StreamWriter(fname, true))
            {
                do
                {
                    Console.Write("\nEnter Item Name : ");
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
                            Console.WriteLine("Invalid Price. Please try Again!!\n");
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
                Console.WriteLine("\nItems Added to the list !");
                Thread.Sleep(1500);
                SOwnerInterface(shopName);
            }

        }

        public static void deleteItemsFromSMenu(string shopName)
        {
            Console.Clear();
            string fname = $"Providers/Shops/{shopName}.txt";

            Console.WriteLine($"\n{shopName}'s Menu:");
            bool itemFound = false;

            using (StreamReader sr = new StreamReader(fname))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Console.WriteLine($"\tItem Name: {parts[0]} \t\tPrice: {(int.Parse(parts[1])):C}");
                }
            }

            Console.Write("\nEnter the name of the item you want to delete: ");
            string itemToDelete = Console.ReadLine();

            string tempFile = fname + ".txt";
            using (StreamReader sr = new StreamReader(fname))
            using (StreamWriter sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts[0].Equals(itemToDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        itemFound = true;
                        continue;
                    }
                    sw.WriteLine(line); 
                }
            }

            if (itemFound)
            {
                File.Delete(fname);
                File.Move(tempFile, fname) ;
                Console.WriteLine("\nItem successfully deleted from the menu!");
            }
            else
            {
                File.Delete(tempFile);
                Console.WriteLine("\nItem not found in the menu.");
            }
            Thread.Sleep(1500);
            SOwnerInterface(shopName);
        }

        public static void SOrderHistory(string shopName)
        {
            Console.Clear();
            string fileName = $"Providers/SOwners/Orders/{shopName}_OrderHistory.txt";
            if(File.Exists(fileName))
            {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string parts = sr.ReadToEnd();
                Console.WriteLine(parts);
            }

            Console.WriteLine("Press any key to go back...");
            if(Console.ReadKey() != null)
            {
                SOwnerInterface(shopName);
            }
            }
            else
            {
                Console.WriteLine("No Orders Yet!");
                Thread.Sleep(1500);
                SOwnerInterface(shopName);
            }
        }

        
    }
}