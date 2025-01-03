using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiDelivery
{
    public class RestaurantorShop
    {
        public static string whatBusiness()
        {
            Console.Clear();
            Console.WriteLine("What type of Business do you have?");
            Console.WriteLine("1. Restaurant");
            Console.WriteLine("2. Shop");
            Console.WriteLine("3. Back");
            Console.Write("Enter your choice : ");
            string choice = Console.ReadLine() ?? "";
            switch (choice)
            {
                case "1":
                    return "restaurant";
                    break;
                case "2":
                    return "shop";
                    break;
                case "3":
                    Menu.DisplayMenu();
                    return "";
                    break;
                default:
                    Console.WriteLine("Invalid Choice!");
                    return whatBusiness();
                    break;
            }
        }

    }
}