using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AuthenticationBcrypt
{
    public class Utility
    {
        public static void GetMessageAlert(ConsoleColor color, string message1)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message1);
            Console.ResetColor();
        }

        public static void GetMessageAlert(ConsoleColor color, string message1, string message2)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message1);
            Console.Write(message2);
            Console.ResetColor();
        }


        public static string GetSubstring(string word)
        {
            return word.Substring(0, 2);
        }

        public static void GetTableFormat(string id, string firstname, string lastname, string username, string password)
        {


            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,-20}|{1,-20}|{2,-20}|{3,-20}|", "Id User", "Nama", "Username", "Password");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,-20}|{1,-20}|{2,-20}|{3,-20}|", id, $"{firstname} {lastname}", username, password);
            Console.WriteLine("---------------------------------------------------------------------");
        }

       

        public static void Loading()
        {
            Console.Write("Loading");
            for (int i = 0; i <= 5; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(400);
            }

        }

        public static string GetPasswordValidation(string stringInput, string msg)
        {
            var hasMiniMaxChars = new Regex(@".{8,12}");
            var hasNumber = new Regex(@"[0-9]+");

            bool isReapeatDialog = true;
            while (isReapeatDialog)
            {
                if (string.IsNullOrEmpty(stringInput) || string.IsNullOrWhiteSpace(stringInput))
                {
                    Utility.GetMessageAlert(ConsoleColor.Red, "input cannot be empty");
                    Utility.ClearTwoLinesAbove();
                    Console.Write(msg);
                    stringInput = Console.ReadLine();
                    isReapeatDialog = true;
                } 
                else if (!hasMiniMaxChars.IsMatch(stringInput))
                {
                    Utility.GetMessageAlert(ConsoleColor.Red, "Password should not be lesser than 8 or greater than 12 characters.");
                    Utility.ClearTwoLinesAbove();
                    Console.Write(msg);
                    stringInput = Console.ReadLine();
                    isReapeatDialog = true;
                }
                else if (!hasNumber.IsMatch(stringInput))
                {
                    Utility.GetMessageAlert(ConsoleColor.Red, "Password should contain at least one numeric value.");
                    Utility.ClearTwoLinesAbove();
                    Console.Write(msg);
                    stringInput = Console.ReadLine();
                    isReapeatDialog = true;
                }
                else
                {
                    isReapeatDialog = false;
                }
            }
            return stringInput;
        }



        public static string GetEmptyStringAlert(string stringInput, string msg)
        {
            while (string.IsNullOrEmpty(stringInput) || string.IsNullOrWhiteSpace(stringInput))
            {
                Utility.GetMessageAlert(ConsoleColor.Red, "input cannot be empty");
                Utility.ClearTwoLinesAbove();
                Console.Write(msg);
                stringInput = Console.ReadLine();
            }
            return stringInput;
        }

        public static void ClearTwoLinesAbove()
        {
            System.Threading.Thread.Sleep(1400);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            RemoveCurrentConsoleLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            RemoveCurrentConsoleLine();
        }

        public static void RemoveCurrentConsoleLine()
        {
            int currentCursorLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentCursorLine);
        }
    }
}
