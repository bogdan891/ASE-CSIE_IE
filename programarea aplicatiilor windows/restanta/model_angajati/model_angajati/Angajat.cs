using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_angajati
{
    [Serializable]
    public class Angajat : IComparable<Angajat>
    {
        private string nume;
        private DateTime dataNasterii;
        private int idCompanie;
        public Angajat()
        {
            this.nume = "NULL";
            this.dataNasterii = DateTime.Now;
            this.idCompanie = 0;
        }
        public Angajat(string nume, DateTime dataNasterii, int idCompanie)
        {
            this.nume = nume;
            this.dataNasterii = dataNasterii;
            this.idCompanie = idCompanie;
        }
        public string Nume
        {
            get => this.nume;
            set => this.nume = value;
        }
        public DateTime DataNasterii
        {
            get => this.dataNasterii;
            set => this.dataNasterii = value;
        }
        public int IdCompanie
        {
            get => this.idCompanie;
            set => this.idCompanie = value;
        }
        public string NumeCompanie
        {
            get
            {
                var c = MainForm.companii.FirstOrDefault(x => x.Id == idCompanie);
                return c != null ? c.ToString() : "NULL";
            }
        }

        public int CompareTo(Angajat other)
        {
            if (other == null) return 1;
            int result = string.Compare(this.Nume, other.Nume, StringComparison.OrdinalIgnoreCase);
            if (result == 0)
                result = this.DataNasterii.CompareTo(other.DataNasterii);
            return result;

        }

        public static explicit operator bool(Angajat angajat)
        {
            return angajat.idCompanie != 0;
        }
    }
}
