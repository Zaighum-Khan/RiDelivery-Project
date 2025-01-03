
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
                if(File.Exists($"Users/{userName}.txt"))
                {
                    Console.WriteLine("User Name already Taken!\nEnter any other User Name.");
                    continue;
                }

                string phoneNumber = RegistrationCheckers.numberChecker();

                
                string fName = userName + ".txt";
                string filepath = $"Users/{fName}";

                string email = RegistrationCheckers.emailChecker();

                string password = RegistrationCheckers.passwordChecker();

                Console.Write("Please enter Your Address : ");
                string address = Console.ReadLine() ?? "Null";

                string age;
                while(true)
                {
                    Console.Write("Please Enter Your Age : ");
                    age = Console.ReadLine() ?? "0";
                    if(!RegistrationCheckers.IsDigitsOnly(age))
                    {
                        Console.WriteLine("Age must be a number.");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (!File.Exists(filepath))
                {
                    using (StreamWriter sw = new StreamWriter(filepath, true))
                    {
                        sw.WriteLine($"{email},{password},{phoneNumber},{userName},{address},{age}");
                    }
                    Console.WriteLine("\nYou are Registered Successfully !! Now Login to Continue.");
                    Thread.Sleep(1500);
                    Menu.LoginMenu();
                    break;
                }

            }
        }

    }
}