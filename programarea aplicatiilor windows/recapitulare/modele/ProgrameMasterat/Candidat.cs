using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrameMasterat
{
    public class Candidat
    {
        private int codCandidat;
        private string numeCandidat;
        private float medieConcurs;
        private int[] vectorOptiuni;

        public Candidat(int codCandidat, string numeCandidat, float medieConcurs, int[] vectorOptiuni)
        {
            this.codCandidat = codCandidat;
            this.numeCandidat = numeCandidat;
            this.medieConcurs = medieConcurs;
            this.vectorOptiuni = vectorOptiuni;
        }

        public int CodCandidat { get => codCandidat; set => codCandidat = value; }
        public string NumeCandidat { get => numeCandidat; set => numeCandidat = value; }
        public float MedieConcurs { get => medieConcurs; set => medieConcurs = value; }
        public int[] VectorOptiuni { get => vectorOptiuni; set => vectorOptiuni = value; }

        public override string ToString()
        {
            string rezultat = "Cod candidat: " + this.codCandidat + ", nume: " + this.numeCandidat + ", medie: " + this.medieConcurs + " optiuni: ";

            for (int i = 0; i < vectorOptiuni.Length; i++)
                rezultat += vectorOptiuni[i] + " ";

            return rezultat;
        }

        public static Candidat operator +(Candidat c, int cod)
        {
            int[] rezultat = new int[c.VectorOptiuni.Length + 1];

            for (int i = 0; i < c.VectorOptiuni.Length; i++)
                rezultat[i] = c.vectorOptiuni[i];

            rezultat[rezultat.Length - 1] = cod;

            c.VectorOptiuni = rezultat;

            return c;
        }
    }
}
