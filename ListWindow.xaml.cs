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
using Newtonsoft.Json;

namespace Task_list_app
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        private string PathToList;
        private string ListName;
        public ListWindow(string Path, string Name)
        {
            InitializeComponent();
            PathToList = Path;
            ListName = Name;
        }

        private void MenuItem_ShowDescription(object sender, MouseEventArgs e)
        {
            new WindowDescription(PathToList, ListName).Show();
        }
    }
}
