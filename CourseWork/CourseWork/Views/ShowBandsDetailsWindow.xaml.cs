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
