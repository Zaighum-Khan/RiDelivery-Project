using System.Globalization;
using System.IO;
namespace RiDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ur-PK");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("ur-PK");

            if(!Directory.Exists("Providers/ROwners"))
                {
                    Directory.CreateDirectory("Providers/ROwners");
                }

            if(!Directory.Exists("Providers/Riders"))
                {
                    Directory.CreateDirectory("Providers/Riders");
                }

            if(!Directory.Exists("Users"))
                {
                    Directory.CreateDirectory("Users");
                }

            if(!Directory.Exists("Providers/ROwners/Orders"))
            {
                Directory.CreateDirectory("Providers/ROwners/Orders");
            }
            
            if(!Directory.Exists("Users/ShopOrders"))
            {
                Directory.CreateDirectory("Users/ShopOrders");
            }

            if(!Directory.Exists("Providers/ROwners/Orders"))
            {
                Directory.CreateDirectory("Providers/ROwners/Orders");
            }

            if (!Directory.Exists("Users/Rides"))
            {
                Directory.CreateDirectory("Users/Rides");
            }

            if(!Directory.Exists("Users/Orders"))
            {
                Directory.CreateDirectory("Users/Orders");
            }

            if (!Directory.Exists("Providers/Riders/Rides"))
            {
                Directory.CreateDirectory("Providers/Riders/Rides");
            }

            if (!Directory.Exists("Providers/SOwners"))
            {
                        Directory.CreateDirectory("Providers/SOwners");
            }

            if (!Directory.Exists("Providers/SOwners/Orders"))
            {
                Directory.CreateDirectory("Providers/SOwners/Orders");
            }

            if (!Directory.Exists("Providers/Restaurants"))
            {
                Directory.CreateDirectory("Providers/Restaurants");
            }

            if (!Directory.Exists("Providers/Shops"))
            {
                Directory.CreateDirectory("Providers/Shops");
            }
            
            Menu.DisplayMenu();
        }
        
        
    }
}