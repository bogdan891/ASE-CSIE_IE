using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace subiect_examen.Models
{
    [Serializable]
    public class Tren
    {
        private string nrTren;
        private string ruta;
        private int cerereBilete;
        private List<Vagon> vagoane;

        //Getters & Setters
        public string NrTren
        {
            get => this.nrTren;
            set => this.nrTren = value;
        }
        public string Ruta
        {
            get => this.ruta;
            set => this.ruta = value;
        }
        public int CerereBilete
        {
            get => this.cerereBilete;
            set => this.cerereBilete = value;
        }
        public List<Vagon> Vagoane
        { 
            get => this.vagoane;
            set => this.vagoane = value;
        }

        //Constructors
        public Tren()
        {
            this.NrTren = "NULL";
            this.ruta = "NULL";
            this.cerereBilete = 0;
            this.vagoane = new List<Vagon>();
        }
        public Tren(string nrTren, string ruta, int cerereBilete)
        {
            NrTren = nrTren;
            Ruta = ruta;
            CerereBilete = cerereBilete;
            Vagoane = new List<Vagon>();
        }

        //Override index
        public int this[int index]
        {
            get => vagoane[index].Capacitate;
            set => vagoane[index].Capacitate = value;
        }
        //Override ToString
        public override string ToString()
        {
            return $"Tren {NrTren} ( {Ruta} ) - {Vagoane.Count} vagoane - Locuri libere {this.LocuriRamase}";
        }

        //Metoda
        public int LocuriRamase
        {
            get
            {
                int totalLocuri = Vagoane.Sum(v => v.Capacitate);
                return totalLocuri - CerereBilete;
            }
        }
    }
}
