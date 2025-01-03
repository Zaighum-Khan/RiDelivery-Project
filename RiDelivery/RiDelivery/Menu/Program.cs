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
            
            Menu.DisplayMenu();
        }
        
        
    }
}