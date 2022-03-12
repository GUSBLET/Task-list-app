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

        private void Delete_list(object sender, MouseEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to delete the list?",
                "Delet list",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information);

            if(result == MessageBoxResult.OK)
            {
                FileIOService fileIOService = new FileIOService();

                //delete list in database
                List<string> list = fileIOService.Read_ListDataBase();
                fileIOService.Delet_ListDataBase(list, PathToList);
                fileIOService.Write_listDataBase(list);
                

                Directory.Delete(PathToList, true);

                MessageBox.Show(
                    "Complite");
            }
        }

        private void Close_list(object sender, MouseButtonEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
