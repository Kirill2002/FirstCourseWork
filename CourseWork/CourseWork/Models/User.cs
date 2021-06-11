using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public enum UserRole : byte
    {
        Admin,
        User
    }

    [Serializable]
    public class User
    {
        public string Username { get; set; }



        public UserRole Role { get; set; }

        public string Password { get; set; }

        public string UserRoleString
        {
            get
            {
                return Role.ToString();
            }
        }


        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public string this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return Username;
                    case 1:
                        return UserRoleString;
                    case 2:
                        return Password;
                    default:
                        return "Error";
                }
            }
            

        }

        public static List<string> ListOfProperties
        {
            get
            {
                List<string> res = new List<string> { "Ім'я користувача", "Статус"};
                return res;
            }
        }
    }
}
