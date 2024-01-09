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
        private Dictionary<string, Event> _events;

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, Dictionary<string, Event> events)
        {
            Name = name;
            _events = events;
        }
    }
}
