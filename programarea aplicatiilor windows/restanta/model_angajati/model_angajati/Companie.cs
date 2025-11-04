using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_angajati
{
    public class Companie
    {
        private int id;
        private string nume;
        public Companie(int id, string nume)
        {
            this.id = id;
            this.nume = nume;
        }
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public string Nume
        {
            get => this.nume;
            set => this.nume = value;
        }

        public override string ToString()
        {
            return this.nume;
        }
    }
}
