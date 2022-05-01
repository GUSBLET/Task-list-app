using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Task_list_app.Service;
using System;
using System.IO;

namespace Task_list_app
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        FileIOService fileIOService = new FileIOService();
        private FileIOService selectedLists;

        public List<FileIOService> Lists { get; set; }
        public FileIOService SelectedLists
        {
            get { return selectedLists; }
            set
            {
                selectedLists = value;
                OnPropertyChanged("SelectedLists");
            }
        }

        public ApplicationViewModel()
        {
            
            Lists = fileIOService.Read_ListDataBase();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
