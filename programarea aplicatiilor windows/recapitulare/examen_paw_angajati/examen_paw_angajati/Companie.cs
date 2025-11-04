using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_angajati
{
    [Serializable]
    public class Companie
    {
        private int id;
        private string nume;

        public int Id
        {
            get => id; 
            set => id = value;
        }

        public string Nume
        {
            get => nume;    
            set => nume = value;
        }

        public Companie() {}
        public Companie(int id, string nume)
        {
            this.id = id;
            this.nume = nume;
        }
        public override string ToString()
        {
            return $"{Id} - {Nume}";
        }

    }
}
