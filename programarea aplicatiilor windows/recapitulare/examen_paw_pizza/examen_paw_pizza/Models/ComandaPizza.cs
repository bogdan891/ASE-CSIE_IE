using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_pizza.Models
{
    [Serializable]
    public class ComandaPizza : ICloneable, Utils.ICumstomizabil
    {
        private string nume;
        private string blat;
        int durataRealizare;
        private List<Topping> topping;
        public string Nume
        {
            get => nume;
            set => nume = value;
        }
        public string Blat
        {
            get => blat;
            set => blat = value;
        }
        public int DurataRealizare
        {
            get => durataRealizare;
            set => durataRealizare = value;
        }
        public List<Topping> Topping
        {
            get => topping;
            set => topping = value;
        }
        public ComandaPizza(string nume, string blat, int durataRealizare, List<Topping> topping)
        {
            this.nume = nume;
            this.blat = blat;
            this.durataRealizare = durataRealizare;
            this.topping = new List<Topping>(topping.Select(t => new Topping(t.Denumire, t.Pret, t.Cod)));
        }
        public ComandaPizza() : this("N/A", "N/A", 0, new List<Topping>()) { }
        public float CalculCostPizza()
        {
            float cost = 0;
            foreach (var top in topping)
            {
                if (top != null)
                {
                    cost += top.Pret;
                }
            }
            return cost;
        }

        public object Clone()
        {
            return new ComandaPizza(nume, blat, durataRealizare, topping);
        }

        public override string ToString()
        {
            string x = $"{Nume},{Blat},{DurataRealizare},";
            foreach(var t in Topping)
            {
                x += string.Join("|", Topping.Select(a => a.ToString()));
            }
            return x;
        }

        //Supraincarcari operatori
        public static ComandaPizza operator +(ComandaPizza c, Topping t)
        {
            if (c == null && t != null)
            {
                c.topping = new List<Topping>();
                c.topping.Add(t);
            }
            else if (c != null && t != null)
            {
                c.topping.Add(t);
            }
            return c;
        }

        public static ComandaPizza operator -(ComandaPizza c, Topping t)
        {
            if (c != null && c.topping.Contains(t))
            {
                c.topping.Remove(t);
            }
            return c;
        }
        public static bool operator <(ComandaPizza c1, ComandaPizza c2)
        {
            if (c1 == null || c2 == null)
            {
                return false;
            }
            return c1.CalculCostPizza() < c2.CalculCostPizza();
        }
        public static bool operator >(ComandaPizza c1, ComandaPizza c2)
        {
            if (c1 == null || c2 == null)
            {
                return false;
            }
            return c1.CalculCostPizza() > c2.CalculCostPizza();
        }

        public static bool operator ==(ComandaPizza c1, ComandaPizza c2)
        {
            if (ReferenceEquals(c1, c2)) return true;
            if (c1 is null || c2 is null) return false;
            return c1.nume == c2.nume && c1.blat == c2.blat && c1.durataRealizare == c2.durataRealizare &&
                   c1.topping.SequenceEqual(c2.topping);
        }
        public static bool operator !=(ComandaPizza c1, ComandaPizza c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object obj)
        {
            if (obj is ComandaPizza other)
            {
                return this == other;
            }
            return false;
        }
    }
}