using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBcrypt
{
    public class Account
    {
        public List<User> _user { get; set; } = new List<User>();

        private void GetAllData(List<User> users)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,-3}|{1,-8}|{2,-18}|{3,-15}|{4,-63}|", "No", "Id User", "Nama", "Username", "Password");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            int no = 1;
            foreach (var user in users)
            {
                Console.WriteLine("|{0,-3}|{1,-8}|{2,-18}|{3,-15}|{4,-63}|", no, user.IdUser, $"{user.FirstName} {user.LastName}" +
                    $"", user.Username, user.Password);
                no++;
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        }

        public void AddUser()
        {
            string preffixId = "usr";
            Console.Write("Id User      : usr-");
            string idUser = Utility.GetEmptyStringAlert(Console.ReadLine().ToLower().Trim(), "Id User      : usr-");
            string newIdUser = string.Concat(preffixId,idUser);

            Console.Write("Firstname    : ");
            string firstname = Utility.GetEmptyStringAlert(Console.ReadLine().ToLower().Trim(), "Firstname    : ");
            
            Console.Write("Lastname     : ");
            string lastname = Utility.GetEmptyStringAlert(Console.ReadLine().ToLower().Trim(), "Lastname     : ");

            Console.Write("Password     : ");
            string password = Utility.GetPasswordValidation(Console.ReadLine().ToLower().Trim(), "Password     : ");

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            string generate = DateTime.Now.ToString("ddss");
            string username = $"{Utility.GetSubstring(firstname)}{Utility.GetSubstring(lastname)}{generate}";
            var newUser = new User(newIdUser, firstname, lastname, username, passwordHash);
            _user.Add(newUser);
            Utility.GetMessageAlert(ConsoleColor.Green, "Record has been added");
        }

        public void ShowUser()
        {
            Console.WriteLine("List User");
            int userLength = _user.Count;
            if (userLength != 0)
            {
                Console.WriteLine("Amount of data : {0}", userLength);
                GetAllData(_user);
            }
            else
            {
                Utility.GetMessageAlert(ConsoleColor.Yellow, "Record is empty");
            }
        }

        public void SearchUser()
        {
            int lengthList = _user.Count();
            if (lengthList == 0)
            {
                Utility.GetMessageAlert(ConsoleColor.Yellow, "Record is empty");
            }
            else
            {
                Console.Write("Input By Username : ");
                string inputUsername = Console.ReadLine().ToLower();
                var usernameMatching = _user.Where(x => x.Username.Contains(inputUsername)).ToList();

                if ((string.IsNullOrEmpty(inputUsername)) || string.IsNullOrWhiteSpace(inputUsername))
                { 
                    Utility.GetMessageAlert(ConsoleColor.Red, "Input is invalid");
                }
                else
                {
                    GetAllData(usernameMatching);
                }
            }
        }

        public void LoginUser()
        {
            int lengthList = _user.Count();
            bool loop = true;
            // bool isStay = true;

            if (lengthList == 0) 
            {
                Console.Clear();
                Utility.GetMessageAlert(ConsoleColor.Red, "you dont have account");
            }
            else
            {
                //bool isStay = true;
                while (loop)
                {
                    Console.Clear();
                    Console.WriteLine("Login");

                    foreach (var user in _user)
                    {
                        Console.Write("Username :");
                        string inputUsername = Console.ReadLine().ToLower().Trim();
                        Console.Write("Password :");
                        string inputPassword = Console.ReadLine().ToLower().Trim();

                        string username = user.Username;
                        string password = user.Password;

                        var passDecrypt = BCrypt.Net.BCrypt.Verify(inputPassword, password);

                        if (inputUsername == username && passDecrypt)
                        {
                            subMenu:
                            Utility.Loading();
                            Console.Clear();
                            Console.WriteLine("Welcome {0}", username.ToUpper());
                            Console.WriteLine("1. Edit User");
                            Console.WriteLine("2. Delete User");
                            Console.WriteLine("3. Logout");
                            Console.WriteLine("----------------");
                            Console.Write("Enter your option : ");
                            int choose = int.Parse(Console.ReadLine());
                            switch (choose)
                            {
                                case 1:
                                        EditUser();
                                        Console.Write("Back to main menu [y] or repeat this section [n] : ");
                                        string inputBack = Console.ReadLine().ToLower().Trim();
                                        switch (inputBack)
                                        {
                                            case "y":
                                                goto subMenu;
                                                break;
                                            case "n":
                                                EditUser();
                                                break;
                                            default:
                                                Utility.GetMessageAlert(ConsoleColor.Red, "input an invalid");
                                                Console.ReadKey();
                                                break;
                                        }
                                    
                                    break;
                                case 2:
                                    DeleteUser();
                                    break;
                                case 3:
                                    loop = false;
                                    Menu.GetMenuIntro();
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Utility.GetMessageAlert(ConsoleColor.Red, "username or passwords is not match");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public void EditUser()
        {
            Console.Clear();
            Console.WriteLine("Edit User");
            Console.WriteLine("----------");
            GetAllData(_user);
            for (int i = 0; i <= _user.Count() - 1; i++)
            {
                User user = _user[i];
                Console.Write("Enter Id User : ");
                string idUser = Console.ReadLine().ToLower().Trim();
                if (idUser == user.IdUser)
                {

                    Console.Write("Edit User - {0}\n", user.IdUser);
                    string id = user.IdUser;
                    Console.Write("Firstname : ");
                    string newFirsname = Utility.GetEmptyStringAlert(Console.ReadLine().ToLower().Trim(), "Firstname    : ");

                    Console.Write("Lastname : ");
                    string newLastname = Utility.GetEmptyStringAlert(Console.ReadLine().ToLower().Trim(), "Lastname     : ");

                    string newUsername = $"{Utility.GetSubstring(newFirsname)}{Utility.GetSubstring(newLastname)}";
                    Console.Write("Password : ");
                    string newPassword = Utility.GetPasswordValidation(Console.ReadLine().ToLower().Trim(), "Password     : ");
                    string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

                    user.IdUser = id;
                    user.Username = newUsername;
                    user.FirstName = newFirsname;
                    user.LastName = newLastname;
                    user.Password = newPasswordHash;
                    Utility.GetMessageAlert(ConsoleColor.Green, "Record has been edited");
                }
                else
                {
                    Utility.GetMessageAlert(ConsoleColor.Red, "Id not found!");
                    Console.ReadKey();
                    EditUser();
                }
            }
        }

        public void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("Delete User");
            Console.WriteLine("----------");
            GetAllData(_user);

            for (int i = 0; i <= _user.Count() - 1; i++)
            {
                User user = _user[i];
                Console.Write("Masukkan Id User : ");
                string idUser = Console.ReadLine();

                if (idUser == user.IdUser)
                {

                    Utility.GetTableFormat(user.IdUser, user.FirstName, user.LastName, user.Username, user.Password);
                    Console.WriteLine("Are you sure to delete this record ? : [y/n] ");
                    string choose = Console.ReadLine().ToLower().Trim();
                    switch (choose)
                    {
                        case "y":
                            _user.Remove(user);
                            DeleteUser();
                            break;
                        case "n":
                            break;
                        default:
                            Utility.GetMessageAlert(ConsoleColor.Red, "Invalid number");
                            break;
                    }
                    DeleteUser();
                }
                else
                {
                    Utility.GetMessageAlert(ConsoleColor.Red, "Id not found!");
                    Console.ReadKey();
                    DeleteUser();
                }
            }
        }
    }
}
