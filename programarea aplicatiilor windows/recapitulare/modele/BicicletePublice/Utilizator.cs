using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicicletePublice
{
    [Serializable]
    public class Utilizator
    {
        private string nume;
        private int codB;
        private int durata_utilizare;

        public Utilizator(string nume, int codB, int durata_utilizare)
        {
            this.nume = nume;
            this.codB = codB;
            this.durata_utilizare = durata_utilizare;
        }

        public string Nume { get => nume; set => nume = value; }
        public int CodB { get => codB; set => codB = value; }
        public int Durata_utilizare { get => durata_utilizare; set => durata_utilizare = value; }
    }
}
