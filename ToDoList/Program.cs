using ToDoList.Classes;

string outputPath = "output.json";
string content = "";
Person person;

FileHandler fileHandler = new FileHandler(outputPath);

while (true)
{

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
        Dictionary<string, object> eventInfo = ConsoleHandler.EditEvent();
        person.EditEvent(eventInfo);
    }
    else if(option == "3")
    {
        //Delete task
        string nameEventToDelete = ConsoleHandler.RemoveEvent();
        person.RemoveEvent(nameEventToDelete);
    }
    else if (option == "4")
    {
        //View tasks
        person.ViewTasks();
    }

    Console.WriteLine(content);

    Console.ReadLine();
}