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
                //Validation
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
                bool success = Int32.TryParse(Console.ReadLine(), out int option);
                if (success)
                {
                    if (option >= 1 && option <= 8)
                    {
                        //Option is in the range
                        return option.ToString();
                    }
                    else
                    {
                        //Option is not in the range
                        Console.WriteLine("There is no option for " + option.ToString());
                    }
                }
                else
                {
                    //Given input isn't number
                    Console.WriteLine("Please enter the number");
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

                //Name validation - name can't be empty
                if (name.Length > 0)
                {
                    break;
                }

                //Name is empty
                Console.WriteLine("Name can not be empty");
            }

            eventInfo.Add("name", name);

            //Event' date
            Console.WriteLine("Type event's date (dd.MM.yyyy HH:mm)");
            DateTime dateTime;
            string dateTimeStr;
            while (true)
            {
                //Date validation
                dateTimeStr = Console.ReadLine();
                bool success = DateTime.TryParseExact(dateTimeStr, dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
                if (success)
                {
                    break;
                }
                else
                {
                    //Invalid format
                    Console.WriteLine("Enter the valid date (dd.MM.yyyy HH:mm)");
                }
            }         
            eventInfo.Add("dateTime", dateTimeStr);

            //Event' Priority
            Console.WriteLine("Type event's priority");
            string priority = "";
            string[] allowedPriorities = { "low", "medium", "high" };
            while (true)
            {
                priority = Console.ReadLine().ToLower();

                //Priority validation
                if (priority.Length > 0)
                {
                    if (allowedPriorities.Contains(priority))
                    {
                        //Priority accepted
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

        //Get edited event's id
        public static int GetIdEditedEvent(Person person)
        {
            Console.WriteLine("Type event's id you want to edit");
            while (true)
            {
                //Int validation
                bool success = Int32.TryParse(Console.ReadLine(), out int idEditedEvent);
                if (success)
                {
                    return idEditedEvent;
                }
                else
                {
                    //Input isn't int
                    Console.WriteLine("Not valid id format");
                }
            }
        }

        //Get info about edited event
        public static Dictionary<string, string> GetInfoEditedEvent(string idEditedEvent)
        {
            Dictionary<string, string> eventInfo = CreateEvent();
            eventInfo.Add("idEditedEvent", idEditedEvent);
            return eventInfo;
        }

        //Get removed event's id
        public static int GetIdRemovedEvent(Person person)
        {
            Console.WriteLine("Type event's id you want to delete");
            while (true)
            {
                //Int validation
                bool success = Int32.TryParse(Console.ReadLine(), out int idRemovedEvent);
                if (success)
                {
                    return idRemovedEvent;
                }
                else
                {
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
                bool success = DateTime.TryParseExact(Console.ReadLine(), dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDate);
                if (success)
                {
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
