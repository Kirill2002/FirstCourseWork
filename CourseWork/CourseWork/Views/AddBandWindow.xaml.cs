using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseWork.Views
{
    /// <summary>
    /// Логика взаимодействия для AddBandWindow.xaml
    /// </summary>
    public partial class AddBandWindow : Window
    {
        private Session session;

        private ChangeDestination destination;

        public AddBandWindow(Session sess, ChangeDestination dest)
        {
            InitializeComponent();
            session = sess;
            destination = dest;
        }

        private void addBandButton_Click(object sender, RoutedEventArgs e)
        {


            List<string> mems = new List<string>();
            string[] mems_split = listOfMembersTextBox.Text.Split('\n');
            foreach(var mems_with_spaces in mems_split)
            {
                string[] m = mems_with_spaces.Split(' ');
                foreach(var mem in m)
                {
                    if (mem != "")
                        if (mem[mem.Length - 1] == ',')
                            mems.Add(mem.Substring(0, mem.Length - 1));
                        else
                            mems.Add(mem);
                }
            }
            BandRecord newBand = new BandRecord(name: nameTextBox.Text, occupation: occupationTextBox.Text, additionalInfo: additionalInfoTextBox.Text, mems);
            RecordChange change = new RecordChange(null, newBand, ChangeType.Add, destination, session.User.Username);


            if (session.User.Role == UserRole.Admin)
            {
                BandRecordsDatabase bands_db = new BandRecordsDatabase();
                bands_db = (BandRecordsDatabase)bands_db.Load();
                bands_db.Change(change);
                bands_db.Save();
            }
            else
            {
                RecordChangesDatabase changes_db = new RecordChangesDatabase();
                changes_db = (RecordChangesDatabase)changes_db.Load();
                changes_db.Add(change);
                changes_db.Save();
            }
            
            this.Close();
        }
    }
}
