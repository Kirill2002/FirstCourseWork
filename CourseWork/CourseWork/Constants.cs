using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CourseWork
{
    public static class Constants
    {
        public const string DATABASE_PATH = "Data";
        public const string IMAGES_PATH = "Images";
        public static SolidColorBrush WRONG_INPUT_COLOR = new SolidColorBrush(Color.FromArgb(100, 255, 50, 1));
        public static SolidColorBrush CHANGED_INFO_COLOR = new SolidColorBrush(Color.FromArgb(100, 255, 50, 1));
    }
}
