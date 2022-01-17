using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBcrypt
{
    public class User
    {
        public User(string idUser, string firstName, string lastName, string username, string password)
        {
            IdUser = idUser;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;

        }

        public string IdUser { get; set; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
    }
}
