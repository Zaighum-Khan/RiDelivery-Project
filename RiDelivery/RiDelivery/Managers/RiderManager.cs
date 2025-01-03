
namespace RiDelivery
{
    public class RiderManager
    {

        
        public static void riderRegistration()
        {

            Console.Clear();
            while (true)
            {
                string vehicleType;

                Console.WriteLine("Personal Info :");
                string userName = RegistrationCheckers.userNameChecker();

                if(!Directory.Exists("Providers/Riders"))
                {
                    Directory.CreateDirectory("Providers/Riders");
                }

                string fName = $"Providers/Riders/{userName}.txt";
                string filepath = $"{fName}";

                if (!File.Exists(filepath))
                {
                    string email = RegistrationCheckers.emailChecker();

                    string phoneNumber = RegistrationCheckers.numberChecker();

                    Console.Write("Please enter Your Address : ");
                    string address = Console.ReadLine() ?? "";

                    Console.WriteLine("\nVehicle Info : ");
                    vehicleType = RegistrationCheckers.vehicleTypeChecker();

                    Console.Write("Please Enter Vehicle Number : ");
                    string vehicleNumber = Console.ReadLine() ?? "";

                    Console.Write("\nCreate Password :");
                    string password = RegistrationCheckers.passwordChecker();

                    using (StreamWriter sw = new StreamWriter(filepath, true))
                    {
                        sw.WriteLine($"{email},{password},{phoneNumber},{address},{vehicleType},{vehicleNumber}");
                    }
                    Console.WriteLine("\nYou are Registered Successfully !! Now login to continue.");
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

        public static void riderLogin()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("\nPlease Enter User Name : ");
                string fName = Console.ReadLine();
                string filepath = $"Providers/Riders/{fName}.txt";
                if (File.Exists(filepath))
                {
                    LoginCheckers.passLoginChecker(filepath);
                    RiderInterface.riderInterface(fName);
                    break;
                }
                else
                {
                    Console.WriteLine("UserName not Found !!\nPlease Try Again");
                }
            }
        }

    }
}