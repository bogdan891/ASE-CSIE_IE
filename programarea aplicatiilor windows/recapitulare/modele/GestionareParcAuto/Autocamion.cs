using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionareParcAuto
{
    public class Autocamion : Autoturism, ICloneable, IComparable<Autocamion>
    {
        private float[] greutateMarfaCurse;
        private int nrCurse;
        public Autocamion(int id, string proprietar, float pret, int nrLocuri, float[] greutateMarfaCurse, int nrCurse) : base(id, proprietar, pret, nrLocuri)
        {
            this.greutateMarfaCurse = greutateMarfaCurse;
            this.nrCurse = nrCurse;
        }

        public float[] GreutateMarfaCurse { get => greutateMarfaCurse; set => greutateMarfaCurse = value; }
        public int NrCurse { get => nrCurse; set => nrCurse = value; }

        public object Clone()
        {
            Autocamion copie = (Autocamion)this.MemberwiseClone();

            return copie;
        }

        public int CompareTo(Autocamion other)
        {
            return this.NrCurse.CompareTo(other.NrCurse);
        }

        public static Autocamion operator+(Autocamion a, float greutate)
        {
            float[] rezultat = new float[a.greutateMarfaCurse.Length + 1];

            for (int i = 0; i < a.greutateMarfaCurse.Length; i++)
                rezultat[i] = a.greutateMarfaCurse[i];

            rezultat[rezultat.Length - 1] = greutate;

            a.greutateMarfaCurse = rezultat;

            a.nrCurse += 1;

            return a;

        }

        public static explicit operator float(Autocamion a)
        {
            float medie = 0;

            for (int i = 0; i < a.greutateMarfaCurse.Length; i++)
                medie += a.greutateMarfaCurse[i];
            
            return medie / a.greutateMarfaCurse.Length;
        }

    }
}
