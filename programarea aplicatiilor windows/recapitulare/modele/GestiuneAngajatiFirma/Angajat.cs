using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiuneAngajatiFirma
{
    public class Angajat
    {
        private string nume;
        private DateTime dataNasterii;
        private int idCompanie;

        public Angajat(string nume, DateTime dataNasterii, int idCompanie)
        {
            this.nume = nume;
            this.dataNasterii = dataNasterii;
            this.idCompanie = idCompanie;
        }

        public Angajat(string nume, DateTime dataNasterii)
        {
            this.nume = nume;
            this.dataNasterii = dataNasterii;
            
        }

        public string Nume { get => nume; set => nume = value; }
        public DateTime DataNasterii { get => dataNasterii; set => dataNasterii = value; }
        public int IdCompanie { get => idCompanie; set => idCompanie = value; }

        public static explicit operator bool(Angajat a)
        {
            if (a.idCompanie != 0)
                return true;
            return false;
        }
    }
}
