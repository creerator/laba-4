using Helpers;
using System;
using System.Collections.Generic;
using DataManager;

namespace CalendarServices
{
    public class LoadService
    {
        public void Load(string command, int n)
        {
            ConsoleWrapper.WriteLine(Literals.load_dialog);

            n--;
            switch (command)
            {
                case "json":
                    LoadDataFromJson(n);
                    break;
                case "xml":
                    LoadDataFromXml(n);
                    break;
                case "sql":
                    LoadDataFromSql(n);
                    break;
                default:
                    ConsoleWrapper.WriteLine(Literals.unknow_command);
                    break;
            }
        }
        public void ShowFiles(string command)
        {
            ConsoleWrapper.WriteLine(Literals.load_dialog);

            switch (command)
            {
                case "json":
                    GetFilesFromCatalog($"{Literals.data_path}\\{"json_data"}");
                    break;
                case "xml":
                    GetFilesFromCatalog($"{Literals.data_path}\\{"xml_data"}");
                    break;
                case "sql":
                    List<string> files = SqlDataManager.GetFiles();
                    for (int i = 0; i < files.Count; i++)
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[i]);
                        ConsoleWrapper.WriteLine((i + 1).ToString() + ") " + fileNameWithoutExtension);
                    }
                    break;
                default:
                    ConsoleWrapper.WriteLine(Literals.unknow_command);
                    break;
            }
        }
        private void LoadDataFromJson(int n)
        {
            string file = GetFile("json_data", n);

            if (String.IsNullOrEmpty(file)) return;

            List<string> l = JsonDataManager.Load<List<string>>(file);

            foreach (string s in l) ConsoleWrapper.Write(s);
            ConsoleWrapper.WriteLine("");
        }
        
        private void LoadDataFromXml(int n)
        {
            string file = GetFile("xml_data", n);

            if (String.IsNullOrEmpty(file)) return;

            List<string> l = XmlDataManager.Load<List<string>>(file);

            foreach (string s in l) ConsoleWrapper.Write(s);
            ConsoleWrapper.WriteLine("");
        }

        private void LoadDataFromSql(int n)
        {
            ConsoleWrapper.WriteLine("");

            List<string> files = SqlDataManager.GetFiles();

            

            if (files == null)
            {
                ConsoleWrapper.WriteLine(Literals.empty_dir);
                return;
            }

            if (n > files.Count - 1 || n < 0)
            {
                ConsoleWrapper.WriteLine(Literals.file_not_found);
                return;
            }

            List<string> l = SqlDataManager.Load(files[n]);

            foreach (string s in l) ConsoleWrapper.Write(s);
            ConsoleWrapper.WriteLine("");
        }

        private string GetFile(string subfolder, int n)
        {
            ConsoleWrapper.WriteLine("");

            string[] files = GetFilesFromCatalog($"{Literals.data_path}\\{subfolder}");

            if (files == null)
            {
                ConsoleWrapper.WriteLine(Literals.empty_dir);
                return "";
            }

            if (n > files.Length - 1 || n < 0)
            {
                ConsoleWrapper.WriteLine(Literals.file_not_found);
                return "";
            }

            return files[n];
        }

        private string[] GetFilesFromCatalog(string path)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
            
                for(int i=0; i< files.Length; i++)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[i]);
                    ConsoleWrapper.WriteLine((i+1).ToString() + ") " + fileNameWithoutExtension);
                }
                return files;
            }
            else
            {
                return null;
            }

        }
    }
}
