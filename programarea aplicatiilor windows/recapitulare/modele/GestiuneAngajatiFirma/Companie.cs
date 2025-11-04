using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiuneAngajatiFirma
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

        public int Id { get => id; set => id = value; }
        public string Nume { get => nume; set => nume = value; }
    }
}
