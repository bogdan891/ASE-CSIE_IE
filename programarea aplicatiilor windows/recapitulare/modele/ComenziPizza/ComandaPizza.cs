using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComenziPizza
{
    public class ComandaPizza : ICloneable, ICustomizabil
    {
        private string nume;
        private string blat;
        private int durataRealizare;
        private List<Topping> toppinguri;
        private static readonly float pretDefaultPizza = 10.5f;

        public ComandaPizza(string nume, string blat, int durataRealizare, List<Topping> toppinguri)
        {
            this.nume = nume;
            this.blat = blat;
            this.durataRealizare = durataRealizare;
            this.toppinguri = toppinguri;
        }


        public string Nume { get => nume; set => nume = value; }
        public string Blat { get => blat; set => blat = value; }
        public int DurataRealizare { get => durataRealizare; set => durataRealizare = value; }
        public List<Topping> Toppinguri { get => toppinguri; set => toppinguri = value; }

        public float CalculCostPizza()
        {
            float pretTotal = 0;

            foreach (Topping topping in toppinguri)
                pretTotal += topping.Pret * topping.Cantitate;

            return pretTotal + pretDefaultPizza;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public Topping this[int index]
        {
            get => this.toppinguri[index];
            set => this.toppinguri[index] = value;
        }

        public static bool operator < (ComandaPizza c1, ComandaPizza c2)
        {
            return c1.CalculCostPizza() < c2.CalculCostPizza();
        }

        public static bool operator > (ComandaPizza c1, ComandaPizza c2)
        {
            return !(c1<c2);
        }

        public static ComandaPizza operator + (ComandaPizza comanda, Topping t)
        {
            comanda.Toppinguri.Add(t);

            return comanda;
        }
        public override string ToString()
        {
            return this.nume + " " + this.blat + " " + this.durataRealizare + " [PRET TOTAL: " + this.CalculCostPizza() + "]";
        }


    }
}
