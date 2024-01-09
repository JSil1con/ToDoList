using ToDoList.Classes;
using System.IO;
using System.Reflection;

string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "output.json");

FileHandler fileHander = new FileHandler(path);


Console.ReadLine();