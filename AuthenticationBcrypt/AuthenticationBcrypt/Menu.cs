using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBcrypt
{
    public class Menu
    {

        public static void GetMenuIntro()
        {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Login");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your option : ");
        }

       

        public static bool RepeatSubMenu(bool isStay)
        {
            bool isReapeatDialog = true;

            while (isReapeatDialog)
            {
                Console.Write("Back to main menu [y] or repeat this section [n] : ");
                string inputBack = Console.ReadLine().ToLower().Trim();
                switch (inputBack)
                {
                    case "y":
                        isStay = false;
                        isReapeatDialog = false;
                        break;
                    case "n":
                        isStay = true;
                        isReapeatDialog = false;
                        break;
                    default:
                        Utility.GetMessageAlert(ConsoleColor.Red, "input an invalid");
                        Console.ReadLine();
                        isReapeatDialog = true;
                        break;
                }
            }
            return isStay;
        }
    }
}
