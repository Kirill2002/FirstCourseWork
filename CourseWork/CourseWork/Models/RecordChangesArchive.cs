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

        public long next_change_id = 0;

        public RecordChangesArchive()
        {
            RecordChanges = new List<RecordChange>();
            type = "RecordChangesArchive";
        }

        public void Add(RecordChange recordChange)
        {
            recordChange.ChangeID = next_change_id++;
            RecordChanges.Add(recordChange);
        }

    }
}
