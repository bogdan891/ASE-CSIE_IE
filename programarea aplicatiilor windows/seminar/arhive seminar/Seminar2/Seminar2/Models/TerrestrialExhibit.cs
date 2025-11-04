using Seminar2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2.Models
{
    public class TerrestrialExhibit : Exhibit, ITerrestrialExhibit
    {
        public bool HasGrass { get; set; }

        public TerrestrialExhibit(int number, 
            string name, 
            int area, 
            bool hasGrass) : base(number, name, area) 
        {
            HasGrass = hasGrass;
        }

        public override void Clean() 
        {
            Console.WriteLine($"Dau cu grebla pe {Area} in habitatul terestru numarul {Number}");
        }
    }
}
