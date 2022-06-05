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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Task_list_app.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Task_list_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private FileIOService _fileIOService;
        //private ListWindow _listWindow;
        private ObservableCollection<Button_HistoryList> Buttons { get; set; } = new ObservableCollection<Button_HistoryList>();
        private bool CancelTheMatchСheck = false;
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists("DataList.json")) File.Create("DataList.json").Close(); CancelTheMatchСheck = true;
                            
            DataContext = new ApplicationViewModel();
            FileIOService fileIOService = new FileIOService();
            List<FileIOService> list = fileIOService.Read_ListDataBase();

            

        }

        
        // Open list from main json list
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            FileIOService unit = new FileIOService();
            List<FileIOService> list = unit.Read_ListDataBase();
            Button button = (Button)sender;
            DockPanel grid = (DockPanel)button.Parent;
            //Отсюда можно вытащить объект, закрепленный за элементом списка
            Object obj = (FileIOService)grid.DataContext;
            unit = (FileIOService)obj;
            
            //А отсюда сам индекс
            int index = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (unit.Path == list[i].Path) index = i;
            }

            new ListWindow(list[index].Path, list[index].ListName, list[index].Description).Show();

            Close();
        }


        //Button create new list
        private void Button_CreateList(object sender, RoutedEventArgs e)
        {
            bool ContinueExecution = true;

            FileIOService _obj = new FileIOService(TextBox_PathToList.Text, TextBox_NameList.Text, TextBox_Description.Text);

            SolidColorBrush CorrectInformation = new SolidColorBrush(Colors.Black);
            SolidColorBrush UncorrectInformation = new SolidColorBrush(Colors.Red);

            TextBox_Description.BorderBrush = CorrectInformation;
            TextBox_PathToList.BorderBrush = CorrectInformation;
            TextBox_NameList.BorderBrush = CorrectInformation;

            if (_obj.ExaminationEmptyTextBox(TextBox_NameList.Text))
            {
                TextBox_NameList.BorderBrush = UncorrectInformation;
                MessageBox.Show("Text box 'Enter name file' must be fill",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                ContinueExecution = false;
            }
            if (_obj.ExaminationEmptyTextBox(TextBox_PathToList.Text))
            {
                TextBox_PathToList.BorderBrush = UncorrectInformation;
                MessageBox.Show("Text box 'Path to list' must be fill",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                ContinueExecution = false;
            }
            if (_obj.ExaminationEmptyTextBox(TextBox_Description.Text))
            {
                TextBox_Description.BorderBrush = UncorrectInformation;
                MessageBox.Show("Text box 'Task description' must be fill",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                ContinueExecution = false;
            }


            if (ContinueExecution)
            {
                
                try
                {
                    
                    FileIOService buffer = new FileIOService(TextBox_PathToList.Text, TextBox_NameList.Text, TextBox_Description.Text);

                    // chek exists main list file
                    if (File.Exists("DataList.json"))
                    {
                        
                        
                        List<FileIOService> unit = _obj.Read_ListDataBase();

                        bool res = false;
                        if(unit == null) unit = new List<FileIOService>();
                        else
                        {
                            foreach (var item in unit)
                            {
                                if (item != buffer) res = true;
                            }
                        }
                        
                        if(res || CancelTheMatchСheck)
                        {

                            unit.Add(buffer);
                            _obj.Write_listDataBase(unit);

                            Directory.CreateDirectory(TextBox_PathToList.Text + TextBox_NameList.Text);
                            _obj.CreateData(_obj);
                            MessageBox.Show("List successful create",
                               ":)",
                               MessageBoxButton.OK);
                            new ListWindow(_obj.Path, _obj.ListName, _obj.Description).Show();

                            Close();
                        }
                        
                        else
                        {
                            MessageBox.Show(
                            "A list with the same name already exists ",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        }

                    }
                    
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }





        }


    }
}
 