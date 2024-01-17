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
        private readonly StreamWriter _streamWriter;

        public FileHandler(string path)
        {
            _path = path;
        }

        public static bool FileExists(string path)
        {
            if (File.Exists(path)) return true;
            return false;
        }

        public void Write(string content)
        {
            using (StreamWriter writer = new StreamWriter(_path))
            {
                writer.Write(content);
            }
        }

        public static string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public static bool IsEmpty(string path)
        {
            if (new FileInfo(path).Length > 0) return false;
            return true;
        }

        public string Read()
        {
            return File.ReadAllText(_path);
        }
    }
}
