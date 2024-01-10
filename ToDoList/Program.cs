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

string option = ConsoleHandler.GetOptions();

if (option == "1")
{
    //Add task


}
else if(option == "2")
{
    //Edit task
}
else if(option == "3")
{
    //Remove task
}

FileHandler fileHandler = new FileHandler(outputPath);

Console.WriteLine(content);


Console.ReadLine();