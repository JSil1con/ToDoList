using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToDoList.Classes
{
    internal class Person
    {
        public string Name { get; set; }
        public Dictionary<int, Event> Events { get; set; } = new Dictionary<int, Event>();

        public Person(string name)
        {
            Name = name;
        }

        [JsonConstructor]
        public Person(string name, Dictionary<int, Event> events)
        {
            Name = name;
            Events = events;
        }

        //Add event to events dictionary
        public void AddEvent(int id, Dictionary<string, string> eventInfo)
        {
            string dateTimeFormat = "dd.MM.yyyy HH:mm";
            Events.Add(id, new Event(id, eventInfo["name"], DateTime.ParseExact(eventInfo["dateTime"], dateTimeFormat, CultureInfo.InvariantCulture), eventInfo["priority"]));
        }

        //Edit event - delete event than add it
        public void EditEvent(Dictionary<string, string> eventInfo)
        {
            RemoveEvent(Int32.Parse(eventInfo["idEditedEvent"]));
            AddEvent(Int32.Parse(eventInfo["idEditedEvent"]), eventInfo);
        }

        //Remove event from dictionary
        public void RemoveEvent(int idEvent)
        {
            Events.Remove(idEvent);
        }

        //View all events sorted by a date
        public void ViewAllEvents()
        {
            List<Event> sortedEvents = Events.Values.OrderBy(x => x.Date).ToList();
            foreach (Event item in sortedEvents)
            {
                item.PrintEventInfo();
            }
        }

        //View only tomorrow events
        public void ViewTomorrowEvents()
        {
            DateTime today = DateTime.Now;
            DateTime tomorrow = today.AddDays(1);

            //List only tomorrow events
            List<Event> tomorrowEvents = Events.Values
                .Where(x => x.Date.Date == tomorrow.Date)
                .OrderBy(x => x.Date)
                .ToList();

            if (tomorrowEvents.Count == 0)
            {
                //There are no events
                Console.WriteLine("No events scheduled for tomorrow");
            }
            else
            {
                //There are events
                foreach (var item in tomorrowEvents)
                {
                    item.PrintEventInfo();
                }
            }
        }

        //View events by given date
        public void ViewEventsByDate(DateTime searchedDate)
        {
            foreach (var item in Events)
            {
                if (new DateTime(item.Value.Date.Year, item.Value.Date.Month, item.Value.Date.Day) == searchedDate.Date)
                {
                    item.Value.PrintEventInfo();
                }
            }
        }

        //Return count of events
        public int GetCountEvents()
        {
            return Events.Count;
        }

        //Checks if event exists
        public bool EventExists<T>(T parameter)
        {
            // Checks if input is string (event's name) or int (event's id)
            Type parameterType = parameter.GetType();

            if (parameterType == typeof(int))
            {
                //It is int
                int id = Int32.Parse(parameter.ToString());
                if (Events.ContainsKey(id)) return true;
                return false;
            }
            else if (parameterType == typeof(string))
            {
                //It is string
                string name = parameter.ToString();
                foreach (KeyValuePair<int, Event> kvpEvent in Events)
                {
                    if (kvpEvent.Value.Name == name)
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (parameterType == typeof(DateTime))
            {
                //It is datetime
                DateTime eventsDate = (DateTime)(object)parameter;

                List<Event> searchedEvents = new List<Event>();

                foreach (var item in Events)
                {
                    if (item.Value.Date.Date == eventsDate)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        // View events by name
        public void ViewEventsByName(string name)
        {
            foreach (Event item in Events.Values)
            {
                if (item.Name == name)
                {
                    item.PrintEventInfo();
                }
            }
        }
    }
}
