using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public class Session
    {
        public User User {get; set;}


        public Session()
        {
            User = null;
        }
    }
}
