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
    Console.WriteLine("Type your name");
    person = new Person(Console.ReadLine());
}

FileHandler fileHandler = new FileHandler(outputPath);

Console.WriteLine(content);


Console.ReadLine();