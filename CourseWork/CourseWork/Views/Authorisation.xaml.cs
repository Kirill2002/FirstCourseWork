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
    /// Логика взаимодействия для Authorisation.xaml
    /// </summary>
    public partial class Authorisation : Window
    {
        public User User { get; protected set; }
        public Authorisation()
        {
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            Registration regWindow = new Registration();
            regWindow.Show();
        }

        private void authorisationButton_Click(object sender, RoutedEventArgs e)
        {
            UsersDatabase users_db = new UsersDatabase();
            users_db = (UsersDatabase)users_db.Load();

            usernameTextBoxBorder.Background = new SolidColorBrush(Colors.Transparent);
            passwordBoxBorder.Background = new SolidColorBrush(Colors.Transparent);

            usernameTextBox.ClearValue(TextBox.ToolTipProperty);
            passwordBox.ClearValue(PasswordBox.ToolTipProperty);

            int i = 0;
            for(i = 0; i < users_db.Users.Count; ++i)
            {
                if (users_db.Users[i].Username == usernameTextBox.Text)
                    break;
            }

            if (i == users_db.Users.Count)
            {
                usernameTextBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                usernameTextBox.ToolTip = "Невірне ім'я";
            }
            else
            {
                if (users_db.Users[i].Password == passwordBox.Password)
                {
                    this.DialogResult = true;
                    User = users_db.Users[i];
                    this.Close();
                }
                else
                {
                    passwordBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                    passwordBox.ToolTip = "Невірний пароль";
                }
            }
        }
    }
}
