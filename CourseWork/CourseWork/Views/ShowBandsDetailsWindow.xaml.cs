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
    /// Логика взаимодействия для ShowBandsDetailsWindow.xaml
    /// </summary>
    public partial class ShowBandsDetailsWindow : Window
    {
        public ShowBandsDetailsWindow(BandRecord band)
        {
            InitializeComponent();
            nameTextBlock.Text += "\n" + band.Name;
            occupationTextBlock.Text += "\n" + band.Occupation;
            listOfMembersTextBlock.Text += "\n" + band.MembersString;
            additionalInfoTextBlock.Text += "\n" + band.AdditionalInfo;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
