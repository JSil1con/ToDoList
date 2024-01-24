using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.Serialization;

namespace ToDoList.Classes
{
    static class ConsoleHandler
    {
        //Get person's name
        public static string GetName()
        {
            Console.Write("Type your name => ");
            while (true)
            {
                string name = Console.ReadLine();
                if (name == null || name == "")
                {
                    Console.WriteLine("Name can't be empty");
                }
                else
                {
                    return name;
                }
            }
        }

        //Write all options to the console
        public static string GetOptions()
        {
            Console.WriteLine("1) Add task");
            Console.WriteLine("2) Edit task");
            Console.WriteLine("3) Remove task");
            Console.WriteLine("4) View all tasks");
            Console.WriteLine("5) View tasks by name");
            Console.WriteLine("6) View tasks by date");
            Console.WriteLine("7) View tomorrow tasks");
            Console.WriteLine("8) End");
            while (true)
            {
                //Validation
                bool success = true;
                string option = "";
                try
                {
                    option = Console.ReadLine();
                    Int32.Parse(option);
                }
                catch
                {
                    //Given input is string
                    success = false;
                }
                if (success)
                { 
                    if (Int32.Parse(option) >= 0 && Int32.Parse(option) <= 8)
                    {
                        return option;
                    }
                    //It is another number than allowed number
                    Console.WriteLine("Only 0/1/2/3/4/5/6/7 are allowed");
                }
            }
        }

        //Get informations about created event
        public static Dictionary<string, string> CreateEvent()
        {
            string dateTimeFormat = "dd.MM.yyyy HH:mm";

            Dictionary<string, string> eventInfo = new Dictionary<string, string>();

            //Event' name
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

            //Event' date
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

            //Event' Priority
            Console.WriteLine("Type event's priority");
            string priority = "";
            string[] allowedPriorities = { "low", "medium", "high" };
            while (true)
            {
                priority = Console.ReadLine().ToLower();
                if (priority.Length > 0)
                {
                    if (allowedPriorities.Contains(priority))
                    {
                        break;
                    }
                    //Another string than low/medium/high
                    Console.WriteLine("Only low/medium/high are allowed");
                }
                else
                {
                    //Input is empty
                    Console.WriteLine("Priority can not be empty");
                }
            }
            eventInfo.Add("priority", priority);

            return eventInfo;
        }

        //Get informations about edited event
        public static Dictionary<string, string> GetInfoAboutEdit(Person person)
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
                        //Event with given id doesn't exist
                        Console.WriteLine("Event with this id doesn't exist");
                    }
                }
                else
                {
                    //Input isn't int
                    Console.WriteLine("Not valid id format");
                }
            }

            Dictionary<string, string> eventInfo = CreateEvent();
            eventInfo.Add("idEditedEvent", idEditedEvent);

            return eventInfo;
        }

        //Get informations about removed event
        public static int GetIdRemovedEvent(Person person)
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
                    return Int32.Parse(idRemovedEvent);
                }
                else
                {
                    //Input isn't int
                    Console.WriteLine("Not valid id format");
                }
            }
        }

        //Get event's name
        public static string GetSearchedName(Person person)
        {
            Console.WriteLine("Entry event's name you are looking for");
            return Console.ReadLine();
        }

        //Get event's date
        public static DateTime GetSearchedDate(Person person)
        {
            Console.WriteLine("Entry event's date you are looking for (dd.MM.yyyy)");
            string dateTimeFormat = "dd.MM.yyyy";
            DateTime taskDate;
            //Validation
            while (true)
            {
                string taskDateString = Console.ReadLine();
                bool success = true;
                try
                {
                    DateTime.ParseExact(taskDateString, dateTimeFormat, CultureInfo.InvariantCulture);
                }
                catch
                {
                    success = false;
                }

                if (success)
                {
                    taskDate = DateTime.ParseExact(taskDateString, dateTimeFormat, CultureInfo.InvariantCulture);
                    return taskDate;
                }
                else
                {
                    Console.WriteLine("Enter the valid date");
                }
            }
        }
    }
}
