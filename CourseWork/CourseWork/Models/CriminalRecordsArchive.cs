﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public class CriminalRecordsArchive : RecordDatabase
    {

        public CriminalRecordsArchive()
        {
            Records = new List<Record>();
            type = "CriminalRecordsArchive";
        }

        public override void Change(RecordChange change)
        {
            bool f = true;
            if (change.Type == ChangeType.Add)
            {
                Records.Add(change.To);
                f = false;
            }
            else if (change.Type == ChangeType.Edit)
            {
                int i = 0;
                for (i = 0; i < Records.Count; ++i)
                {
                    if (Records[i].ID == change.RecordID)
                    {
                        change.To.ID = change.RecordID;
                        Records[i] = change.To;
                        break;
                    }
                }

                if (i == Records.Count) f = false;

            }else if(change.Type == ChangeType.MoveBackFromArchive)
            {
                int i = 0;
                for (i = 0; i < Records.Count; ++i)
                {
                    if (Records[i].ID == change.RecordID)
                    {
                        CriminalRecordsDatabase crims_db = new CriminalRecordsDatabase();
                        crims_db = (CriminalRecordsDatabase)crims_db.Load();
                        crims_db.Records.Add(Records[i]);
                        crims_db.Save();
                        Records.RemoveAt(i);
                        --i;
                        break;
                    }
                }

                if (i == Records.Count) f = false;
            }

            if (f)
            {
                RecordChangesArchive changesArchive = new RecordChangesArchive();
                changesArchive = (RecordChangesArchive)changesArchive.Load();
                changesArchive.Add(change);
                changesArchive.Save();
            }
        }
    }
}