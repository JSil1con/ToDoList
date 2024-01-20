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
        string jsonResponse = FileHandler.Read(outputPath);
        person = JsonConvert.DeserializeObject<Person>(jsonResponse, jsonSettings);
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
        person.AddEvent(person.GetCountEvents() + 1, eventInfo);
        Console.Clear();
    }
    else if (option == "2")
    {
        //Edit task
        Dictionary<string, string> eventInfo = ConsoleHandler.EditEvent();
        person.EditEvent(eventInfo);
        Console.Clear();
    }
    else if (option == "3")
    {
        //Delete task
        string IdEventToDelete = ConsoleHandler.RemoveEvent();
        person.RemoveEvent(Int32.Parse(IdEventToDelete));
        Console.Clear();
    }
    else if (option == "4")
    {
        //View tasks
        person.ViewTasks();
    }
    else if (option == "5")
    {
        break;
    }
    fileHandler.Write(JsonConvert.SerializeObject(person, jsonSettings));   
}