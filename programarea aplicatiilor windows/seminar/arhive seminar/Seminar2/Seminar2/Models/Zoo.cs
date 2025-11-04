using System.Collections.Generic;
using System.Linq;

namespace Seminar2.Models
{
    public class Zoo
    {
        public List<Exhibit> Exhibits { get; set; }

        public Zoo() {
            Exhibits = new List<Exhibit>();
        }

        public void CleanZoo() {
            foreach (Exhibit exhibit in Exhibits.Where(x=>x.Area > 50).OrderByDescending(x=>x.Number)) {
                exhibit.Clean();
            }
        }
    }
}
