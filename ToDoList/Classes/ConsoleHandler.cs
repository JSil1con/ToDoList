﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ToDoList.Classes
{
    static class ConsoleHandler
    {
        public static string GetName()
        {
            Console.Write("Type your name => ");
            return Console.ReadLine();
        }

        public static string GetOptions()
        {
            Console.WriteLine("1) Add task");
            Console.WriteLine("2) Edit task");
            Console.WriteLine("3) Remove task");
            return Console.ReadLine();
        }

        public static Dictionary<string, object> CreateEvent()
        {
            Dictionary<string, object> eventInfo = new Dictionary<string, object>();

            Console.WriteLine("Type event's name");
            eventInfo.Add("name", Console.ReadLine());

            Console.WriteLine("Type event's date (dd.MM.yyyy HH:mm:ss:)");
            eventInfo.Add("dateTime", DateTime.Parse(Console.ReadLine()));

            Console.WriteLine("Type event's priority (can be empty)");
            eventInfo.Add("priority", Console.ReadLine());

            return eventInfo;
        }

        public static Dictionary<string, object> EditEvent()
        {
            Console.WriteLine("Type event's name you want to delete");
            string editedEvent = Console.ReadLine();

            Dictionary<string, object> eventInfo = CreateEvent();
            eventInfo.Add("editedEvent", editedEvent);

            return eventInfo;
        }

        public static string RemoveEvent()
        {
            Console.WriteLine("Type event's name you want to delete");
            return Console.ReadLine();
        }
    }
}