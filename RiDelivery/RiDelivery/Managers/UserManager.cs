
namespace RiDelivery
{
    public class UserManager
    { 
        public static void CustomerLogin()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("\nPlease Enter User Name : ");
                string fName = Console.ReadLine() + ".txt";
                string filepath = $"Users/{fName}";
                string uName = Path.GetFileNameWithoutExtension(fName);
                if (File.Exists(filepath))
                {
                    LoginCheckers.passLoginChecker(filepath);
                    UserInterface.userInterface(uName);

                    break;
                }
                else
                {
                    Console.WriteLine("UserName not Found !!\nPlease Try Again");
                }
            }
        }

        public static void CustomerRegistration()
        {
            Console.Clear();
            while (true)
            {
                string userName = RegistrationCheckers.userNameChecker();

                string phoneNumber = RegistrationCheckers.numberChecker();

                if(!Directory.Exists("Users"))
                {
                    Directory.CreateDirectory("Users");
                }
                string fName = userName + ".txt";
                string filepath = $"Users/{fName}";

                string email = RegistrationCheckers.emailChecker();

                string password = RegistrationCheckers.passwordChecker();

                if (!File.Exists(filepath))
                {
                    using (StreamWriter sw = new StreamWriter(filepath, true))
                    {
                        sw.WriteLine($"{email},{password},{phoneNumber}");
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

    }
}