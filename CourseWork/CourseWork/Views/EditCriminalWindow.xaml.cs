using CourseWork.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EditCriminalWindow.xaml
    /// </summary>
    public partial class EditCriminalWindow : Window
    {
        private RecordChange recordChange;
        private string imageChange;
        private Session session;

        public EditCriminalWindow(CriminalRecord from, Session sess, ChangeDestination destination)
        {
            InitializeComponent();
            imageChange = from.Image;

            firstNameTextBox.Text = from.FirstName;
            lastNameTextBox.Text = from.LastName;
            nickNameTextBox.Text = from.NickName;
            heightTextBox.Text = from.Height;
            hairColorTextBox.Text = from.HairColor;
            eyeColorTextBox.Text = from.EyeColor;
            distinctiveFeaturesTextBox.Text = from.DistinctiveFeatures;
            citizenshipTextBox.Text = from.Citizenship;
            birthPlaceTextBox.Text = from.BirthPlace;
            birthDateTextBox.Text = from.BirthDate;
            lastDomicileTextBox.Text = from.LastDomicile;
            criminalSpecializationTextBox.Text = from.CriminalSpecialization;
            lastCaseTextBox.Text = from.LastCase;
            languagesTextBox.Text = from.Languages;
            session = sess;

            if(from.Image == "")
            {
                criminalImage.Source = new BitmapImage(new Uri("/Images/default.jpeg", UriKind.Relative));
            }
            else
            {
                criminalImage.Source = new BitmapImage(new Uri(from.Image, UriKind.Absolute));
            }


            recordChange = new RecordChange(from, null, ChangeType.Edit, destination, session.User.Username, from.ID);
        }

        private void editCriminalButton_Click(object sender, RoutedEventArgs e)
        {
            recordChange.To = new CriminalRecord(firstName: firstNameTextBox.Text,
                lastName: lastNameTextBox.Text, nickName: nickNameTextBox.Text, height: heightTextBox.Text,
                hairColor: hairColorTextBox.Text, eyeColor: eyeColorTextBox.Text, distinctiveFeatures: distinctiveFeaturesTextBox.Text,
                citizenShip: citizenshipTextBox.Text, birthPlace: birthPlaceTextBox.Text, birthDate: birthDateTextBox.Text,
                lastDomicile: lastDomicileTextBox.Text, criminalSpecialization: criminalSpecializationTextBox.Text,
                lastCase: lastCaseTextBox.Text, languages: languagesTextBox.Text, image: imageChange);

            if(session.User.Role == UserRole.Admin)
            {

                CriminalRecordsDatabase crimsDB = new CriminalRecordsDatabase();
                crimsDB = (CriminalRecordsDatabase)crimsDB.Load();
                crimsDB.Change(recordChange);
                crimsDB.Save();

                CriminalRecordsArchive crimsArchive = new CriminalRecordsArchive();
                crimsArchive = (CriminalRecordsArchive)crimsArchive.Load();
                crimsArchive.Change(recordChange);
                crimsArchive.Save();
            }
            else
            {
                RecordChangesDatabase changesDB = new RecordChangesDatabase();
                changesDB = (RecordChangesDatabase)changesDB.Load();
                changesDB.Add(recordChange);
                changesDB.Save();  
            }

            
            this.Close();
        }

        private void changeImageButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Console.WriteLine(openFileDialog.FileName);

                string new_path = Environment.CurrentDirectory + "\\" + Constants.IMAGES_PATH + "\\";
                string[] s = openFileDialog.FileName.Split('\\');
                string file = s[s.Length - 1];

                imageChange = new_path + file;
                if(!File.Exists(imageChange))
                    File.Copy(openFileDialog.FileName, imageChange);
                criminalImage.Source = new BitmapImage(new Uri(imageChange, UriKind.Absolute));
            }

        }
    }
}
