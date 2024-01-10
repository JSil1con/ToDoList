using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
