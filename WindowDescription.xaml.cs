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
using Task_list_app.Service;

namespace Task_list_app
{
    /// <summary>
    /// Interaction logic for WindowDescription.xaml
    /// </summary>
    public partial class WindowDescription : Window
    {
        private FileIOService _obj;
        public WindowDescription(string Path, string ListName, string Description)
        {
            InitializeComponent();

            _obj = new FileIOService(Path, ListName, Description);


            Label_NameList.Content = _obj.ListName.ToString();
            Label_PathToList.Content = _obj.Path.ToString();
            Label_Description.Content = _obj.Description.ToString();

        }
        
        
    }
}
