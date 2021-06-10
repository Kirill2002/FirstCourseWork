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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseWork.Models;
using CourseWork.Views;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CriminalRecordsDatabase crims_db;
        private BandRecordsDatabase bands_db;
        private CriminalRecordsArchive crims_arch;
        private Session session;
        private UsersDatabase users_db;
        private RecordChangesDatabase changes_db;
        private RecordChangesArchive changesArchive;

        public MainWindow()
        {
            InitializeComponent();
            
            //db.Users.Add(new User("Kirill", "12345678", UserRole.Admin));
            //db.Save();

            string path_data_dir = Environment.CurrentDirectory + "\\" + Constants.DATABASE_PATH;
            if (!Directory.Exists(path_data_dir) || Directory.GetFiles(path_data_dir).Length == 0)
            {
                UsersDatabase udb = new UsersDatabase();
                CriminalRecordsDatabase crims_db = new CriminalRecordsDatabase();
                BandRecordsDatabase bands_db = new BandRecordsDatabase();
                CriminalRecordsArchive crims_arch = new CriminalRecordsArchive();
                RecordChangesDatabase changes_db = new RecordChangesDatabase();
                RecordChangesArchive changesArchive = new RecordChangesArchive();
                udb.Save();
                crims_db.Save();
                bands_db.Save();
                crims_arch.Save();
                changes_db.Save();
                changesArchive.Save();
            }
            string path_img = Environment.CurrentDirectory + "\\" + Constants.IMAGES_PATH;
            if (!Directory.Exists(path_img))
            {
                Directory.CreateDirectory(path_img);
            }

           

            session = new Session();

            Authorisation authWindow = new Authorisation();

            if(authWindow.ShowDialog() == true)
            {
                session.User = authWindow.User;
            }else
            {
                this.Close();
            }
            //UsersDatabase db = new UsersDatabase();
            //db = (UsersDatabase)db.Load();

            
            //db_crims = new CriminalRecordsDatabase();
            ////db_crims.Save();

            //db_crims = (CriminalRecordsDatabase)db_crims.Load();

            if(session.User != null)
            {
                if (session.User.Role == UserRole.User)
                {
                    ChangesConfirm.Visibility = Visibility.Collapsed;
                    Users.Visibility = Visibility.Collapsed;
                    ChangesArchive.Visibility = Visibility.Collapsed;

                    addBandButton.Content = "Запропонувати запис";
                    addBandButton.Width = 200;
                    addCriminalButton.Content = "Запропонувати запис";
                    addCriminalButton.Width = 200;
                    ContextMenu cm1 = criminalsDataGrid.FindResource("rowContextMenu") as ContextMenu;
                    (cm1.Items[0] as MenuItem).Header = "Запропонувати зміни";
                    (cm1.Items[2] as MenuItem).Visibility = Visibility.Collapsed;
                    
                    ContextMenu cm2 = bandsDataGrid.FindResource("rowContextMenu") as ContextMenu;
                    (cm2.Items[0] as MenuItem).Header = "Запропонувати зміни";


                    ContextMenu cm3 = criminalsArchiveDataGrid.FindResource("rowContextMenu") as ContextMenu;
                    (cm3.Items[0] as MenuItem).Header = "Запропонувати зміни";
                    (cm3.Items[2] as MenuItem).Visibility = Visibility.Collapsed;

                }
            }


            //criminalsDataGrid.ItemsSource = db_crims.Records;
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(criminalsDataGrid.ItemsSource);
            //filterCriminalsComboBox.ItemsSource = CriminalRecord.ListOfProperties;
            //view.Filter = UserFilter;


            //ContextMenu cm = criminalsDataGrid.FindResource("rowContextMenu") as ContextMenu;
            //(cm.Items[0] as MenuItem).Visibility = Visibility.Collapsed;

        }


        private bool UserFilterCrims(object item)
        {
            if (String.IsNullOrEmpty(filterCriminalsTextBox.Text))
                return true;
            else
                return (item as CriminalRecord)[filterCriminalsComboBox.SelectedIndex].IndexOf((string)filterCriminalsTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool UserFilterBands(object item)
        {
            if (String.IsNullOrEmpty(filterBandsTextBox.Text))
                return true;
            else
                return (item as BandRecord)[filterBandsComboBox.SelectedIndex].IndexOf((string)filterBandsTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool UserFilterCrimsArchive(object item)
        {
            if (String.IsNullOrEmpty(filterCriminalsArchiveTextBox.Text))
                return true;
            else
                return (item as CriminalRecord)[filterCriminalsArchiveComboBox.SelectedIndex].IndexOf((string)filterCriminalsArchiveTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool UserFilterUsers(object item)
        {
            if (String.IsNullOrEmpty(filterUsersTextBox.Text))
                return true;
            else
                return (item as User)[filterUsersComboBox.SelectedIndex].IndexOf((string)filterUsersTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool UserFilterChanges(object item)
        {
            if (String.IsNullOrEmpty(filterChangesTextBox.Text))
                return true;
            else
                return (item as RecordChange)[filterChangesComboBox.SelectedIndex].IndexOf((string)filterChangesTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool UserFilterChangesArchive(object item)
        {
            if (String.IsNullOrEmpty(filterChangesArchiveTextBox.Text))
                return true;
            else
                return (item as RecordChange)[filterChangesArchiveComboBox.SelectedIndex].IndexOf((string)filterChangesArchiveTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }


        private void filterCriminalsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(criminalsDataGrid.ItemsSource).Refresh();
        }

        private void filterCriminalsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(criminalsDataGrid.ItemsSource).Refresh();
        }

        private void filterCriminalsArchiveTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(criminalsArchiveDataGrid.ItemsSource).Refresh();
        }

        private void filterCriminalsArchiveComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(criminalsArchiveDataGrid.ItemsSource).Refresh();
        }

        private void filterUsersTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(usersDataGrid.ItemsSource).Refresh();
        }

        private void filterUsersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(usersDataGrid.ItemsSource).Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(crims_db != null)
                crims_db.Save();
            if (crims_arch != null)
                crims_arch.Save();
            if (bands_db != null)
                bands_db.Save();
            if (users_db != null)
                users_db.Save();
            if (changesArchive != null)
                changesArchive.Save();
            Console.WriteLine("Closed!");

        }


        private void Window_Activated(object sender, EventArgs e)
        {
            if(crims_db != null)
            {
                crims_db = (CriminalRecordsDatabase)crims_db.Load();

                criminalsDataGrid.ItemsSource = crims_db.Records;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(criminalsDataGrid.ItemsSource);
                filterCriminalsComboBox.ItemsSource = CriminalRecord.ListOfProperties;
                view.Filter = UserFilterCrims;
            }else if(bands_db != null)
            {
                bands_db = (BandRecordsDatabase)bands_db.Load();
                bandsDataGrid.ItemsSource = bands_db.Records;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(bandsDataGrid.ItemsSource);
                filterBandsComboBox.ItemsSource = BandRecord.ListOfProperties;
                view.Filter = UserFilterBands;

            }else if(crims_arch != null)
            {
                crims_arch = (CriminalRecordsArchive)crims_arch.Load();
                criminalsArchiveDataGrid.ItemsSource = crims_arch.Records;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(criminalsArchiveDataGrid.ItemsSource);
                filterCriminalsArchiveComboBox.ItemsSource = CriminalRecord.ListOfProperties;
                view.Filter = UserFilterCrimsArchive;
            }else if(users_db != null)
            {
                users_db = (UsersDatabase)users_db.Load();
                usersDataGrid.ItemsSource = users_db.Users;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(usersDataGrid.ItemsSource);
                filterUsersComboBox.ItemsSource = User.ListOfProperties;
                view.Filter = UserFilterUsers;
            }else if(changes_db != null)
            {
                changes_db = (RecordChangesDatabase)changes_db.Load();
                changesDataGrid.ItemsSource = changes_db.RecordChanges;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(changesDataGrid.ItemsSource);
                filterChangesComboBox.ItemsSource = RecordChange.ListOfProperties;
                view.Filter = UserFilterChanges;
            }else if(changesArchive != null)
            {
                changesArchive = (RecordChangesArchive)changesArchive.Load();
                changesArchiveDataGrid.ItemsSource = changesArchive.RecordChanges;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(changesArchiveDataGrid.ItemsSource);
                filterChangesArchiveComboBox.ItemsSource = RecordChange.ListOfProperties;
                view.Filter = UserFilterChangesArchive;
            }

        }


        private void editCriminalMenuItem_Click(object sender, RoutedEventArgs e)
        {
            EditCriminalWindow editWindow = new EditCriminalWindow(criminalsDataGrid.SelectedItem as CriminalRecord, session, ChangeDestination.CriminalsDatabase);
            editWindow.Show();
        }

        private void editCriminalArchiveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            EditCriminalWindow editWindow = new EditCriminalWindow(criminalsArchiveDataGrid.SelectedItem as CriminalRecord, session, ChangeDestination.CriminalsArchive);
            editWindow.Show();
        }

        private void Criminals_Selected(object sender, RoutedEventArgs e)
        {
            crims_db = new CriminalRecordsDatabase();
            //db_crims.Save();

            crims_db = (CriminalRecordsDatabase)crims_db.Load();

            criminalsDataGrid.ItemsSource = crims_db.Records;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(criminalsDataGrid.ItemsSource);
            filterCriminalsComboBox.ItemsSource = CriminalRecord.ListOfProperties;
            view.Filter = UserFilterCrims;
        }

        private void Criminals_Unselected(object sender, RoutedEventArgs e)
        {
            crims_db.Save();
            crims_db = null;
        }

        private void ChangesConfirm_Selected(object sender, RoutedEventArgs e)
        {
            changes_db = new RecordChangesDatabase();
            changes_db = (RecordChangesDatabase)changes_db.Load();
            changesDataGrid.ItemsSource = changes_db.RecordChanges;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(changesDataGrid.ItemsSource);
            filterChangesComboBox.ItemsSource = RecordChange.ListOfProperties;
            view.Filter = UserFilterChanges;
        }

        private void ChangesConfirm_Unselected(object sender, RoutedEventArgs e)
        {
            changes_db.Save();
            changes_db = null;
        }

        private void addCriminalButton_Click(object sender, RoutedEventArgs e)
        {
            AddCriminalWindow addWindow = new AddCriminalWindow(session, ChangeDestination.CriminalsDatabase);
            addWindow.Show();
        }

        private void Bands_Selected(object sender, RoutedEventArgs e)
        {
            bands_db = new BandRecordsDatabase();
            bands_db = (BandRecordsDatabase)bands_db.Load();
            bandsDataGrid.ItemsSource = bands_db.Records;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(bandsDataGrid.ItemsSource);
            filterBandsComboBox.ItemsSource = BandRecord.ListOfProperties;
            view.Filter = UserFilterBands;

            //List<CriminalRecord> mems = new List<CriminalRecord>();
            //mems.Add(new CriminalRecord(firstName: "Денис", lastName: "Рябцев"));
            //mems.Add(new CriminalRecord(firstName: "Денис", lastName: "Рябцев"));
            //bands_db.Records.Add(new BandRecord(name: "NURE", occupation: "Hacking", additionalInfo: "", members: mems));
        }

        private void Bands_Unselected(object sender, RoutedEventArgs e)
        {
            bands_db.Save();
            bands_db = null;
        }

        private void Users_Selected(object sender, RoutedEventArgs e)
        {
            users_db = new UsersDatabase();
            users_db = (UsersDatabase)users_db.Load();
            usersDataGrid.ItemsSource = users_db.Users;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(usersDataGrid.ItemsSource);
            filterUsersComboBox.ItemsSource = User.ListOfProperties;
            view.Filter = UserFilterUsers;
        }

        private void Users_Unselected(object sender, RoutedEventArgs e)
        {
            users_db.Save();
            users_db = null;
        }

        private void filterBandsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(bandsDataGrid.ItemsSource).Refresh();
        }

        private void filterBandsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(bandsDataGrid.ItemsSource).Refresh();
        }

        private void filterChangesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(changesDataGrid.ItemsSource).Refresh();
        }

        private void filterChangesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(changesDataGrid.ItemsSource).Refresh();
        }

        private void filterChangesArchiveTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(changesArchiveDataGrid.ItemsSource).Refresh();
        }

        private void filterChangesArchiveComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(changesArchiveDataGrid.ItemsSource).Refresh();
        }

        private void addBandButton_Click(object sender, RoutedEventArgs e)
        {
            AddBandWindow addWindow = new AddBandWindow(session, ChangeDestination.BandsDatabase);
            addWindow.Show();
        }


        private void editBandMenuItem_Click(object sender, RoutedEventArgs e)
        {
            EditBandWindow editWindow = new EditBandWindow(bandsDataGrid.SelectedItem as BandRecord, session, ChangeDestination.BandsDatabase);
            editWindow.Show();
        }

        

        private void showCriminalsDetailsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowCriminalsDetailsWindow showWindow = new ShowCriminalsDetailsWindow(criminalsDataGrid.SelectedItem as CriminalRecord);
            showWindow.Show();
        }

        private void showBandDetailsBandMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowBandsDetailsWindow showWindow = new ShowBandsDetailsWindow(bandsDataGrid.SelectedItem as BandRecord);
            showWindow.Show();
        }

        private void showCriminalsDetailsArchiveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowCriminalsDetailsWindow showWindow = new ShowCriminalsDetailsWindow(criminalsArchiveDataGrid.SelectedItem as CriminalRecord);
            showWindow.Show();
        }

        

        private void Archive_Selected(object sender, RoutedEventArgs e)
        {
            crims_arch = new CriminalRecordsArchive();
            crims_arch = (CriminalRecordsArchive)crims_arch.Load();
            criminalsArchiveDataGrid.ItemsSource = crims_arch.Records;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(criminalsArchiveDataGrid.ItemsSource);
            filterCriminalsArchiveComboBox.ItemsSource = CriminalRecord.ListOfProperties;
            view.Filter = UserFilterCrimsArchive;
        }

        private void Archive_Unselected(object sender, RoutedEventArgs e)
        {
            crims_arch.Save();
            crims_arch = null;
        }

        private void ChangesArchive_Selected(object sender, RoutedEventArgs e)
        {
            changesArchive = new RecordChangesArchive();
            changesArchive = (RecordChangesArchive)changesArchive.Load();
            changesArchiveDataGrid.ItemsSource = changesArchive.RecordChanges;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(changesArchiveDataGrid.ItemsSource);
            filterChangesArchiveComboBox.ItemsSource = RecordChange.ListOfProperties;
            view.Filter = UserFilterChangesArchive;
        }

        private void ChangesArchive_Unselected(object sender, RoutedEventArgs e)
        {
            changesArchive.Save();
            changesArchive = null;
        }

        private void moveCriminalToArchiveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RecordChange change = new RecordChange(null, (criminalsDataGrid.SelectedItem as CriminalRecord),
                ChangeType.MoveToArchive, ChangeDestination.CriminalsDatabase, session.User.Username, (criminalsDataGrid.SelectedItem as CriminalRecord).ID);

            if(session.User.Role == UserRole.Admin)
            {
                crims_db.Change(change);
                crims_db.Save();
            }
            else
            {
                RecordChangesDatabase changes_db = new RecordChangesDatabase();
                changes_db = (RecordChangesDatabase)changes_db.Load();
                changes_db.Add(change);
                changes_db.Save();
                changes_db = null;
            }


            criminalsDataGrid.ItemsSource = crims_db.Records;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(criminalsDataGrid.ItemsSource);
            filterCriminalsComboBox.ItemsSource = CriminalRecord.ListOfProperties;
            view.Filter = UserFilterCrims;
        }

        private void moveBackFromArchiveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RecordChange change = new RecordChange(null, (criminalsArchiveDataGrid.SelectedItem as CriminalRecord), 
                ChangeType.MoveBackFromArchive, ChangeDestination.CriminalsArchive, session.User.Username, (criminalsArchiveDataGrid.SelectedItem as CriminalRecord).ID);

            if (session.User.Role == UserRole.Admin)
            {
                crims_arch.Change(change);
                crims_arch.Save();
            }
            else
            {
                RecordChangesDatabase changes_db = new RecordChangesDatabase();
                changes_db = (RecordChangesDatabase)changes_db.Load();
                changes_db.Add(change);
                changes_db.Save();
                changes_db = null;
            }

            criminalsArchiveDataGrid.ItemsSource = crims_arch.Records;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(criminalsArchiveDataGrid.ItemsSource);
            filterCriminalsArchiveComboBox.ItemsSource = CriminalRecord.ListOfProperties;
            view.Filter = UserFilterCrimsArchive;
        }

        

        

        private void promoteToAdminMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(usersDataGrid.SelectedItem != null)
                (usersDataGrid.SelectedItem as User).Role = UserRole.Admin;
            CollectionViewSource.GetDefaultView(usersDataGrid.ItemsSource).Refresh();
        }

        

        private void applyChangeMenuItem_Click(object sender, RoutedEventArgs e)
        {


            if ((changesDataGrid.SelectedItem as RecordChange).Destination == ChangeDestination.CriminalsDatabase)
            {
                crims_db = new CriminalRecordsDatabase();
                crims_db = (CriminalRecordsDatabase)crims_db.Load();
                crims_db.Change(changesDataGrid.SelectedItem as RecordChange);
                crims_db.Save();
                crims_db = null;
            }
            else if ((changesDataGrid.SelectedItem as RecordChange).Destination == ChangeDestination.BandsDatabase)
            {
                bands_db = new BandRecordsDatabase();
                bands_db = (BandRecordsDatabase)bands_db.Load();
                bands_db.Change(changesDataGrid.SelectedItem as RecordChange);
                bands_db.Save();
                bands_db = null;
            }
            else if ((changesDataGrid.SelectedItem as RecordChange).Destination == ChangeDestination.CriminalsArchive)
            {
                crims_arch = new CriminalRecordsArchive();
                crims_arch = (CriminalRecordsArchive)crims_arch.Load();
                crims_arch.Change(changesDataGrid.SelectedItem as RecordChange);
                crims_arch.Save();
                crims_arch = null;
            }

            changes_db.Delete(changesDataGrid.SelectedItem as RecordChange);
            changes_db.Save();
            CollectionViewSource.GetDefaultView(changesDataGrid.ItemsSource).Refresh();
        }

        private void deleteChangeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            changes_db.Delete(changesDataGrid.SelectedItem as RecordChange);
            changes_db.Save();
            CollectionViewSource.GetDefaultView(changesDataGrid.ItemsSource).Refresh();
        }

        private void showChangeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowChangeDetailsWindow showDetailsWindow = new ShowChangeDetailsWindow(changesDataGrid.SelectedItem as RecordChange);
            showDetailsWindow.Show();
        }

        

        private void showChangeArchiveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowChangeDetailsWindow showDetailsWindow = new ShowChangeDetailsWindow(changesArchiveDataGrid.SelectedItem as RecordChange);
            showDetailsWindow.Show();
        }

        private void Account_Selected(object sender, RoutedEventArgs e)
        {
            userNameTextBlock.Text = "Ім'я користувача: " + session.User.Username;
            userRoleTextBlock.Text = "Роль: " + session.User.UserRoleString;
        }

        private void Account_Unselected(object sender, RoutedEventArgs e)
        {

        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            //session = new Session();

            //Authorisation authWindow = new Authorisation();

            //if (authWindow.ShowDialog() == true)
            //{
            //    session.User = authWindow.User;
            //}
            //else
            //{
            //    this.Close();
            //}

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
            //if (session.User != null)
            //{
            //    if (session.User.Role == UserRole.User)
            //    {
            //        ChangesConfirm.Visibility = Visibility.Collapsed;
            //        Users.Visibility = Visibility.Collapsed;
            //        ChangesArchive.Visibility = Visibility.Collapsed;

            //        addBandButton.Content = "Запропонувати запис";
            //        addBandButton.Width = 200;
            //        addCriminalButton.Content = "Запропонувати запис";
            //        addCriminalButton.Width = 200;
            //        ContextMenu cm1 = criminalsDataGrid.FindResource("rowContextMenu") as ContextMenu;
            //        (cm1.Items[0] as MenuItem).Header = "Запропонувати зміни";
            //        (cm1.Items[2] as MenuItem).Visibility = Visibility.Collapsed;

            //        ContextMenu cm2 = bandsDataGrid.FindResource("rowContextMenu") as ContextMenu;
            //        (cm2.Items[0] as MenuItem).Header = "Запропонувати зміни";


            //        ContextMenu cm3 = criminalsArchiveDataGrid.FindResource("rowContextMenu") as ContextMenu;
            //        (cm3.Items[0] as MenuItem).Header = "Запропонувати зміни";
            //        (cm3.Items[2] as MenuItem).Visibility = Visibility.Collapsed;

            //    }else
            //    {
            //        ChangesConfirm.Visibility = Visibility.Visible;
            //        Users.Visibility = Visibility.Visible;
            //        ChangesArchive.Visibility = Visibility.Visible;

            //        addBandButton.Content = "Додати";
            //        addBandButton.Width = 200;
            //        addCriminalButton.Content = "Додати";
            //        addCriminalButton.Width = 200;
            //        ContextMenu cm1 = criminalsDataGrid.FindResource("rowContextMenu") as ContextMenu;
            //        (cm1.Items[0] as MenuItem).Header = "Редагувати";
            //        (cm1.Items[2] as MenuItem).Visibility = Visibility.Visible;

            //        ContextMenu cm2 = bandsDataGrid.FindResource("rowContextMenu") as ContextMenu;
            //        (cm2.Items[0] as MenuItem).Header = "Редагувати";


            //        ContextMenu cm3 = criminalsArchiveDataGrid.FindResource("rowContextMenu") as ContextMenu;
            //        (cm3.Items[0] as MenuItem).Header = "Редагувати";
            //        (cm3.Items[2] as MenuItem).Visibility = Visibility.Visible;
            //    }
            //}
        }
    }
}
