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
        private readonly FileStream _fileStream;
        private readonly StreamWriter _streamWriter;
        private readonly StreamReader _streamReader;

        public FileHandler(string path)
        {
            _path = path;

            _fileStream = File.Create(_path);

            _streamWriter = new StreamWriter(_fileStream);
            _streamReader = new StreamReader(_fileStream);
        }

        public static bool FileExists(string path)
        {
            if (File.Exists(path)) return true;
            return false;
        }

        public void InsertIntoFile(string content)
        {
            _streamWriter.Write(content);
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
            return _streamReader.ReadToEnd();
        }
    }
}
