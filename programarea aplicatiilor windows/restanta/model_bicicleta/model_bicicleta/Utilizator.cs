using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_bicicleta
{
    [Serializable]
    public class Utilizator
    {
        private string nume;
        private int codB;
        private int durataUtilizare;

        public Utilizator()
        {
            this.nume = "NULL";
            this.codB = 0;
            this.durataUtilizare = 0;
        }
        public Utilizator(string nume, int codB, int durataUtilizare)
        {
            this.nume = nume;
            this.codB = codB;
            this.durataUtilizare = durataUtilizare;
        }
        public string Nume
        {
            get => this.nume;
            set => this.nume = value;
        }
        public int CodB
        {
            get => this.codB;
            set => this.codB = value;
        }
        public int DurataUtilizare
        {
            get => this.durataUtilizare;
            set => this.durataUtilizare = value;
        }
    }
}
