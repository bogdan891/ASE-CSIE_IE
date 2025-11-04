using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace seminar_2_paw.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Activity> Activities { get; set; }

        public Student(string name, int age)
        {
            Name = name;        
            Age = age;
            Activities = new List<Activity>();
        }

        public void Display()
        {
            Console.WriteLine($"Student {Name} has activites: ");
            foreach (var activity in Activities.Where(x => x.Duration <= 4).OrderBy(x => x.Name))
            {
                Console.WriteLine($"\t{activity.Name} for {activity.Duration} hours.");
            }
        }
    }
}
