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
    //person = new Person(ConsoleHandler.GetName());
}

//delete later
person = new Person(ConsoleHandler.GetName());

string option = ConsoleHandler.GetOptions();

if (option == "1")
{
    //Add task
    Dictionary<string, object> eventInfo = ConsoleHandler.CreateEvent();
    person.AddEvent((string)eventInfo["name"], (DateTime)eventInfo["dateTime"], (string)eventInfo["priority"]);
}
else if(option == "2")
{
    //Edit task
}
else if(option == "3")
{
    string nameEventToDelete = ConsoleHandler.RemoveEvent();
    person.RemoveEvent(nameEventToDelete);
}

FileHandler fileHandler = new FileHandler(outputPath);

Console.WriteLine(content);


Console.ReadLine();