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
    public abstract class Database
    {
        protected string type;
        public void Save()
        {
            BinaryFormatter formatter= new BinaryFormatter();
            string path = Environment.CurrentDirectory + "\\" + Constants.DATABASE_PATH + "\\";
            Directory.CreateDirectory(path);
            using (FileStream fs = new FileStream(path + type, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }


        public Database Load()
        {
            string path = Environment.CurrentDirectory + "\\" + Constants.DATABASE_PATH + "\\" + type;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                
                Database res = (Database)formatter.Deserialize(fs);
                return res;
            }

        }
    }
}
