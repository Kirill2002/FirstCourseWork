using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public class RecordChangesArchive : Database
    {
        public List<RecordChange> RecordChanges { get; set; }

        public long nextChangeID = 0;

        public RecordChangesArchive()
        {
            RecordChanges = new List<RecordChange>();
            type = "RecordChangesArchive";
        }

        public void Add(RecordChange recordChange)
        {
            recordChange.ChangeID = nextChangeID++;
            RecordChanges.Add(recordChange);
        }

    }
}
