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
        public Dictionary<int, Event> Events { get; set; } = new Dictionary<int, Event>();

        public Person(string name)
        {
            Name = name;
        }

        [JsonConstructor]
        public Person(string name, Dictionary<int, Event> events)
        {
            Name = name;
            Events = events;
        }

        public void AddEvent(int id, Dictionary<string, string> eventInfo)
        {
            string dateTimeFormat = "dd.MM.yyyy HH:mm";
            Events.Add(id, new Event(id, eventInfo["name"], DateTime.ParseExact(eventInfo["dateTime"], dateTimeFormat, CultureInfo.InvariantCulture), eventInfo["priority"]));
        }

        public void EditEvent(Dictionary<string, string> eventInfo)
        {
            RemoveEvent(Int32.Parse(eventInfo["idEditedEvent"]));
            AddEvent(Int32.Parse(eventInfo["idEditedEvent"]), eventInfo);
        }

        public void RemoveEvent(int idEvent)
        {
            Events.Remove(idEvent);
        }

        public void ViewTasks()
        {
            foreach (Event item in Events.Values)
            {
                item.PrintEventInfo();
            }
        }

        public int GetCountEvents()
        {
            return Events.Count;
        }
    }
}
