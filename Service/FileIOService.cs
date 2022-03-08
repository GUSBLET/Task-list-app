using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json;

namespace Task_list_app.Service
{
    class FileIOService
    {
        private string _PATH;
        private string _Description;
        private string _ListName;

        public string Path
        {
            get { return _PATH; }
            set { _PATH = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string ListName
        {
            get { return _ListName; }
            set { _ListName = value; }
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

        //Print data to label
        public void PrintData(FileIOService fileIOService)
        {

        }


        // Convert to jsoon format
        public void CreateData(FileIOService fileIOService)
        {
            using (StreamWriter writer = File.CreateText(_PATH + "/" + _ListName + "Main.json"))
            {
                
                var output = JsonConvert.SerializeObject(fileIOService);
                 writer.Write(output);
            }
        }
        
        //check availability list
        public void CreateListFile()
        {
            
        }

        // UnZip json in code
        public FileIOService UnPack(string PathToFile, string ListName)
        {
            using(var reader = File.OpenText(PathToFile + "/" + ListName + "Main.json"))
            {
                var fileText = reader.ReadToEnd();
                                
                return JsonConvert.DeserializeObject<FileIOService>(fileText);
            }
            
            
        }
    }
}
