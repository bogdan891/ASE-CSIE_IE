using Seminar2.Interfaces;
using System;

namespace Seminar2.Models
{
    public class AquaticExhibit : Exhibit, IAquaticExhibit
    {
        public bool HasFreshWater { get; set; }

        public AquaticExhibit(int number, 
            string name, 
            int area, 
            bool hasFreshWater) : base(number, name, area) 
        {
            HasFreshWater = hasFreshWater;
        }

        public override void Clean() 
        {
            if (HasFreshWater == true) {
                Console.WriteLine($"Schimb apa dulce din habitatul {Number}");
            }
            else {
                Console.WriteLine($"Nu schimb apa in habitatul {Number} fiindca este sarata");
            }
        }
    }
}
