using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComenziPizza
{
    public class Topping
    {
        private readonly int cod;
        private string denumire;
        private float pret;
        private float cantitate;

        public Topping(int cod, string denumire, float pret, float cantitate)
        {
            this.cod = cod;
            this.denumire = denumire;
            this.pret = pret;
            this.cantitate = cantitate;
        }

        public int Cod => cod;

        public string Denumire { get => denumire; set => denumire = value; }
        public float Pret { get => pret; set => pret = value; }
        public float Cantitate { get => cantitate; set => cantitate = value; }


        public override string ToString()
        {
            return this.cod + " " + this.denumire + " " + this.pret + " " + this.cantitate;
        }
    }
}
