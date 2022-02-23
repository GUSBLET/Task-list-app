using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Task_list_app.Service
{
    class FileIOService
    {
        private readonly string _PATH;
        private string _Description;
        private string _ListName;

        public string Path
        {
            get { return _PATH; }
        }
        public string Description
        {
            get { return _Description; }
        }
        public string ListName
        {
            get { return _ListName; }
        }

        public bool ExaminationEmptyTextBox(string unit)
        {
            return unit == string.Empty ? true : false;
        }

        public FileIOService(string path, string listName, string description)
        {
            _PATH = path;
            _ListName = listName;
            _Description = description;
        }      
        

       

        public void CreateData(FileIOService fileIOService)
        {
            using (StreamWriter writer = File.CreateText(_PATH + "/" + _ListName + "Main.json"))
            {
                
                var output = JsonConvert.SerializeObject(fileIOService);
                 writer.Write(output);
            }
            /*
            using (StreamWriter write = File.CreateText(_PATH ))
            {
                string output = JsonConvert.SerializeObject(write ,fileIOService);
                write.Write(output);
                
            }
            */
        }
    }
}
