using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDoList.Classes
{
    internal class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Priority { get; set; }
        public DateTime Date { get; set; }

        [JsonConstructor]
        public Event(int id, string name, DateTime dateTime, string priority)
        {
            Id = id;
            Name = name;
            Priority = priority;
            Date = dateTime;
        }

        public void PrintEventInfo()
        {
            Console.WriteLine("id: {0} name: {1} date: {2} priority {3}", Id, Name, Date.ToString(), Priority);
        }
    }
}
