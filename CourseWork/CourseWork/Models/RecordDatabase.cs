﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public abstract class RecordDatabase : Database
    {
        public long next_id = 0;
        public List<Record> Records { get; protected set; }
        public virtual void Change(RecordChange change)
        {
            bool f = true;
            if(change.Type == ChangeType.Add)
            {
                change.To.ID = next_id++;
                Records.Add(change.To);
            }else if(change.Type == ChangeType.Edit)
            {
                int i = 0;
                for(i = 0; i < Records.Count; ++i)
                {
                    if(Records[i].ID == change.RecordID)
                    {
                        change.To.ID = change.RecordID;
                        Records[i] = change.To;
                        break;
                    }
                }

                if (i == Records.Count) f = false;


            }else if(change.Type == ChangeType.MoveToArchive)
            {
                int i = 0;
                for (i = 0; i < Records.Count; ++i)
                {
                    if (Records[i].ID == change.RecordID)
                    {
                        CriminalRecordsArchive crims_archive = new CriminalRecordsArchive();
                        crims_archive = (CriminalRecordsArchive)crims_archive.Load();
                        RecordChange archiveAddChange = new RecordChange(null, change.To, ChangeType.Add, ChangeDestination.CriminalsArchive, "");
                        crims_archive.Change(archiveAddChange);
                        crims_archive.Save();
                        Records.RemoveAt(i);
                        --i;
                        break;
                    }
                }

                if (i == Records.Count) f = false;
            }

            if(f)
            {
                RecordChangesArchive changesArchive = new RecordChangesArchive();
                changesArchive = (RecordChangesArchive)changesArchive.Load();
                changesArchive.Add(change);
                changesArchive.Save();
            }
            
        }
    }
}
