using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public class UsersDatabase : Database
    {
        public List<User> Users { get; set; }
        public UsersDatabase()
        {
            Users = new List<User>();
            type = "UsersDatabase";
        }


    }
}
