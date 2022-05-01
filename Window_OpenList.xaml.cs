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
    /// Interaction logic for Window_OpenList.xaml
    /// </summary>
    public partial class Window_OpenList : Window
    {
        public Window_OpenList()
        {
            InitializeComponent();
            FileIOService fileIOService = new FileIOService();
            List<FileIOService> list = fileIOService.Read_ListDataBase();

            
        }
    }
}
