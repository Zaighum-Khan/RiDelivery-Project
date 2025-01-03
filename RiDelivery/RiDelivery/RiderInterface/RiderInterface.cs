using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiDelivery
{
    public class RiderInterface
    {
        public static void riderInterface(string riderName)
        {
            Console.Clear();
            Console.WriteLine("Welcome to RiDelivery!");
            Console.WriteLine("1. Check Rides History \n2. Exit \n3. Go Back \n4. Change Password");
            Console.Write("Enter your choice : ");
            int choice = int.Parse(Console.ReadLine() ?? "0");
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Ride History : ");
                    rideHistory(riderName);
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
                    passChanger.changePass($"Providers/Riders/{riderName}.txt");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    Thread.Sleep(1000);
                    riderInterface(riderName);
                    break;
            }
        }

        public static void rideHistory(string riderName)
        {
            Console.Clear();
            string fileName = $"Providers/Riders/Rides/{riderName}_RideHistory.txt";
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
                riderInterface(riderName);
            }
            }
            else
            {
                Console.WriteLine("No Rides History!");
                Thread.Sleep(1500);
                riderInterface(riderName);
            }
        }

    }
}