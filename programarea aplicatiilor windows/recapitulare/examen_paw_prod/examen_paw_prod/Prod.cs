using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_prod
{
    [Serializable]
    public class Prod
    {
        private int cod;
        private string denumire;
        private float pret;

        public int Cod 
        {
            get => this.cod;
            set => this.cod = value;
        }
        public string Denumire
        {
            get => this.denumire;
            set => this.denumire = value;
        }
        public float Pret
        {
            get => this.pret;
            set => this.pret = value;
        }
        public Prod()
        {
            cod = 0;
            denumire = "";
            pret = 0;
        }

        public Prod(int cod, string denumire, float pret)
        {
            this.cod = cod;
            this.denumire = denumire;
            this.pret = pret;
        }

        public override string ToString()
        {
            return $"{cod} - {denumire} - {pret}";
        }

        // Operator <
        public static bool operator <(Prod a, Prod b)
        {
            return a.Pret < b.Pret;
        }

        // Operator >
        public static bool operator >(Prod a, Prod b)
        {
            return a.Pret > b.Pret;
        }
    }
}