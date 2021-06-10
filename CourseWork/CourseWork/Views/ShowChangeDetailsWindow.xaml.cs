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
    /// Логика взаимодействия для ShowChangeDetailsWindow.xaml
    /// </summary>
    public partial class ShowChangeDetailsWindow : Window
    {
        private RecordChange change;

        public ShowChangeDetailsWindow(RecordChange recordChange)
        {
            InitializeComponent();

            change = recordChange;

            List<string> listOfProps = new List<string>();
            List<string> currentInfo = new List<string>(listOfProps.Count);
            List<string> prevInfo = new List<string>(listOfProps.Count);


            if (recordChange.To is BandRecord)
            {
                listOfProps = BandRecord.ListOfProperties;
                for (int i = 0; i < listOfProps.Count; ++i)
                {
                    currentInfo.Add("");
                    prevInfo.Add("");
                }


                BandRecord to = recordChange.To as BandRecord;
                BandRecord from = recordChange.From as BandRecord;
                if (recordChange.Type == ChangeType.Edit)
                {
                    for (int i = 0; i < prevInfo.Count; ++i)
                    {
                        prevInfo[i] = from[i];
                    }
                }

                for (int i = 0; i < currentInfo.Count; ++i)
                {
                    currentInfo[i] = to[i];
                }


            }
            else if (recordChange.To is CriminalRecord)
            {
                listOfProps = CriminalRecord.ListOfProperties;
                for (int i = 0; i < listOfProps.Count; ++i)
                {
                    currentInfo.Add("");
                    prevInfo.Add("");
                }

                CriminalRecord to = recordChange.To as CriminalRecord;
                CriminalRecord from = recordChange.From as CriminalRecord;
                if (recordChange.Type == ChangeType.Edit)
                {
                    for (int i = 0; i < prevInfo.Count; ++i)
                    {
                        prevInfo[i] = from[i];
                    }

                    if(from.Image != to.Image)
                    {
                        criminalImage.ToolTip = "До змін";
                        borderCriminalImage.BorderBrush = Constants.CHANGED_INFO_COLOR;
                    }
                }

                if (to.Image == "")
                {
                    criminalImage.Source = new BitmapImage(new Uri("/Images/default.jpeg", UriKind.Relative));
                }
                else
                {
                    criminalImage.Source = new BitmapImage(new Uri(to.Image, UriKind.Absolute));
                }
                

                for (int i = 0; i < currentInfo.Count; ++i)
                {
                    currentInfo[i] = to[i];
                }

                if (prevInfo[14] != currentInfo[14])
                {
                    languagesTextBlock.ToolTip = "До змін:\n" + prevInfo[14];
                    languagesTextBlock.Background = Constants.CHANGED_INFO_COLOR;
                }
                languagesTextBlock.Text = listOfProps[14] + "\n" + currentInfo[14];
                
            }

            {
                byte i = 1;
                foreach (FrameworkElement element in grid.Children)
                {
                    if (element is StackPanel && i < listOfProps.Count)
                    {
                        StackPanel sp = element as StackPanel;
                        foreach (FrameworkElement textBlock in sp.Children)
                        {
                            if(prevInfo[i] != currentInfo[i])
                            {
                                (textBlock as TextBlock).ToolTip = "До змін:\n" + prevInfo[i];
                                (textBlock as TextBlock).Background = Constants.CHANGED_INFO_COLOR;
                            }

                            (textBlock as TextBlock).Text = listOfProps[i] + ":\n" + currentInfo[i++];


                            Console.WriteLine((textBlock as TextBlock).Name);
                        }
                    }

                }


            }



        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void criminalImage_MouseEnter(object sender, MouseEventArgs e)
        {
            if(change.To is CriminalRecord && change.Type == ChangeType.Edit)
            {
                CriminalRecord from = change.From as CriminalRecord;
                if (from.Image == "")
                {
                    criminalImage.Source = new BitmapImage(new Uri("/Images/default.jpeg", UriKind.Relative));
                }
                else
                {
                    criminalImage.Source = new BitmapImage(new Uri(from.Image, UriKind.Absolute));
                }
                borderCriminalImage.BorderBrush = Brushes.Transparent;
            }
        }

        private void criminalImage_MouseLeave(object sender, MouseEventArgs e)
        {
            if (change.To is CriminalRecord && change.Type == ChangeType.Edit)
            {
                CriminalRecord to = change.To as CriminalRecord;
                if (to.Image == "")
                {
                    criminalImage.Source = new BitmapImage(new Uri("/Images/default.jpeg", UriKind.Relative));
                }
                else
                {
                    criminalImage.Source = new BitmapImage(new Uri(to.Image, UriKind.Absolute));
                }
                borderCriminalImage.BorderBrush = Constants.CHANGED_INFO_COLOR;
            }
        }
    }
}
