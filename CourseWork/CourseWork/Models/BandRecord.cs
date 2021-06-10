using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public class BandRecord : Record
    {
        
        public string Name { get; set; }

        public string Occupation { get; set; }

        public List<string> Members { get; set; }

        public string AdditionalInfo { get; set; }

        
        public string this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return IDstring;
                    case 1:
                        return Name;
                    case 2:
                        return Occupation;
                    case 3:
                        return MembersString;
                    case 4:
                        return AdditionalInfo;
                    default:
                        return "Error";
                }
                
            }
        }
        

        public BandRecord(string name = "", string occupation = "", string additionalInfo = "", List<string> members = null)
        {
            Name = name;
            Occupation = occupation;
            AdditionalInfo = additionalInfo;
            Members = members;
        }

        public string MembersString
        {
            get
            {
                string res = "";
                for(int i = 0; i < Members.Count; ++i)
                {
                    
                    res += Members[i];
                    if (i != Members.Count - 1)
                        res += ", ";
                    if (i % 5 == 0 && i != 0)
                        res += "\n";
                }
                return res;
            }
        }

        public string IDstring
        {
            get
            {
                return Convert.ToString(ID);
            }
        }

        public static List<string> ListOfProperties
        {
            get
            {
                List<string> res = new List<string> {"ID", "Назва", "Рід діяльності", "Члени", "Додаткова інформація" };
                return res;
            }
        }


    }
}
