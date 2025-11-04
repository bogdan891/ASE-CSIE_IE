using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicicletePublice
{
    [Serializable]
    public class Bicicleta
    {
        private readonly int codB;
        private string denumire_statie;
        private int km_parcursi;

        public Bicicleta(int codB, string denumire_statie, int km_parcursi)
        {
            this.codB = codB;
            this.denumire_statie = denumire_statie;
            this.km_parcursi = km_parcursi;
        }

        public int CodB => codB;

        public string Denumire_statie { get => denumire_statie; set => denumire_statie = value; }
        public int Km_parcursi { get => km_parcursi; set => km_parcursi = value; }
    }
}
