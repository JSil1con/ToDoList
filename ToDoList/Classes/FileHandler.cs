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

        public FileHandler(string name, string path)
        {
            _path = path;

            _fileStream = File.Create(_path);

            _streamWriter = new StreamWriter(_fileStream);
            _streamReader = new StreamReader(_fileStream);
        }

        private bool FileExists()
        {
            if (File.Exists(_path)) return true;
            return false;
        }

        public void InsertIntoFile(string content)
        {
            _streamWriter.Write(content);
        }

        public string Read()
        {
            return _streamReader.ReadToEnd();
        }
    }
}
