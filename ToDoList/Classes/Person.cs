using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Classes
{
    internal class Person
    {
        public string Name { get; set; }
        private Dictionary<string, Event> _events = new Dictionary<string, Event>();

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, Dictionary<string, Event> events)
        {
            Name = name;
            _events = events;
        }

        public void AddEvent(string nameEvent, DateTime dateTime)
        {
            _events.Add(nameEvent, new Event(nameEvent, dateTime));
        }

        public void AddEvent(string nameEvent, DateTime dateTime, string priority)
        {
            _events.Add(nameEvent, new Event(nameEvent, dateTime, priority));
        }

        public void EditEvent(Dictionary<string, object> eventInfo)
        {
            RemoveEvent((string)eventInfo["editedEvent"]);
            AddEvent((string)eventInfo["name"], (DateTime)eventInfo["dateTime"], (string)eventInfo["priority"]);
        }

        public void RemoveEvent(string nameEvent)
        {
            _events.Remove(nameEvent);
        }

        public void ViewTasks()
        {
            foreach (Event item in _events.Values)
            {
                item.PrintEventInfo();
                Console.WriteLine("test");
            }
        }
    }
}
