using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_angajati
{
    [Serializable]
    public class Angajat : IComparable<Angajat>
    {
        private string nume;
        private DateTime dataNasterii;
        private int idCompanie;

        public string Nume
        {
            get => nume;
            set => nume = value;
        }

        public DateTime DataNasterii
        {
            get => dataNasterii;
            set => dataNasterii = value;
        }

        public int IDCompanie
        {
            get => idCompanie; 
            set => idCompanie = value;
        }

        public Angajat() {}

        public Angajat(string nume, DateTime dataNasterii, int idCompanie)
        {
            this.nume = nume;
            this.dataNasterii = dataNasterii;
            this.idCompanie = idCompanie;
        }

        public override string ToString()
        {
            return $"{Nume} - {IDCompanie}";
        }

        public static explicit operator bool(Angajat a)
        {
            return a != null && a.IDCompanie != 0;
        }

        public int CompareTo(Angajat x)
        {
            if(this.Nume.CompareTo(x.Nume) == 0)
                return this.DataNasterii.CompareTo(x.DataNasterii);
            return this.Nume.CompareTo(x.Nume);
        }
    }
}
