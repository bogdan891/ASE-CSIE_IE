using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_2_paw.Models
{
    public class Activity
    {
        //private string _name;

        /*
        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }
        */

       // public string Name { get { return _name; } set { _name = value; } }

        public string Name { get; set; }
        public int Duration { get; set; }

        public Activity(string name, int duration)
        {
            Name = name;
            Duration = duration;
        }
    }
}
