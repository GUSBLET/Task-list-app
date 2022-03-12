using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json;
using System.ComponentModel;

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
            using (StreamWriter writer = File.CreateText(fileIOService.Path + "/" + fileIOService.ListName + "Main.json"))
            {
                var output = JsonConvert.SerializeObject(fileIOService);
                writer.Write(output);
            }
        }
        
        //check availability list
        public void Write_listDataBase(List<string> list)
        {
            using (StreamWriter writer = File.CreateText("DataList.json"))
            {
                string output = JsonConvert.SerializeObject(list);
                writer.Write(output);
            }
        }

        //read list database
        public List<string> Read_ListDataBase()
        {
            using (StreamReader reader = File.OpenText("DataList.json"))
            {
                var fileText = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<List<string>>(fileText);
            }           
        }

        //delete list in database
        public List<string> Delet_ListDataBase(List<string> list, string unit)
        {
            list.Remove(unit);
            return list;
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
