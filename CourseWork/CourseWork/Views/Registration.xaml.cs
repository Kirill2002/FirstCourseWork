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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            accessCodeTextBoxBorder.Background = new SolidColorBrush(Colors.Transparent);
            usernameTextBoxBorder.Background = new SolidColorBrush(Colors.Transparent);
            passwordBoxBorder.Background = new SolidColorBrush(Colors.Transparent);
            repeatPasswordBoxBorder.Background = new SolidColorBrush(Colors.Transparent);
            

            accessCodeTextBox.ClearValue(TextBox.ToolTipProperty);
            usernameTextBox.ClearValue(TextBox.ToolTipProperty);
            passwordBox.ClearValue(PasswordBox.ToolTipProperty);
            repeatPasswordBox.ClearValue(PasswordBox.ToolTipProperty);

            if(accessCodeTextBox.Text == "12345678")
            {
                UsersDatabase usersDB = new UsersDatabase();
                usersDB = (UsersDatabase)usersDB.Load();
                int i = 0;
                for(i = 0; i < usersDB.Users.Count; ++i)
                {
                    if (usersDB.Users[i].Username == usernameTextBox.Text)
                        break;
                }
                if(i == usersDB.Users.Count &&  usernameTextBox.Text.Length >= 1)
                {
                    if(passwordBox.Password.Length < 8)
                    {
                        passwordBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                        passwordBox.ToolTip = "Занадто короткий пароль";
                    }else if(passwordBox.Password != repeatPasswordBox.Password)
                    {
                        repeatPasswordBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                        repeatPasswordBox.ToolTip = "Паролі не співпадають";
                    }else
                    {
                        usersDB.Users.Add(new User(usernameTextBox.Text, passwordBox.Password, UserRole.Admin));
                        usersDB.Save();
                        this.Close();
                    }
                }else if(usernameTextBox.Text.Length == 0)
                {
                    usernameTextBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                    usernameTextBox.ToolTip = "Щонайменше 1 символ";
                }else
                {
                    usernameTextBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                    usernameTextBox.ToolTip = "Таке ім'я вже існує";
                }
            }else if(accessCodeTextBox.Text == "11111111")
            {
                UsersDatabase usersDB = new UsersDatabase();
                usersDB = (UsersDatabase)usersDB.Load();
                int i = 0;
                for (i = 0; i < usersDB.Users.Count; ++i)
                {
                    if (usersDB.Users[i].Username == usernameTextBox.Text)
                        break;
                }
                if (i == usersDB.Users.Count && usernameTextBox.Text.Length >= 1)
                {
                    if (passwordBox.Password.Length < 8)
                    {
                        passwordBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                        passwordBox.ToolTip = "Занадто короткий пароль";
                    }
                    else if (passwordBox.Password != repeatPasswordBox.Password)
                    {
                        repeatPasswordBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                        repeatPasswordBox.ToolTip = "Паролі не співпадають";
                    }
                    else
                    {
                        usersDB.Users.Add(new User(usernameTextBox.Text, passwordBox.Password, UserRole.User));
                        usersDB.Save();
                        this.Close();
                    }
                }else if (usernameTextBox.Text.Length == 0)
                {
                    usernameTextBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                    usernameTextBox.ToolTip = "Щонайменше 1 символ";
                }else
                {
                    usernameTextBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                    usernameTextBox.ToolTip = "Таке ім'я вже існує";
                }
            }
            else
            {
                accessCodeTextBoxBorder.Background = Constants.WRONG_INPUT_COLOR;
                accessCodeTextBox.ToolTip = "Невірний код";
            }
        }
    }
}
