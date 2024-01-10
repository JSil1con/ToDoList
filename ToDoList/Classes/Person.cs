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

        public void RemoveEvent(string nameEvent)
        {
            _events.Remove(nameEvent);
        }
    }
}
