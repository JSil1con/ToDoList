using ToDoList.Classes;

string outputPath = "output.json";
string content = "";
Person person;

if (FileHandler.FileExists(outputPath) && !FileHandler.IsEmpty(outputPath))
{
    content = FileHandler.Read(outputPath);
}
else
{
    person = new Person(ConsoleHandler.GetName());
}

FileHandler fileHandler = new FileHandler(outputPath);

Console.WriteLine(content);


Console.ReadLine();