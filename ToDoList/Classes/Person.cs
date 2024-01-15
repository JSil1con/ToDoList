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

        public void AddEvent(string nameEvent, string dateTime)
        {
            _events.Add(nameEvent, new Event(nameEvent, DateTime.Parse(dateTime)));
        }

        public void AddEvent(string nameEvent, string dateTime, string priority)
        {
            _events.Add(nameEvent, new Event(nameEvent, DateTime.Parse(dateTime), priority));
        }

        public void EditEvent(Dictionary<string, string> eventInfo)
        {
            RemoveEvent(eventInfo["editedEvent"]);
            AddEvent(eventInfo["name"], eventInfo["dateTime"], eventInfo["priority"]);
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
