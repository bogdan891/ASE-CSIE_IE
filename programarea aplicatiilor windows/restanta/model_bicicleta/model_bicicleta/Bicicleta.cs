using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_bicicleta
{
    [Serializable]
    public class Bicicleta
    {
        private readonly int codB;
        private string statieParcare;
        private int kmParcursi;

        public Bicicleta()
        {
            this.codB = 0;
            this.statieParcare = "NULL"; ;
            this.kmParcursi = 0;
        }
        public Bicicleta(int codB, string statieParcare, int kmParcursi)
        {
            this.codB = codB;
            this.statieParcare = statieParcare;
            this.kmParcursi = kmParcursi;
        }
        public int CodB
        {
            get => this.codB;
        }
        public string StatieParcare
        {
            get => this.statieParcare;
            set => this.statieParcare = value;
        }
        public int KmParcursi
        {
            get => this.kmParcursi;
            set => this.kmParcursi = value;
        }
    }
}
