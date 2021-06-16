using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public class BandRecordsDatabase : RecordDatabase
    {
        public BandRecordsDatabase()
        {
            Records = new List<Record>();
            type = "BandRecordsDatabase";
        }
        
    }
}
