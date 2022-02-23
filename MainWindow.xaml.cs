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



namespace Task_list_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private FileIOService _fileIOService;
        //private ListWindow _listWindow;
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            //_listWindow.Show();
            Close();
        }
        


        //Button create new list
        private void Button_CreateList(object sender, RoutedEventArgs e)
        {
            bool ContinueExecution = true;

            FileIOService _fileIOService = new FileIOService(TextBox_PathToList.Text, TextBox_NameList.Text, TextBox_Description.Text);

            SolidColorBrush CorrectInformation = new SolidColorBrush(Colors.Black);
            SolidColorBrush UncorrectInformation = new SolidColorBrush(Colors.Red);

            TextBox_Description.BorderBrush = CorrectInformation;
            TextBox_PathToList.BorderBrush = CorrectInformation;
            TextBox_NameList.BorderBrush = CorrectInformation;

            if (_fileIOService.ExaminationEmptyTextBox(TextBox_NameList.Text))
            {
                TextBox_NameList.BorderBrush = UncorrectInformation;
                MessageBox.Show("Text box 'Enter name file' must be fill",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                ContinueExecution = false;
            }
            if (_fileIOService.ExaminationEmptyTextBox(TextBox_PathToList.Text))
            {
                TextBox_PathToList.BorderBrush = UncorrectInformation;
                MessageBox.Show("Text box 'Path to list' must be fill",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                ContinueExecution = false;
            }
            if (_fileIOService.ExaminationEmptyTextBox(TextBox_Description.Text))
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
                    Directory.CreateDirectory(TextBox_PathToList.Text);
                    _fileIOService.CreateData(_fileIOService);
                    MessageBox.Show("List successful create",
                        ":)",
                        MessageBoxButton.OK);
                    new ListWindow(TextBox_PathToList.Text).Show();
                    
                    Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }





        }

        private void AddText(object sender, KeyEventArgs e)
        {
            
            if(e.Key == Key.Enter)
            {
                TextBox_PathToList.Text += TextBox_NameList.Text;   
            }
        }
    }
}
 