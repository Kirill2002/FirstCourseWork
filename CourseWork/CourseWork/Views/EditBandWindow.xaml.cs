﻿using CourseWork.Models;
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
    /// Логика взаимодействия для EditBandWindow.xaml
    /// </summary>
    public partial class EditBandWindow : Window
    {
        private RecordChange recordChange;
        private Session session;
        private ChangeDestination destination;

        public EditBandWindow(BandRecord from, Session sess, ChangeDestination destination)
        {
            InitializeComponent();

            nameTextBox.Text = from.Name;
            occupationTextBox.Text = from.Occupation;
            listOfMembersTextBox.Text = from.MembersString;
            additionalInfoTextBox.Text = from.AdditionalInfo;
            session = sess;

            recordChange = new RecordChange(from, null, ChangeType.Edit, destination, session.User.Username, from.ID);
            
        }


        private void editBandButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> mems = new List<string>();
            string[] mems_split = listOfMembersTextBox.Text.Split('\n');
            foreach (var mems_with_spaces in mems_split)
            {
                string[] m = mems_with_spaces.Split(' ');
                foreach (var mem in m)
                {
                    if (mem != "")
                        if (mem[mem.Length - 1] == ',')
                            mems.Add(mem.Substring(0, mem.Length - 1));
                        else
                            mems.Add(mem);
                }
            }
            recordChange.To = new BandRecord(name: nameTextBox.Text,
                occupation: occupationTextBox.Text, members: mems, additionalInfo: additionalInfoTextBox.Text);

            if(session.User.Role == UserRole.Admin)
            {
                BandRecordsDatabase bands_db = new BandRecordsDatabase();
                bands_db = (BandRecordsDatabase)bands_db.Load();
                bands_db.Change(recordChange);
                bands_db.Save();
            }
            else
            {
                RecordChangesDatabase changes_db = new RecordChangesDatabase();
                changes_db = (RecordChangesDatabase)changes_db.Load();
                changes_db.Add(recordChange);
                changes_db.Save();
            }
            
            this.Close();
        }
    }
}