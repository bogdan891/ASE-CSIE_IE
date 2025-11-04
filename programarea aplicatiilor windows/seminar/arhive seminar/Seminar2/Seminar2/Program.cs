using Seminar2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Exhibits.Add(new TerrestrialExhibit(1, "Habitat lei", 40, false));
            zoo.Exhibits.Add(new AquaticExhibit(2, "Habitat rechini", 500, false));
            zoo.Exhibits.Add(new MixedExhibit(3, "Habitat foci", 90, true, true));
            zoo.Exhibits.Add(new TerrestrialExhibit(4, "Habitat baribali", 100, true));

            zoo.CleanZoo();
        }
    }
}
