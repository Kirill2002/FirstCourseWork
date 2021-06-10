using CourseWork.Models;
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
    /// Логика взаимодействия для ShowCriminalsDetailsWindow.xaml
    /// </summary>
    public partial class ShowCriminalsDetailsWindow : Window
    {
        public ShowCriminalsDetailsWindow(CriminalRecord criminal)
        {
            InitializeComponent();
            firstNameTextBlock.Text += "\n" + criminal.FirstName;
            lastNameTextBlock.Text += "\n" + criminal.LastName;
            nickNameTextBlock.Text += "\n" + criminal.NickName;
            heightTextBlock.Text += "\n" + criminal.Height;
            hairColorTextBlock.Text += "\n" + criminal.HairColor;
            eyeColorTextBlock.Text += "\n" + criminal.EyeColor;
            distinctiveFeaturesTextBlock.Text += "\n" + criminal.DistinctiveFeatures;
            citizenshipTextBlock.Text += "\n" + criminal.Citizenship;
            birthPlaceTextBlock.Text += "\n" + criminal.BirthPlace;
            birthDateTextBlock.Text += "\n" + criminal.BirthDate;
            lastDomicileTextBlock.Text += "\n" + criminal.LastDomicile;
            criminalSpecializationTextBlock.Text += "\n" + criminal.CriminalSpecialization;
            lastCaseTextBlock.Text += "\n" + criminal.LastCase;
            languagesTextBlock.Text += "\n" + criminal.Languages;

            if (criminal.Image == "")
            {
                criminalImage.Source = new BitmapImage(new Uri("/Images/default.jpeg", UriKind.Relative));
            }
            else
            {
                criminalImage.Source = new BitmapImage(new Uri(criminal.Image, UriKind.Absolute));
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                okButton.Visibility = Visibility.Hidden;
                printButton.Visibility = Visibility.Hidden;
                printDialog.PrintVisual(grid, "Print criminal");
                okButton.Visibility = Visibility.Visible;
                printButton.Visibility = Visibility.Visible;
            }

            okButton.Visibility = Visibility.Hidden;
            printButton.Visibility = Visibility.Hidden;
            

            RenderTargetBitmap renderTargetBitmap =
                 new RenderTargetBitmap(800, 800, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(grid);
            PngBitmapEncoder pngImage = new PngBitmapEncoder();
            pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            string path = Environment.CurrentDirectory + "\\" + Constants.IMAGES_PATH;

            using (Stream fileStream = File.Create(path + "\\" + Directory.GetFiles(path).Length.ToString() + ".png"))
            {
                pngImage.Save(fileStream);
            }

            okButton.Visibility = Visibility.Visible;
            printButton.Visibility = Visibility.Visible;
        }

    }
}
