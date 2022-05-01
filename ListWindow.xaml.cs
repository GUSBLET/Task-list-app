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
using Task_list_app.Service;
using System.IO;


namespace Task_list_app
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        private FileIOService _obj;
        
         public ListWindow(string Path, string ListName, string Description)
        {
            InitializeComponent();
            _obj = new FileIOService(Path, ListName, Description);
        }

        private void MenuItem_ShowDescription(object sender, MouseEventArgs e)
        {
            new WindowDescription(_obj.Path, _obj.ListName, _obj.Description).Show();
        }

        private void Delete_list(object sender, MouseEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to delete the list?",
                "Delet list",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information);

            if(result == MessageBoxResult.OK)
            {
                //delete list in database
                List<FileIOService> list = _obj.Read_ListDataBase();

                bool res = false;
                int a = _obj.Find_listDataBase(list, _obj, ref res);
                list.RemoveAt(a);
                

                

                if(res)
                {
                    _obj.Write_listDataBase(list);
                    Directory.Delete(_obj.Path, true);

                    MessageBox.Show(
                        "Complite");
                    Close();
                }
                else
                {
                    MessageBox.Show(
                            "Error");
                }
            }
        }

        private void Close_list(object sender, MouseButtonEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
