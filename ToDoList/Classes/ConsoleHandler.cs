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
            Console.WriteLine("4) View tasks");
            Console.WriteLine("5) End");
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
                    if (Int32.Parse(option) >= 0 && Int32.Parse(option) <= 5)
                    {
                        return option;
                    }
                    Console.WriteLine("Only 0/1/2/3/4/5 are allowed");
                }
            }
        }

        public static Dictionary<string, string> CreateEvent()
        {
            Dictionary<string, string> eventInfo = new Dictionary<string, string>();

            Console.WriteLine("Type event's name");
            eventInfo.Add("name", Console.ReadLine());

            Console.WriteLine("Type event's date (dd.MM.yyyy HH:mm:ss:)");
            eventInfo.Add("dateTime", Console.ReadLine());

            Console.WriteLine("Type event's priority (can be empty)");
            eventInfo.Add("priority", Console.ReadLine());

            return eventInfo;
        }

        public static Dictionary<string, string> EditEvent()
        {
            Console.WriteLine("Type event's id you want to delete");
            string idEditedEvent = Console.ReadLine();

            Dictionary<string, string> eventInfo = CreateEvent();
            eventInfo.Add("idEditedEvent", idEditedEvent);

            return eventInfo;
        }

        public static string RemoveEvent()
        {
            Console.WriteLine("Type event's id you want to delete");
            return Console.ReadLine();
        }
    }
}
