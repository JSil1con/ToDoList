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

        public void AddEvent(int id, Dictionary<string, string> eventInfo)
        {
            string dateTimeFormat = "dd.MM.yyyy HH:mm";
            Events.Add(id, new Event(id, eventInfo["name"], DateTime.ParseExact(eventInfo["dateTime"], dateTimeFormat, CultureInfo.InvariantCulture), eventInfo["priority"]));
        }

        public void EditEvent(Dictionary<string, string> eventInfo)
        {
            RemoveEvent(Int32.Parse(eventInfo["idEditedEvent"]));
            AddEvent(Int32.Parse(eventInfo["idEditedEvent"]), eventInfo);
        }

        public void RemoveEvent(int idEvent)
        {
            Events.Remove(idEvent);
        }

        public void ViewAllEvents()
        {
            List<Event> sortedEvents = Events.Values.OrderBy(x => x.Date).ToList();
            foreach (Event item in sortedEvents)
            {
                item.PrintEventInfo();
            }
        }

        public void ViewTomorrowEvents()
        {
            DateTime today = DateTime.Now;
            DateTime tomorrow = today.AddDays(1);

            List<Event> tomorrowEvents = Events.Values
                .Where(x => x.Date.Date == tomorrow.Date)
                .OrderBy(x => x.Date)
                .ToList();

            if (tomorrowEvents.Count == 0)
            {
                Console.WriteLine("No events scheduled for tomorrow");
            }
            else
            {
                foreach (var item in tomorrowEvents)
                {
                    item.PrintEventInfo();
                }
            }
        }

        public int GetCountEvents()
        {
            return Events.Count;
        }

        public bool EventExists<T>(T parameter)
        {
            Type parameterType = parameter.GetType();

            if (parameterType == typeof(int))
            {
                int id = (int)(object)parameter;
                if (Events.ContainsKey(id)) return true;
                return false;
            }
            else if (parameterType == typeof(string))
            {
                string name = (string)(object)parameter;
                foreach (KeyValuePair<int, Event> kvpEvent in Events)
                {
                    if (kvpEvent.Value.Name == name)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

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
