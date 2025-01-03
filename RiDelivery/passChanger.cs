using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiDelivery
{
    public class passChanger
    {
        public static void changePass(string filePath)
        {
            Console.Clear();
            Console.WriteLine("Change Password : ");
            Console.Write("Enter your User Name : ");
            string userName = Console.ReadLine() ?? "";
            string fileName = filePath.Contains(userName , StringComparison.OrdinalIgnoreCase) ? filePath : "Wrong UserName! Try Again"; 
            if (File.Exists(fileName))
            {
                Console.Write("Enter your Old Password : ");
                string oldPass = Console.ReadLine() ?? "";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts[1].Equals(oldPass))
                        {
                            Console.Write("Enter New Password : ");
                            string newPass = RegistrationCheckers.passwordChecker();
                            Console.Write("Re-Enter New Password : ");
                            string confirmPass = Console.ReadLine() ?? "";
                            while(true)
                            {
                            if (newPass.Equals(confirmPass))
                            {
                                string tempFile = Path.GetTempFileName();
                                using (StreamWriter sw = new StreamWriter(tempFile))
                                using (StreamReader sr1 = new StreamReader(fileName))
                                {
                                    string line1;
                                    while ((line1 = sr1.ReadLine()) != null)
                                    {
                                        string[] parts1 = line1.Split(',');
                                        if (parts1[1].Equals(oldPass))
                                        {
                                            sw.WriteLine($"{parts1[0]},{newPass},{parts1[2]},{parts1[3]},{parts1[4]},{parts1[5]}");
                                        }
                                        else
                                        {
                                            sw.WriteLine(line1);
                                        }
                                    }
                                }
                                File.Delete(fileName);
                                File.Move(tempFile, fileName);
                                Console.WriteLine("Password Changed Successfully!");
                                Thread.Sleep(1500);
                                Menu.LoginMenu();
                                break;
                            }
                            else if(!newPass.Equals(confirmPass))
                            {
                                Console.WriteLine("Passwords do not match!");
                                Thread.Sleep(1500);
                            }
                        }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Password!");
                            Thread.Sleep(1500);
                            changePass(filePath);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("User Name does not exist!");
                Thread.Sleep(1500);
                Menu.LoginMenu();
            }
        }
    }
}