using System;

namespace AuthenticationBcrypt
{
    public class Program
    {
        static void Main(string[] args)
        {
            //(DateTime.Now.ToShortDateString());

            Account account = new Account();
            bool backToMenu = true;
            bool isStay = true;
            do
            {
               
                Menu.GetMenuIntro();
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            CreateUser(isStay, account);
                            break;
                        case 2:
                            ShowUser(isStay, account);
                            break;
                        case 3:
                            SearchUser(isStay, account);
                            break;
                        case 4:
                            Login(isStay, account);
                            break;
                        case 5:
                            Console.WriteLine("Thank you");
                            backToMenu = false;
                            break;
                        default:
                            Utility.GetMessageAlert(ConsoleColor.Red, "Menu not available");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Utility.GetMessageAlert(ConsoleColor.Red, "Input is empty or wrong character");
                    Console.ReadKey();
                }
            } while (backToMenu);
        }

        public static void CreateUser(bool isStay, Account account)
        {
            while (isStay)
            {
                Console.Clear();
                account.AddUser();
                bool answerToStay = Menu.RepeatSubMenu(isStay);
                isStay = answerToStay;
            }
        }

        public static void ShowUser(bool isStay, Account account)
        {
            while (isStay)
            {
                Console.Clear();
                account.ShowUser();
                bool answerToStay = Menu.RepeatSubMenu(isStay);
                isStay = answerToStay;
            }
        }

        public static void SearchUser(bool isStay, Account account)
        {
            while (isStay)
            {
                Console.Clear();
                account.SearchUser();
                bool answerToStay = Menu.RepeatSubMenu(isStay);
                isStay = answerToStay;
            }
        }

        public static void Login(bool isStay, Account account)
        {
            while(isStay)
            {
                Console.Clear();
                account.LoginUser();
                bool answerToStay = Menu.RepeatSubMenu(isStay);
                isStay = answerToStay;
            }
        }

    }
}
