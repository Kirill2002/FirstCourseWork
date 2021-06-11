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
    /// Логика взаимодействия для AddCriminalWindow.xaml
    /// </summary>
    public partial class AddCriminalWindow : Window
    {
        private string imagePath;
        private Session session;
        private ChangeDestination destination;

        public AddCriminalWindow(Session sess, ChangeDestination dest)
        {
            InitializeComponent();
            imagePath = "";
            criminalImage.Source = new BitmapImage(new Uri("/Images/default.jpeg", UriKind.Relative));
            session = sess;
            destination = dest;
        }

        private void addCriminalButton_Click(object sender, RoutedEventArgs e)
        {
            CriminalRecord newCriminal = new CriminalRecord(firstName: firstNameTextBox.Text,
                lastName: lastNameTextBox.Text, nickName: nickNameTextBox.Text, height: heightTextBox.Text,
                hairColor: hairColorTextBox.Text, eyeColor: eyeColorTextBox.Text, distinctiveFeatures: distinctiveFeaturesTextBox.Text,
                citizenShip: citizenshipTextBox.Text, birthPlace: birthPlaceTextBox.Text, birthDate: birthDateTextBox.Text,
                lastDomicile: lastDomicileTextBox.Text, criminalSpecialization: criminalSpecializationTextBox.Text,
                lastCase: lastCaseTextBox.Text, languages: languagesTextBox.Text,
                image: imagePath);
            
            RecordChange change = new RecordChange(null, newCriminal, ChangeType.Add, destination, session.User.Username);

            if(session.User.Role == UserRole.Admin)
            {
                CriminalRecordsDatabase db_crims = new CriminalRecordsDatabase();
                db_crims = (CriminalRecordsDatabase)db_crims.Load();
                db_crims.Change(change);
                db_crims.Save();
            }else
            {
                RecordChangesDatabase changesDB = new RecordChangesDatabase();
                changesDB = (RecordChangesDatabase)changesDB.Load();
                changesDB.Add(change);
                changesDB.Save();
            }
            
            this.Close();
        }

        private void changeImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Console.WriteLine(openFileDialog.FileName);

                string new_path = Environment.CurrentDirectory + "\\" + Constants.IMAGES_PATH + "\\";
                string[] s = openFileDialog.FileName.Split('\\');
                string file = s[s.Length - 1];
                imagePath = new_path + file;
                if (!File.Exists(imagePath))
                    File.Copy(openFileDialog.FileName, imagePath);
                criminalImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
            }
        }

    }
}
