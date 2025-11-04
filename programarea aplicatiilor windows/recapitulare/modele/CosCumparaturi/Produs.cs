using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosCumparaturi
{
    public class Produs
    {
        private int id;
        private string denumire;
        private int cantitate;
        private float pret;

        public Produs(int id, string denumire, int cantitate, float pret)
        {
            this.id = id;
            this.denumire = denumire;
            this.cantitate = cantitate;
            this.pret = pret;
        }

        public int Id_produs { get => id; set => id = value; }
        public string Denumire { get => denumire; set => denumire = value; }
        public int Cantitate { get => cantitate; set => cantitate = value; }
        public float Pret { get => pret; set => pret = value; }

        public float Valoare { get => pret * cantitate;}

        public override string ToString()
        {
            return "Produsul cu codul " + this.id + " are denumirea " + this.denumire + " pretul pe bucata de " + this.pret + " si urmeaza sa fie comandate " + this.cantitate + " bucati [VALOARE TOTALA = " + this.Valoare + "]";
        }
    }
}
