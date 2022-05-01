using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Task_list_app.Service
{
    public class Button_HistoryList
    {
        private string _ListName;
        private string _ListDescription;
        private string _ListPath;

        public string ListName
        {
            get { return _ListName; }
            set { _ListName = value; }
        }

        public string ListDescription
        {
            get { return _ListDescription; }
            set { _ListDescription = value; }
        }
        public string ListPath 
        {
            get { return _ListPath; }
            set { _ListPath = value; }
        }

        public Button_HistoryList()
        {

        }

        
         
    }
}
