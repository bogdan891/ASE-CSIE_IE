using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firme
{
    public class Produs
    {
        private int cod;
        private string denumire;
        private float pret;

        public Produs(int cod, string denumire, float pret)
        {
            this.cod = cod;
            this.denumire = denumire;
            this.pret = pret;
        }

        public int Cod { get => cod; set => cod = value; }
        public string Denumire { get => denumire; set => denumire = value; }
        public float Pret { get => pret; set => pret = value; }


        public static bool operator <(Produs p1, Produs p2)
        {
            return p1.Pret < p2.Pret;
        }

        public static bool operator >(Produs p1, Produs p2)
        {
            return !(p1<p2);
        }
        public override string ToString()
        {
            return "Produsul " + this.denumire + " are codul " + this.cod + " si pretul " + this.pret;
        }



    }
}
