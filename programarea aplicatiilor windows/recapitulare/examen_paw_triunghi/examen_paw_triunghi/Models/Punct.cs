using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_triunghi
{
    [Serializable]
    public class Punct
    {
        public double X { get; }
        public double Y { get; }

        public Punct(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
