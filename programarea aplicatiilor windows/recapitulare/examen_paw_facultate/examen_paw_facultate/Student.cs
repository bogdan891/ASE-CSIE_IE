using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_facultate
{
    public class Student
    {
        private int nrMatricol;
        private string nume;
        private float medie;

        public int NrMatricol
        {
            get => nrMatricol;
            set => nrMatricol = value;
        }
        public string Nume
        {
            get => nume;
            set => nume = value;
        }
        public float Medie
        {
            get => medie;
            set => medie = value;
        }
        public Student(int nrMatricol, string nume, float medie)
        {
            this.nrMatricol = nrMatricol;
            this.nume = nume;
            this.medie = medie;
        }
        public override string ToString()
        {
            return $" {NrMatricol} - {Nume} - Medie: {Medie}";
        }
    }
}
