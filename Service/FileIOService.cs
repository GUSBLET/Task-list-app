using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task_list_app.Model;

namespace Task_list_app.Service
{
    class FileIOService : INotifyPropertyChanged
    {
        private string _ListName;
        private string _PATH;
        private string _Description;


        public string Path
        {
            get { return _PATH; }
            set
            {
                _PATH = value + _ListName;
                OnPropertyChanged("Path");
            }
        }
        public string ListName
        {
            get { return _ListName; }
            set 
            {
                _ListName = value;
                OnPropertyChanged("ListName");
            }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        //Сheck for emptiness 
        public bool ExaminationEmptyTextBox(string unit)
        {
            return unit == string.Empty ? true : false;
        }



        // class constructor 
        public FileIOService(string path, string listName, string description)
        {
            _PATH = path;
            _ListName = listName;
            _Description = description;
        }

        public FileIOService()
        {

        }

        
        // Convert to jsoon format
        public void CreateData(FileIOService fileIOService)
        {
            using (StreamWriter writer = File.CreateText(fileIOService.Path + fileIOService.ListName + '/' + fileIOService.ListName + "Main.json"))
            {
                var output = JsonConvert.SerializeObject(fileIOService);
                writer.Write(output);
            }
        }
        
        //check availability path list
        public void Write_listDataBase(List<FileIOService> list)
        {
            using (StreamWriter writer = File.CreateText("DataList.json"))
            {
                string output = JsonConvert.SerializeObject(list);
                writer.Write(output);
            }
        }

        //read list path database
        public List<FileIOService> Read_ListDataBase()
        {
            using (StreamReader reader = File.OpenText("DataList.json"))
            {
                var fileText = reader.ReadToEnd();
                
                return JsonConvert.DeserializeObject<List<FileIOService>>(fileText);
            }           
        }
        

        //I find element in DB
        public int Find_listDataBase(List<FileIOService> list, FileIOService fileIOService, ref bool result)
        {
            int id = 0;
            for(int i = 0; i < list.Count;i++)
            {
                if (list[i].ListName == fileIOService.ListName)
                {
                    result = true;
                    id = i;
                }
            }
            return id;
        }


        // Read list
        public BindingList<TodoModel> ReadList(FileIOService fileIOService)
        {
            using (StreamReader reader = File.OpenText(fileIOService.Path + fileIOService.ListName + '/' + fileIOService.ListName + "List.json"))
            {
                var fileText = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
            }
        }


        public bool WriteList(BindingList<TodoModel> list, FileIOService fileIOService)
        {
            bool result = false;
            using (StreamWriter writer = File.CreateText(fileIOService.Path + fileIOService.ListName + '/' + fileIOService.ListName + "List.json"))
            {
                string output = JsonConvert.SerializeObject(list);
                writer.Write(output);
                result = true; 
            }
            return result;
        }

        public bool ChekListFile(FileIOService fileIOService)
        {
            return File.Exists(fileIOService.Path);
        }


        //// UnZip json in code
        //public FileIOService UnPack(string PathToFile, string ListName)
        //{
        //    using(var reader = File.OpenText(PathToFile + "/" + ListName + "Main.json"))
        //    {
        //        var fileText = reader.ReadToEnd();
        //        return JsonConvert.DeserializeObject<FileIOService>(fileText);
        //    }
            
            
        //}
    }
}
