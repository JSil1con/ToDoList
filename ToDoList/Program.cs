using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Nodes;
using ToDoList.Classes;

string outputPath = "output.json";
Person? person;

// Json settings
JsonSerializerSettings jsonSettings = new JsonSerializerSettings
{
    Formatting = Formatting.Indented
};


while (true)
{
    //Checks if file already exists, if it doesn't - create the person
    if (FileHandler.FileExists(outputPath) && !FileHandler.IsEmpty(outputPath))
    {
        string jsonResponse = FileHandler.Read(outputPath);
        person = JsonConvert.DeserializeObject<Person>(jsonResponse, jsonSettings);

        if (person  == null)
        {
            person = new Person(ConsoleHandler.GetName());
        }
    }
    else
    {
        person = new Person(ConsoleHandler.GetName());
    }

    //Create the file
    FileHandler fileHandler = new FileHandler(outputPath);

    string option = ConsoleHandler.GetOptions();

    if (option == "1")
    {
        //Add task

        //Get information about added event
        Dictionary<string, string> eventInfo = ConsoleHandler.CreateEvent();
        person.AddEvent(person.GetCountEvents() + 1, eventInfo);
    }
    else if (option == "2")
    {
        //Edit task

        //Get information about edited event
        int eventEditedId = ConsoleHandler.GetIdEditedEvent();
        if (person.EventExists(eventEditedId))
        {
            Dictionary<string, string> infoEditedEvent = ConsoleHandler.GetInfoEditedEvent(eventEditedId.ToString());
            person.EditEvent(infoEditedEvent);
        }
        else
        {
            Console.WriteLine("Event doesn't exist");
        }    
    }
    else if (option == "3")
    {
        //Delete task

        //Get information about deleted event
        int IdEventToDelete = ConsoleHandler.GetIdRemovedEvent();

        //Checks if event exists
        if (person.EventExists(IdEventToDelete))
        {
            //If it exists remove it
            person.RemoveEvent(IdEventToDelete);
        }
        else
        {
            //If it doesn't exist
            Console.WriteLine("Event doesn't exist");
        }
    }
    else if (option == "4")
    {
        //View all tasks
        person.ViewAllEvents();
    }
    else if (option == "5")
    {
        //View tasks by name

        //Get information about viewed event
        string taskName = ConsoleHandler.GetSearchedName();

        //Checks if event exists
        if (person.EventExists(taskName))
        {
            //View events by name
            person.ViewEventsByName(taskName);
        }
        else
        {
            //Events with given name don't exist
            Console.WriteLine("Event doesn't exist");
        }
    }
    else if (option == "6")
    {
        //Search events by date

        DateTime searchedDate = ConsoleHandler.GetSearchedDate();

        //Checks if event exists
        if (person.EventExists(searchedDate))
        {
            //View events by date
            person.ViewEventsByDate(searchedDate);
        }
        else
        {
            //Events with given date don't exist
            Console.WriteLine("Event doesn't exist");
        }
    }
    else if (option == "7")
    {
        //View tomorrow events
        person.ViewTomorrowEvents();
    }
    else if (option == "8")
    {
        //End the program
        break;
    }

    //Save person to the json file
    fileHandler.Write(JsonConvert.SerializeObject(person, jsonSettings));

    //Enter to continue
    Console.WriteLine("Press Enter to continue");
    Console.Read();
    Console.Clear();
}