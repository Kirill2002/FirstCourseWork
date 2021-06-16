using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public class RecordChangesDatabase : Database
    {
        public List<RecordChange> RecordChanges { get; set; }

        public static long nextChangeID = 0;

        public RecordChangesDatabase()
        {
            RecordChanges = new List<RecordChange>();
            type = "RecordChangesDatabase";
        }

        public void Add(RecordChange recordChange)
        {
            recordChange.ChangeID = nextChangeID++;
            RecordChanges.Add(recordChange);
        }

        public void Delete(RecordChange recordChange)
        {
            for(int i = 0; i < RecordChanges.Count; ++i)
            {
                if (recordChange.ChangeID == RecordChanges[i].ChangeID)
                {
                    RecordChanges.RemoveAt(i);
                    break;
                }
                    
            }
        }

    }
}
