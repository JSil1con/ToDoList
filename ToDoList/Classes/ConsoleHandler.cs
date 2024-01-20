using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

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
            Console.WriteLine("4) View all tasks");
            Console.WriteLine("5) View tasks by name");
            Console.WriteLine("6) End");
            while (true)
            {
                bool success = true;
                string option = "";
                try
                {
                    option = Console.ReadLine();
                    Int32.Parse(option);
                }
                catch
                {
                    Console.WriteLine("It has to be number");
                    success = false;
                }
                if (success)
                { 
                    if (Int32.Parse(option) >= 0 && Int32.Parse(option) <= 6)
                    {
                        return option;
                    }
                    Console.WriteLine("Only 0/1/2/3/4/5 are allowed");
                }
            }
        }

        public static Dictionary<string, string> CreateEvent()
        {
            string dateTimeFormat = "dd.MM.yyyy HH:mm";

            Dictionary<string, string> eventInfo = new Dictionary<string, string>();

            Console.WriteLine("Type event's name");
            string name = "";
            while (true)
            {
                name = Console.ReadLine();
                if (name.Length > 0)
                {
                    break;
                }
                Console.WriteLine("Name can not be empty");
            }

            eventInfo.Add("name", name);

            Console.WriteLine("Type event's date (dd.MM.yyyy HH:mm)");
            string dateTime = "";
            while (true)
            {
                bool success = true;
                try
                {
                    dateTime = Console.ReadLine();
                    DateTime.ParseExact(dateTime, dateTimeFormat, CultureInfo.InvariantCulture);
                }
                catch
                {
                    success = false;
                }

                if (success)
                {
                    break;
                }
                Console.WriteLine("Correct format is: [dd.MM.yyyy HH:mm]");
            }         
            eventInfo.Add("dateTime", dateTime);

            Console.WriteLine("Type event's priority");
            string priority = "";
            string[] allowedPriorities = { "low", "medium", "high" };
            while (true)
            {
                priority = Console.ReadLine();
                if (priority.Length > 0)
                {
                    if (allowedPriorities.Contains(priority))
                    {
                        break;
                    }
                    Console.WriteLine("Only low/medium/high are allowed");
                }
                else
                {
                    Console.WriteLine("Priority can not be empty");
                }
            }
            eventInfo.Add("priority", priority);

            return eventInfo;
        }

        public static Dictionary<string, string> EditEvent(Person person)
        {
            Console.WriteLine("Type event's id you want to edit");
            string idEditedEvent = "";
            bool success = true;
            while (true)
            {
                idEditedEvent = Console.ReadLine();
                try
                {
                    Int32.Parse(idEditedEvent);
                }
                catch
                {
                    success = false;
                }

                if (success)
                {
                    if(person.EventExists(Int32.Parse(idEditedEvent)))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Event with this id doesn't exist");
                    }
                }
                else
                {
                    Console.WriteLine("Not valid id format");
                }
            }

            Dictionary<string, string> eventInfo = CreateEvent();
            eventInfo.Add("idEditedEvent", idEditedEvent);

            return eventInfo;
        }

        public static string RemoveEvent(Person person)
        {
            Console.WriteLine("Type event's id you want to delete");
            string idRemovedEvent = "";
            bool success = true;
            while (true)
            {
                idRemovedEvent = Console.ReadLine();
                try
                {
                    Int32.Parse(idRemovedEvent);
                }
                catch
                {
                    success = false;
                }

                if (success)
                {
                    if (person.EventExists(Int32.Parse(idRemovedEvent)))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Event with this id doesn't exist");
                    }
                }
                else
                {
                    Console.WriteLine("Not valid id format");
                }
            }
            return idRemovedEvent;
        }

        public static string GetEventsByName(Person person)
        {
            Console.WriteLine("Entry event's name you are looking for");
            string taskName = "";
            while (true)
            {
                taskName = Console.ReadLine();
                if (person.EventExists(taskName))
                {
                    return taskName;
                }
                Console.WriteLine("This event doesn't exist");
            }
        }
    }
}
