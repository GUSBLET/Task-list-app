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
using Task_list_app.Model;
using System.ComponentModel;

namespace Task_list_app
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
         private FileIOService _obj;
         private BindingList<TodoModel> _todoDataList = new BindingList<TodoModel>();
        
         public ListWindow(string Path, string ListName, string Description)
         {
            InitializeComponent();
            _obj = new FileIOService(Path, ListName, Description);

            if (File.Exists(Path + ListName + '/' + ListName + "List.json"))
                _todoDataList = _obj.ReadList(_obj);
            else
                _obj.WriteList(_todoDataList, _obj);
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
                    Directory.Delete(_obj.Path+_obj.ListName, true);

                    MessageBox.Show(
                        "Complite");
                    new MainWindow().Show();
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
            var answer = MessageBox.Show("Do you want save list?", "", MessageBoxButton.YesNo);
            if(answer == MessageBoxResult.Yes)
            {
                _obj.WriteList(_todoDataList, _obj);
                new MainWindow().Show();
                Close();
            }
            else
            {
                new MainWindow().Show();
                Close();
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            dgTodoList.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += _todoDataList_ListChanged;
        }

        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();

            switch (e.ListChangedType)
            {
                case ListChangedType.Reset:
                    break;
                case ListChangedType.ItemAdded:
                    break;
                case ListChangedType.ItemDeleted:
                    break;
                case ListChangedType.ItemMoved:
                    break;
                case ListChangedType.ItemChanged:
                    break;
                case ListChangedType.PropertyDescriptorAdded:
                    break;
                case ListChangedType.PropertyDescriptorDeleted:
                    break;
                case ListChangedType.PropertyDescriptorChanged:
                    break;
                default:
                    break;
            }
        }

        private void Save_List(object sender, MouseButtonEventArgs e)
        {
            if (_obj.WriteList(_todoDataList, _obj))
                MessageBox.Show("File successfully save");
            
        }
    }
}
