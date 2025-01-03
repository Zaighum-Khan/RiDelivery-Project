using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiDelivery
{
    public class RegistrationCheckers
    {
        public static string userNameChecker()
        {
            Console.Write("\nPlease Enter Your User Name : ");
            string user = Console.ReadLine() ?? "";
            if (user.Length < 3)
            {
                Console.WriteLine("User Name must contain atleast 3 characters.");
                userNameChecker();
            }
            return user;
        }

        public static string restaurantNameChecker()
        {
            Console.Write("\nPlease Enter Your Restaurant's Name : ");
            string user = Console.ReadLine() ?? "";
            if (user.Length < 3)
            {
                Console.WriteLine("Restaurant's Name must contain atleast 3 characters.");
                userNameChecker();
            }
            return user;
        }

        public static string emailChecker()
        { 
                Console.Write("Please Enter Your E-mail : ");
                string mail = Console.ReadLine() ?? "";
                if (!mail.Contains("@") && !mail.Contains(".com"))
                {
                    Console.WriteLine("Invalid Email Address! Email must contain '@' and '.com'");
                    emailChecker();
                }
            return mail;
        }

        public static string passwordChecker()
        {
            Console.Write("Enter Password : ");
            string pass = Console.ReadLine() ?? "";
            if (pass.Length < 8)
            {
                Console.WriteLine("Password Should contains atleast 8 characters!! \nPlease Try again.");
                passwordChecker();
            }
            else
            {
            Console.Write("Confirm Password : ");
            string passConfirm = Console.ReadLine() ?? "";
            if (pass != passConfirm)
            {
                Console.Clear();
                Console.WriteLine("Password Does not match. Please Try Again!!");
                passwordChecker();
            }
            }
            return pass;
        }

        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }

        public static string numberChecker()
        {
            Console.Write("\nPlease enter your Contact Number : ");
            string number = Console.ReadLine() ?? "";
            
            if (number.Length != 11 || !IsDigitsOnly(number))
            {
                Console.WriteLine("Contact should only contain Numbers and length of 11 digits.\nTry Again !!");
                numberChecker();
            }

            return number;
        }

        public static string vehicleTypeChecker()
        {
            Console.Write("Please Enter Vehicle Type (bike/car): ");
            string type = Console.ReadLine().ToUpper();
            if ((type != "BIKE") && (type != "CAR"))
            {
                Console.WriteLine("Invalid Vehicle Type!!\nPlease Try Again.");
                return vehicleTypeChecker();
            }
            return type;
        }

    }
}