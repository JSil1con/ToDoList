using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoList.Classes
{
    internal class FileHandler
    {
        private readonly string _path;
        private readonly FileStream _file;

        public FileHandler(string name, string path)
        {
            _path = path;

            _file = File.Create(_path);
        }

        private bool FileExists()
        {
            if (File.Exists(_path)) return true;
            return false;
        }
    }
}
