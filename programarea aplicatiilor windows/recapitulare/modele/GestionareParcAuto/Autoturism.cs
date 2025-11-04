using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionareParcAuto
{
    public class Autoturism : Vehicul
    {
        private int nrLocuri;
        public Autoturism(int id, string proprietar, float pret, int nrLocuri) : base(id, proprietar, pret)
        {
            this.nrLocuri = nrLocuri;
        }

        public int NrLocuri { get => nrLocuri; set => nrLocuri = value; }
    }
}
