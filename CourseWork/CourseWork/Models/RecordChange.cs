using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public enum ChangeType : byte
    {
        Add,
        Edit,
        MoveToArchive,
        MoveBackFromArchive
    }

    [Serializable]
    public enum ChangeDestination : byte
    {
        CriminalsDatabase,
        BandsDatabase,
        CriminalsArchive
    }

    [Serializable]
    public class RecordChange
    {
        public Record From { get; set; }

        public Record To { get; set; }

        public long RecordID { get; set; }

        public ChangeType Type { get; set; }

        public long ChangeID { get; set; }

        public ChangeDestination Destination { get; set; }

        public string RecordIDstring 
        { 
            get
            {
                if (Type == ChangeType.Add) return "";
                return Convert.ToString(RecordID);
                
            }
        }

        

        public string TypeToString
        {
            get
            {
                return Type.ToString();
            }
        }

        public string Author {get; set;}

        public RecordChange(Record from, Record to, ChangeType type, ChangeDestination destination, string author, long id = 0)
        {
            From = from;
            To = to;
            RecordID = id;
            Type = type;
            Destination = destination;
            Author = author;
        }

        public string this[int i]
        {
            get
            {
                switch(i)
                {
                    case 0:
                        return Author;
                    case 1:
                        return TypeToString;
                    case 2:
                        return RecordIDstring;
                    default:
                        return "Error";
                }
            }
        }

        public static List<string> ListOfProperties
        {
            get
            {
                List<string> res = new List<string> {"Автор", "Тип зміни", "Запис, що змінюється"};
                return res;
            }
        }
    }
}
