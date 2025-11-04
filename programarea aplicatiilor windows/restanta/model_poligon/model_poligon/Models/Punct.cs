using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_paw_poligon.Models
{
    [Serializable]
    public class Punct
    {
        private float x;
        private float y;

        public float X
        {
            get => x;
            set => x = value;
        }

        public float Y
        {
            get => y;
            set => y = value;
        }

        public Punct() { }
        public Punct(float x, float y)
        {
            this.x = x;
            this.y = y;
        }   

        public static double Distanta(Punct a, Punct b)
        {
            return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
        }

        public override string ToString() 
        {
            return $"{X},{Y}";
        }

    }
}
