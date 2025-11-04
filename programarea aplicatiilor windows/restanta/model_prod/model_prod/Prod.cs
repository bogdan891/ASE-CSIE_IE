using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_prod
{
    [Serializable]
    public class Prod
    {
        private int cod;
        private string denumire;
        private double pret;

        public Prod()
        {
            this.cod = 0;
            this.denumire = "NULL";
            this.pret = 0;
        }

        public Prod(int cod, string denumire, double pret)
        {
            this.cod = cod;
            this.denumire = denumire;
            this.pret = pret;
        }

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
        public double Pret
        {
            get => this.pret;
            set => this.pret = value;
        }

        public static bool operator <(Prod x, Prod y)
        {
            return x.cod < y.cod;
        }
        public static bool operator >(Prod x, Prod y)
        {
            return x.cod > y.cod;
        }

        public override string ToString()
        {
            return $"{Denumire} - Cod: {Cod} -> Pret: {Pret}";
        }
    }
}
