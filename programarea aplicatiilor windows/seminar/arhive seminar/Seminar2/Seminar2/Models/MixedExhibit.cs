using Seminar2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2.Models
{
    public class MixedExhibit : Exhibit, IMixedExhibit {
        public bool HasGrass { get; set; }
        public bool HasFreshWater { get; set; }

        public MixedExhibit(int number, 
            string name, 
            int area,
            bool hasGrass, 
            bool hasFreshWater) : base(number, name, area) 
        {
            HasGrass = hasGrass;
            HasFreshWater = hasFreshWater;
        }

        public override void Clean() {
            if (HasFreshWater && HasGrass) {
                Console.WriteLine($"Ud iarba din habitatul {Number} cu cea pe care o schimb");
            }
            else {
                Console.WriteLine($"Ud iarba in habitatul {Number}");
                string tipApa = HasFreshWater ? "dulce" : "sarata";
                Console.WriteLine($"Schimb apa in habitatul {Number} care este {tipApa}");
            }
        }
    }
}
