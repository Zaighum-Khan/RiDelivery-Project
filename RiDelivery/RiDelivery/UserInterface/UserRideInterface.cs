using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiDelivery
{
    public class UserRideInterface
    {
        public static void RideInterface(string uName)
        {
            string vehicleType = "";
            Console.Write("Enter Your Pick-Up Location : ");
            string pickUp = Console.ReadLine() ?? "";
            Console.Write("Enter Your Drop-Off Location : ");
            string dropOff = Console.ReadLine() ?? "";

            string fName = "Providers/Riders";
            string[] files = Directory.GetFiles(fName);
            Console.WriteLine("Files in directory:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                StreamReader sr1 = new StreamReader(file);
                {  
                    string line;
                    while ((line = sr1.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        Console.WriteLine($"\tVehicle Type: {parts[4]} \t\tVehicle Number: {parts[5]}");
                    }
                }
            }

            Console.WriteLine("Select a Rider : ");
            Console.Write("Enter Rider Name: ");
            string riderName = Console.ReadLine() ?? "";
            string riderFile = $"Providers/Riders/{riderName}.txt";
            if (File.Exists(riderFile))
            {
                using (StreamReader sr = new StreamReader(riderFile))
                {
                    string line;
                    Console.WriteLine($"\n{riderName}'s Info :");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        vehicleType = parts[4];
                        Console.WriteLine($"\tRider's Name : {riderName} \t\tContact : {parts[2]}");
                    }
                }

                Console.Write("Enter Distance (in km): ");
                double distance = double.Parse(Console.ReadLine() ?? "0");
                double ratePerKm = 0;
                if(vehicleType.Equals("Bike" , StringComparison.OrdinalIgnoreCase))
                {
                    ratePerKm = 10.0;
                }
                else if(vehicleType.Equals("Car" , StringComparison.OrdinalIgnoreCase))
                {
                    ratePerKm = 20.0;
                }
                double totalFare = distance * ratePerKm;

                Console.WriteLine($"\nTotal Fare: {totalFare:C}");
                RideHistoryforUser(uName, riderName, pickUp, dropOff, distance, totalFare);
                RideHistoryforRider(riderName, uName, pickUp, dropOff, distance, totalFare);
            }
            else
            {
                Console.WriteLine("Entered Rider is not available. Please select from the Given list only.");
            }
        }

        public static void RideHistoryforUser(string uName, string RiderName, string pickUp, string dropOff, double distance, double totalFare)
        {
            if (!Directory.Exists("Users/Rides"))
            {
                Directory.CreateDirectory("Users/Rides");
            }
            string fName = $"Users/Rides/{uName}_RideHistory.txt";
            using (StreamWriter sw = new StreamWriter(fName, true))
            {
                sw.WriteLine($"Ride Date: {DateTime.Now}");
                sw.WriteLine($"Rider's Name: {RiderName}");
                sw.WriteLine($"Pick-Up Location: {pickUp}");
                sw.WriteLine($"Drop-Off Location: {dropOff}");
                sw.WriteLine($"Distance: {distance} km");
                sw.WriteLine($"Total Fare: {totalFare:C}");
                sw.WriteLine(new String('-', 50));
            }
        }

        public static void RideHistoryforRider(string RiderName, string uName, string pickUp, string dropOff, double distance, double totalFare)
        {
            if (!Directory.Exists("Providers/Riders/Rides"))
            {
                Directory.CreateDirectory("Providers/Riders/Rides");
            }
            string fName = $"Providers/Riders/Rides/{RiderName}_RideHistory.txt";
            using (StreamWriter sw = new StreamWriter(fName, true))
            {
                sw.WriteLine($"Ride Date: {DateTime.Now}");
                sw.WriteLine($"Customer's Name: {uName}");
                sw.WriteLine($"Pick-Up Location: {pickUp}");
                sw.WriteLine($"Drop-Off Location: {dropOff}");
                sw.WriteLine($"Distance: {distance} km");
                sw.WriteLine($"Total Fare: {totalFare:C}");
                sw.WriteLine(new String('-', 50));
            }
        }
    }
}