using seminar_2_paw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_2_paw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Activity paw = new Activity("Paw", 2);
            Activity java = new Activity("Java", 3);
            Activity oop = new Activity("OOP", 4);
            //activity.Name = "PAW";
            //Console.WriteLine($"Name: {activity.Name} | Duration: {activity.Duration} ");
            //Console.ReadKey();

            Student george = new Student("George", 21);
            Student ioana = new Student("Ioana", 22);

            george.Activities.Add(paw);
            george.Activities.Add(oop);

            ioana.Activities.Add(paw);
            ioana.Activities.Add(java);
            ioana.Activities.Add(oop);

            ioana.Display();
        }
    }
}
