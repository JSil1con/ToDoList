using Newtonsoft.Json;
using System.Text.Json.Nodes;
using ToDoList.Classes;

string outputPath = "output.json";
Person person;

JsonSerializerSettings jsonSettings = new JsonSerializerSettings
{
    Formatting = Formatting.Indented
};


while (true)
{

    if (FileHandler.FileExists(outputPath) && !FileHandler.IsEmpty(outputPath))
    {
        Console.WriteLine(FileHandler.Read(outputPath));
        person = JsonConvert.DeserializeObject<Person>(FileHandler.Read(outputPath));
    }
    else
    {
        person = new Person(ConsoleHandler.GetName());
    }

    FileHandler fileHandler = new FileHandler(outputPath);

    string option = ConsoleHandler.GetOptions();

    if (option == "1")
    {
        //Add task
        Dictionary<string, string> eventInfo = ConsoleHandler.CreateEvent();
        person.AddEvent(eventInfo["name"], eventInfo["dateTime"], eventInfo["priority"]);
    }
    else if (option == "2")
    {
        //Edit task
        Dictionary<string, string> eventInfo = ConsoleHandler.EditEvent();
        person.EditEvent(eventInfo);
    }
    else if (option == "3")
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

    fileHandler.Write(JsonConvert.SerializeObject(person, jsonSettings));

    Console.ReadLine();
}