using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToDoList.Classes
{
    internal class Person
    {
        public string Name { get; set; }
        public Dictionary<string, Event> Events { get; set; } = new Dictionary<string, Event>();

        public Person(string name)
        {
            Name = name;
        }

        [JsonConstructor]
        public Person(string name, Dictionary<string, Event> events)
        {
            Name = name;
            Events = events;
        }

        public void AddEvent(string nameEvent, string dateTime, string priority)
        {
            string dateTimeFormat = "dd.MM.yyyy HH:mm:ss";
            Events.Add(nameEvent, new Event(nameEvent, DateTime.ParseExact(dateTime, dateTimeFormat, CultureInfo.InvariantCulture), priority));
        }

        public void EditEvent(Dictionary<string, string> eventInfo)
        {
            RemoveEvent(eventInfo["editedEvent"]);
            AddEvent(eventInfo["name"], eventInfo["dateTime"], eventInfo["priority"]);
        }

        public void RemoveEvent(string nameEvent)
        {
            Events.Remove(nameEvent);
        }

        public void ViewTasks()
        {
            foreach (Event item in Events.Values)
            {
                item.PrintEventInfo();
                Console.WriteLine("test");
            }
        }
    }
}
