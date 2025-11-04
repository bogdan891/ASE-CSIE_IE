using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_pizza.Models
{
    [Serializable]
    public class Topping
    {
        private string denumire;
        private float pret;
        private readonly int cod;

        public string Denumire
        {
            get => denumire;
            set => denumire = value;
        }
        public float Pret
        {
            get => pret;
            set => pret = value;
        }
        public int Cod
        {
            get => cod;
        }

        public Topping() {}
        public Topping(string denumire, float pret, int cod)
        {
            this.denumire = denumire;
            this.pret = pret;
            this.cod = cod;
        }
        public override bool Equals(object obj)
        {
            return obj is Topping topping &&
                   denumire == topping.denumire &&
                   pret == topping.pret &&
                   cod == topping.cod;
        }

        public override string ToString()
        {
            return $"{denumire},{pret},{cod}";
        }
    }
}
