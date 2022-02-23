using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_list_app.Model
{
    class TodoModel
    {
        private bool _IsDone;
        private string _Text;
        private string _Description;
        private string _Path;
        public DateTime CreationTime { get; set; } = DateTime.Now;

        public bool IsDone
        {
            get { return _IsDone; }
            set { _IsDone = value; }
        }
        public string Text 
        { 
            get { return _Text;} 
            set { _Text = value; }
        }
    }
}
