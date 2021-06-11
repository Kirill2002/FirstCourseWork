using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public class CriminalRecordsDatabase : RecordDatabase
    {
        public CriminalRecordsDatabase()
        {
            Records = new List<Record>();
            type = "CriminalRecordsDatabase";
            nextID = 0;
        }
        
    }
}
