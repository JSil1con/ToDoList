using ToDoList.Classes;

string outputPath = "output.json";
string content = "";

if (FileHandler.FileExists(outputPath))
{
    content = FileHandler.Read(outputPath);
}

FileHandler fileHandler = new FileHandler(outputPath);

Console.WriteLine(content);


Console.ReadLine();