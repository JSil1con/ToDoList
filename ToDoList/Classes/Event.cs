﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Classes
{
    internal class Event
    {
        public string Name { get; set; }
        public string? Priority { get; set; }
        public DateTime Date { get; set; }

        public Event(string name, DateTime dateTime, string priority)
        {
            Name = name;
            Priority = priority;
            Date = dateTime;
        }

        public Event(string name, DateTime dateTime)
        {
            Name = name;
            Date = dateTime;
        }

        public void PrintEventInfo()
        {
            Console.WriteLine("name: {0} date: {1} priority {2}", Name, Date.ToString(), Priority);
        }
    }
}
