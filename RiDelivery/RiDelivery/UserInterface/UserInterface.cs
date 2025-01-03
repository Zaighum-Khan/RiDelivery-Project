using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiDelivery
{
    public class UserInterface
    {
        public static void userInterface(string uName)
        {

        
        Console.Clear();
        Console.WriteLine("Welcome to RiDelivery!");
        Console.WriteLine("1. Ride \n2. Order \n3. Exit \n4. Go Back \n5. Check History \n6. Change Password");
        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine() ?? "";
            switch (choice)
            {
            case "1":
                UserRideInterface.RideInterface(uName);
                break;
            case "2":
                UserOrderInterface.OrderInterface(uName);
                break;
            case "3": 
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            case "4":
                Menu.LoginMenu();
                break;
            case "5":
            Console.Clear();
                Console.Write("1. Order History \n2. Ride History \n3. Go Back \n\nEnter your choice: ");
                string ch = Console.ReadLine() ?? "";
                switch (ch)
                {
                    case "1":
                        userOrderHistory(uName);
                        break;
                    case "2":
                        userRideHistory(uName);
                        break;
                    case "3":
                        userInterface(uName);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                break;
            case "6":
                passChanger.changePass($"Users/{uName}.txt");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                Thread.Sleep(1000);
                userInterface(uName);
                break;

            }
        }

        public static void userRideHistory(string userName)
        {
            Console.Clear();
            string fileName = $"Users/Rides/{userName}_RideHistory.txt";
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
                userInterface(userName);
            }
            }
            else
            {
                Console.WriteLine("No Rides History!");
                Thread.Sleep(1500);
                userInterface(userName);
            }
        }

        public static void userOrderHistory(string userName)
        {
            Console.Clear();
            string fileName = $"Users/Orders/{userName}_OrderHistory.txt";
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
                userInterface(userName);
            }
            }
            else
            {
                Console.WriteLine("No Orders History!");
                Thread.Sleep(1500);
                userInterface(userName);
            }
        }



        
    }
}